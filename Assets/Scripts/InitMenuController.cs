using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class InitMenuController : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _creditButton;
    [SerializeField] private Button _backButton;

    void PlayOnClick()
    {
        Debug.Log("playonclick");
        GameManager.GetInstance().StartGame();
    }

    void QuitOnClick()
    {
        #if UNITY_EDITOR
                if (UnityEditor.EditorApplication.isPlaying == true)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
        #else
                            Application.Quit();
   
        #endif
    }

    void Start()
    {
        _playButton.onClick.AddListener(PlayOnClick);
        _creditButton.onClick.AddListener(CreditOnClick);
        _backButton.onClick.AddListener(BackOnClick);
        _quitButton.onClick.AddListener(QuitOnClick);
    }

    void CreditOnClick()
    {
        Debug.Log("plsqsqsqayonclick");
        SceneManager.LoadScene(23, LoadSceneMode.Single);
    }

    void BackOnClick()
    {
        Debug.Log("plsqsqsqddddddayonclick");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
