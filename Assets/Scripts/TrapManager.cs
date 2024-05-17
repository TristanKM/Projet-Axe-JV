using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField] private float _trapTime;
    [SerializeField] private float _length;
    
    private bool _isUsed = false;
    private float _currentTimer;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TrapManager " + other.gameObject.tag);
        if (!_isUsed )
        {
            _isUsed = true;
            var position = transform.position;
            position.y += _length;
            transform.position = position;
            _currentTimer = _trapTime;
        }
    }

    void Update()
    {
        if (_isUsed)
        {
            if (_currentTimer > 0)
            {
                _currentTimer -= Time.deltaTime;
                if (_currentTimer < 0)
                {
                    var position = transform.position;
                    position.y -= _length;
                    transform.position = position;
                }
            }
        }
    }
}
