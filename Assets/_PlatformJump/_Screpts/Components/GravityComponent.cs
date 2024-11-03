using System;
using UnityEngine;

namespace _PlatformJump._Screpts.Components
{
    public class GravityComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _gravityObject;
        [SerializeField] private float _smoothingFactor;
        [SerializeField] private float _attractionSpeed;

        private Vector2 _forceDirection;

        private void Start()
        {
            _forceDirection = Vector2.down;
        }

        private void FixedUpdate()
        {
            Vector2 targetPosition =
                _gravityObject.position + _forceDirection * (_attractionSpeed * Time.fixedDeltaTime);
            _gravityObject.MovePosition(Vector2.Lerp(_gravityObject.position, targetPosition, _smoothingFactor));
        }

        public void SwitchDirection()
        {
            _forceDirection = _forceDirection == Vector2.down ? Vector2.up : Vector2.down;
        }
    }
}