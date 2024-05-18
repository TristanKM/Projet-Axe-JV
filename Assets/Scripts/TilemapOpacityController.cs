using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapOpacityController : MonoBehaviour
{
    public Tilemap tilemap;
    private Color originalColor;
    public float opacity = 0.5f; // L'opacité souhaitée (50% ici)

    void Start()
    {
        if (tilemap == null)
        {
            tilemap = GetComponent<Tilemap>();
        }

        if (tilemap != null)
        {
            originalColor = tilemap.color;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tilemap != null)
        {
            SetTilemapOpacity(opacity);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tilemap != null)
        {
            SetTilemapOpacity(1f); // Restaurer l'opacité à 100%
        }
    }

    void SetTilemapOpacity(float alpha)
    {
        Color newColor = tilemap.color;
        newColor.a = alpha;
        tilemap.color = newColor;
    }
}
