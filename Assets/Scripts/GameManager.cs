using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private int _currentLevel = -1;
    public int CurrentLevel {  get { return _currentLevel; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        } else if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }

    public void ShowMenu()
    {

    }

    public void StartGame()
    {
        PlayerLife.GetInstance().Restart();
        _currentLevel = 1;
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        _currentLevel += 1;
        SceneManager.LoadScene(_currentLevel);
    }

    public void GameOver()
    {
        Debug.Log("game over");
    }

    public void EndOfGame()
    {

    }
}
