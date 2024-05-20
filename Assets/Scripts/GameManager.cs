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
            _currentLevel = SceneManager.GetActiveScene().buildIndex;
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
        AudioManager.GetInstance().UpdateClip(WorldScene.Prehistorique);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        _currentLevel += 1;
        if (_currentLevel == 1)
        {
            AudioManager.GetInstance().UpdateClip(WorldScene.Prehistorique);
        }  else if (_currentLevel == 7)
        {
            AudioManager.GetInstance().UpdateClip(WorldScene.Coulure);
        } else if (_currentLevel == 13)
        {
            AudioManager.GetInstance().UpdateClip(WorldScene.Futuriste);
        } else if (_currentLevel == 19)
        {
            AudioManager.GetInstance().UpdateClip(WorldScene.MenuFin);
        }
        SceneManager.LoadScene(_currentLevel);

    }

    public void GameOver()
    {
        Debug.Log("game over");
    }

    public void ShowDeadMenu()
    {
        Debug.Log("ShowDeadMenu");
        if (_currentLevel >= 1 && _currentLevel <= 6)
        {
            SceneManager.LoadScene(20, LoadSceneMode.Additive);
        } else if (_currentLevel >= 7 && _currentLevel <= 12)
        {
            SceneManager.LoadScene(21, LoadSceneMode.Additive);
        }
        else 
        {
            SceneManager.LoadScene(22, LoadSceneMode.Additive);
        }
    } 

    public void EndOfGame()
    {

    }
}
