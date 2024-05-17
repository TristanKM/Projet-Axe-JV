using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public bool IsAlive() { return _life > 0; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            Restart();
        }
        else if (_instance == null)
        {
            _instance = this;
            Restart();
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

    public void TakeDamage(int damage)
    {
        _life -= damage;
        if (_life <= 0)
        {
            //GameManager.GetInstance().GameOver();
        }
    }
}