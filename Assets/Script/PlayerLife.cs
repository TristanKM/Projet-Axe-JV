using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private static PlayerLife _instance;

    [SerializeField] private int _startLife;
    private int _life;
    public int Life
    { 
        get { return _life; } 
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static PlayerLife GetInstance()
    {
        if (_instance == null)
        {
            _instance = new PlayerLife();
        }
        return _instance;
    }

    public void Restart()
    {
        _life = _startLife;
    }
}
