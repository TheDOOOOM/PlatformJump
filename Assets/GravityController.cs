
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private float _gravityStrengthUp = 9.8f;
    [SerializeField] private float _gravityStrengthDown = 9.8f;
    [SerializeField] private float _transitionSpeed = 2f;

    private Vector2 _upGravityDirection = Vector2.up;
    private Vector2 _downGravityDirection = Vector2.down;
    private Vector2 _targetGravity;
    private Vector2 _currentGravity;
    private bool _isUsingUpGravity;

    private void Start()
    {
        _targetGravity = _downGravityDirection * _gravityStrengthDown;
        _currentGravity = _targetGravity;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        _currentGravity = Vector2.Lerp(_currentGravity, _targetGravity, _transitionSpeed * Time.fixedDeltaTime);
        _playerRigidbody.AddForce(_currentGravity * _playerRigidbody.mass, ForceMode2D.Force);
    }

    private void SwitchGravity()
    {
        _isUsingUpGravity = !_isUsingUpGravity;
        _targetGravity = _isUsingUpGravity
            ? _upGravityDirection * _gravityStrengthUp
            : _downGravityDirection * _gravityStrengthDown;
    }
}