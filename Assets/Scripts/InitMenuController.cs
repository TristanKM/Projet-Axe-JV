using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMenuController : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;

    void PlayOnClick()
    {
        Debug.Log("playonclick");
        GameManager.GetInstance().StartGame();
    }

    void QuitOnClick()
    {
        Debug.Log("quitonclick");
    }

    void Start()
    {
        _playButton.onClick.AddListener(PlayOnClick);
        _quitButton.onClick.AddListener(QuitOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
