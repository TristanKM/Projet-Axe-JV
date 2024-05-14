using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    public float deccalageGroundcheck = -1;
    private Rigidbody2D rb;
    private Collider2D[] colls;
    private bool grounded;
    private Collider2D monColl;
    private SpriteRenderer skin;
    private Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        monColl = GetComponent<Collider2D>();
        skin = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        groundCheck();
        controlCheck();
        flipCheck();
        animCheck();
    }

    void controlCheck() {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
//      Debug.Log("==== " + rb.velocity.y);
        if (Input.GetButtonDown("Jump") && grounded) {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    void groundCheck() {
        grounded = false;
        colls = Physics2D.OverlapCircleAll(transform.position + Vector3.up * deccalageGroundcheck, monColl.bounds.extents.x * 0.9f);
        foreach(Collider2D coll in colls) {
            if(coll != monColl && !coll.isTrigger) {
                grounded = true;
                break;
            }
        }
    }

    void flipCheck() {
        if(Input.GetAxisRaw("Horizontal") < 0) {
            skin.flipX = true;
        }
        if (Input.GetAxisRaw("Horizontal") > 0) {
            skin.flipX = false;
        }
    }

    void animCheck() {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("grounded", grounded);
    }

    private void OnDrawGizmos() {
        if(monColl == null) {
            monColl = GetComponent<CapsuleCollider2D>();
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * deccalageGroundcheck, monColl.bounds.extents.x * 0.9f);
    }
}