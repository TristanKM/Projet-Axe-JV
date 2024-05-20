using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiPatrol : MonoBehaviour
{

    public float speed = 2f;                                            
    [SerializeField, Range(0.1f, 50f)] private float limiteDroite = 1f; 
    [SerializeField, Range(0.1f, 50f)] private float limiteGauche = 1f; 
    private Vector3 limiteDroitePosition;                               
    private Vector3 limiteGauchePosition;                               
    private Rigidbody2D rb;                             
    private float direction = 1f;                                      
    private SpriteRenderer skin;                                

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        skin = GetComponent<SpriteRenderer>();

        limiteDroitePosition = transform.position + new Vector3(limiteDroite, 0, 0);
        limiteGauchePosition = transform.position - new Vector3(limiteGauche, 0, 0);
    }

    void Update() {
        if (Mathf.Abs(rb.velocity.x) < 0.1f) {
            direction = -direction;
        }
        
        if (transform.position.x > limiteDroitePosition.x) {
            direction = -1f;
        }

        if (transform.position.x < limiteGauchePosition.x) {
            direction = 1f;
        }

        if (direction == 1f) {
            skin.flipX = true;
        }

        if (direction == -1f) {
            skin.flipX = false;
        }

        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    void OnDrawGizmos() {
        if (!Application.IsPlaying(gameObject)) {
            limiteDroitePosition = transform.position + new Vector3(limiteDroite, 0, 0);
            limiteGauchePosition = transform.position - new Vector3(limiteGauche, 0, 0);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawCube(limiteDroitePosition, new Vector3(0.2f, 1, 0.2f));
        Gizmos.DrawCube(limiteGauchePosition, new Vector3(0.2f, 1, 0.2f));
        Gizmos.DrawLine(limiteDroitePosition, limiteGauchePosition);
    }
}
