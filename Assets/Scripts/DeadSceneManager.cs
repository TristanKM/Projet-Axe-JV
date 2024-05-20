using UnityEngine;
using UnityEngine.UI;

public class DeadSceneManager : MonoBehaviour
{

    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _quitButton;

    void ReplayOnClick()
    {
        Debug.Log("playonclick");
        GameManager.GetInstance().ReloadScene();
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
        _replayButton.onClick.AddListener(ReplayOnClick);
        _quitButton.onClick.AddListener(QuitOnClick);
    }

    
}
