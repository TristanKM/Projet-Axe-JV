using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool _isFrozen = false;
    private Vector3 spawnPosition;

    public bool IsFrozen { get { return _isFrozen; } }

    public void UnFreeze()
    { _isFrozen = false; }

    public void Freeze()
    {
        _isFrozen = true;
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
    }

    void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
