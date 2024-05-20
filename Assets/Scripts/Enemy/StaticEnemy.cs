using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Direction _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _frequency;
    [SerializeField] private Vector3 _startPosition;

    void Start()
    {
        StartCoroutine(InfiniteFire());
    }

    IEnumerator InfiniteFire()
    { 
        for(;; )
        {
            Fire();
            yield return new WaitForSeconds( _frequency );
        }
    }

    private void Fire()
    {
        GameObject p = Instantiate(_projectile, _startPosition + transform.position, Quaternion.identity);
        Rigidbody2D rigidbody = p.GetComponent<Rigidbody2D>();
        var velocity = rigidbody.velocity;
        if (_direction == Direction.Right)
        {
            velocity.x = _speed; 
        } else
        {
            velocity.x = -_speed;
        }
        rigidbody.velocity = velocity;
    }
    
    void Update()
    {
        
    }

}

