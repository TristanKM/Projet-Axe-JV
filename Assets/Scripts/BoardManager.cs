using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private TextMeshProUGUI _LevelText;


    void Start()
    {
        
    }

    void Update()
    {
        _lifeText.text = "Vies : " + PlayerLife.GetInstance().Life;
        _LevelText.text = "Level : " + GameManager.GetInstance().CurrentLevel;
    }
}
