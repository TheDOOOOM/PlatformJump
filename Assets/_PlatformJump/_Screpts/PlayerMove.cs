using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GravityController _gravityController;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    public GravityController GravityController => _gravityController;

    public void Jump()
    {
        if (_rigidbody.velocity.y != 0)
            return;

        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void MoveDirection(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
    }
}