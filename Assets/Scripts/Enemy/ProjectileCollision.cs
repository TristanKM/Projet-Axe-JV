using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ProjectileCollision " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            PlayerLife.GetInstance().TakeDamage(1);
        } else if (other.gameObject.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
