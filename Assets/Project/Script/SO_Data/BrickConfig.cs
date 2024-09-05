using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BrickContainer 
{
    [SerializeField] private Color _colorInTextureMap;
    [SerializeField] private Brick _brickPrefab;

    public Color ColorInTextureMap { get => _colorInTextureMap;  }
    public Brick BrickPrefab { get => _brickPrefab;  }
}


[CreateAssetMenu]
public class BrickConfig : ScriptableObject
{
    [SerializeField] private BrickContainer[] _bricksInLevel;
  

    private Dictionary<Color, Brick> _brickDictionary;

   

    public void InitBrickDictionary() 
    {
        _brickDictionary = null;
        if (_brickDictionary == null) 
        {
            _brickDictionary = new Dictionary<Color, Brick>();

            foreach (BrickContainer brickCon in _bricksInLevel) 
            {
                if (!_brickDictionary.ContainsKey(brickCon.ColorInTextureMap))
                {
                    _brickDictionary.Add(brickCon.ColorInTextureMap, brickCon.BrickPrefab);
                }
                else 
                {
                    Debug.LogError("Duplicate color : " + brickCon.ColorInTextureMap);
                }
            }
        }
    }
    public Brick TryGetBrick(Color key) 
    {
        if (_brickDictionary.TryGetValue(key, out Brick brick)) 
        {
            return brick;
        }
        return null;

    }
}
