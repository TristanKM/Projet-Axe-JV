using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private float _freezeTime;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private Animator anim;

    private float _currentTimer;
    private bool _freeze = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("DamageZone " + other.gameObject.tag);
        if (other.gameObject.tag == "Trap" && !_freeze)
        {
            PlayerLife.GetInstance().TakeDamage(1);
            anim.SetFloat("velocityX", 0);
            anim.SetFloat("velocityY", 0);
            _freeze = true;
            _currentTimer = _freezeTime;
            _playerManager.Freeze();
        }
    }

    void Update()
    {
        if (_freeze)
        {
            if (_currentTimer > 0)
            {
                _currentTimer -= Time.deltaTime;
                if (_currentTimer < 0)
                {
                    _freeze = false;
                    if (PlayerLife.GetInstance().IsAlive())
                    {
                        _playerManager.Respawn();
                        _playerManager.UnFreeze();
                    }
                    else { }
                }
            }
        }
    }


}
