using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreDisplay;

    public void OpenDialog(int score) 
    {
        gameObject.SetActive(true);
        _scoreDisplay.text = "Score:" + score;
    }
    public void CloseDialog() 
    {
        gameObject.SetActive(false);
    }
}
