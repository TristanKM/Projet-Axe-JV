using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision2D : MonoBehaviour
{
    private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current scene: " + currentSceneName);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Collision with Trap detected. Reloading scene...");
            SceneManager.LoadScene(currentSceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Trigger with Trap detected. Reloading scene...");
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
