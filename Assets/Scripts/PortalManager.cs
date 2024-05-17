using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
 
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PortalManager " + other.gameObject.tag);
        GameManager.GetInstance().NextLevel();
    }
}
