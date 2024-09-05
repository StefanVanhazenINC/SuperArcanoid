using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MapLevelSetting 
{
    [SerializeField] private Texture2D _mapLevel;
    [SerializeField] private float _xSpacing = 1;
    [SerializeField] private float _ySpacing = 1;

    public Texture2D MapLevel { get => _mapLevel;}
    public float XSpacing { get => _xSpacing;  }
    public float YSpacing { get => _ySpacing;  }
}

public class LevelGeneration : MonoBehaviour
{
    //стартовая точка
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private BrickConfig _brickConfig;
    [SerializeField] private MapLevelSetting[] _mapLevels;
    [SerializeField] private Brick _brickPrefab;
    [SerializeField] private Transform _levelParent;
    [SerializeField] private Transform _centerLevel;
    [HideInInspector] public UnityEvent<int> OnUpdateLevelIndex;

    private Brick[] _brickPool = new Brick[250];
    private int _indexLevel = 0;
    private int _brickInLevel = 0;
    private int _currentBrickDestroy = 0;

    public int IndexLevel 
    { 
        get => _indexLevel;
        set 
        {
            _indexLevel = value;
            OnUpdateLevelIndex?.Invoke(value);
        } 
    }

    //сколько линий от стартовой точки 
    // массив c цветом закрепленным за определенной платформой
    // платформы берутся из пула и к ним отсюда подключается система очков 
    //ссылка систему очков
    private void Awake()
    {
        Consturctor();
    }
    private void Consturctor() 
    {
        CreatePool();
    }
    public void CreatePool() 
    {
        for (int i = 0; i < _brickPool.Length; i++)
        {
            _brickPool[i] = Instantiate(_brickPrefab,_levelParent);
            _brickPool[i].OnDeathBrickInt.AddListener(_scoreManager.AddedScore);
            _brickPool[i].OnDeathBrick.AddListener(CheckEndLevel);
            _brickPool[i].gameObject.SetActive(false);
        }
    }
    public void ClearLevel() 
    {
        for (int i = 0; i < _brickPool.Length; i++)
        {
            if (_brickPool[i].gameObject.activeSelf) 
            {
                _brickPool[i].gameObject.SetActive(false);
            }
        }
    }
    public Brick GetTileInPool() 
    {
        for (int i = 0; i < _brickPool.Length; i++)
        {
            if (!_brickPool[i].gameObject.activeSelf) 
            {
                return _brickPool[i];
            }
        }
        Debug.LogError("Array out of Bound");
        return null;
    }
    public void CheckEndLevel() 
    {
        _currentBrickDestroy++;
        if (_currentBrickDestroy>=_brickInLevel) 
        {
            _indexLevel++;
            if (_indexLevel >= _mapLevels.Length)
            {
                _gameManager.WinGameWindowOpen();
            }
            else 
            {
                _gameManager.LoadLevel();
                LoadLevel(_indexLevel);
            }
        }
    }
    public void LoadLevel(int level) 
    {
        _currentBrickDestroy = 0;
        _brickConfig.InitBrickDictionary();
        GenerationLevel(_mapLevels[level]);
    }
    private void GenerationLevel(MapLevelSetting mapLevel) 
    {
       
        float t_spacingX = mapLevel.XSpacing;
        float t_spacingY = mapLevel.YSpacing;
        Texture2D t_maxLevel = mapLevel.MapLevel;
        for (int x = 0; x < t_maxLevel.width; x++)
        {
            for (int y = 0; y < t_maxLevel.height; y++)
            {
                Vector3 t_position = new Vector2(x * t_spacingX, y * t_spacingY);

                Brick t_brick = GetTileInPool();
                Brick t_brickInConfig = _brickConfig.TryGetBrick(t_maxLevel.GetPixel(x, y));
                if (t_brickInConfig!=null) 
                {
                    t_brick.SetBrick(t_brickInConfig.MaxHealth,t_brickInConfig.ScorePoint);
                    t_brick.transform.position = _centerLevel.position + t_position;
                    t_brick.gameObject.SetActive(true);
                    _brickInLevel++;
                }
            }
        }
    }
}
