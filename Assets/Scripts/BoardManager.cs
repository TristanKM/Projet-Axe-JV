using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardManager : MonoBehaviour
{
     private TextMeshProUGUI _lifeText;
    [SerializeField] private TextMeshProUGUI _LevelText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _lifeText.text = "Vies : " + PlayerLife.GetInstance().Life;
        _LevelText.text = "Level : " + GameManager.GetInstance().CurrentLevel;
    }
}
