using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _mainMenuClip;
    [SerializeField] private AudioClip _prehistoriqueClip;
    [SerializeField] private AudioClip _coulureClip;
    [SerializeField] private AudioClip _futuristeClip;
    [SerializeField] private AudioClip _menuFinClip;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static AudioManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AudioManager();
        }
        return _instance;
    }

    public void UpdateClip(WorldScene worldScene)
    {
        if (worldScene == WorldScene.MainMenu)
        {
            _audioSource.clip = _mainMenuClip;
            _audioSource.Play();
        } else if (worldScene == WorldScene.Prehistorique)
        {
            _audioSource.clip = _prehistoriqueClip;
            _audioSource.Play();
        } else if (worldScene == WorldScene.Coulure)
        {
            _audioSource.clip = _coulureClip;
            _audioSource.Play();
        } else if (worldScene == WorldScene.Futuriste)
        {
            _audioSource.clip = _futuristeClip;
            _audioSource.Play();
        } else if (worldScene == WorldScene.MenuFin)
        {
            _audioSource.clip = _menuFinClip;
            _audioSource.Play();
        }
    }
}

