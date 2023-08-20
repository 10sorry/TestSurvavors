using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rb;
    private Animator _animator;
    private GameObject _player;
    private float speed = 1.5f;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = (_player.transform.position - transform.position).normalized;
        _animator.SetFloat(Horizontal, _direction.x);
        _animator.SetFloat(Vertical, _direction.y);
        _animator.SetFloat(Speed, _direction.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (speed * Time.fixedDeltaTime));
    }
}
