using UnityEngine;

namespace _PlatformJump._Screpts.Components
{
    public class GravityComponent : MonoBehaviour
    {
        [SerializeField] private float gravityForce = 9.81f; // Сила гравитации
        [SerializeField] private float jumpForce = 5.0f; // Сила прыжка
        [SerializeField] private KeyCode toggleGravityKey = KeyCode.G; // Кнопка переключения гравитации
        [SerializeField] private KeyCode jumpKey = KeyCode.Space; // Кнопка прыжка
        [SerializeField] private Rigidbody2D _rigidbody;

        private bool _isGravityInverted; // Показывает, инвертирована ли гравитация
        private Vector2 _gravityDirection; // Направление гравитации
        private bool _isGrounded; // Флаг для проверки, на земле ли игрок

        private Vector2 _velocity; // Текущая скорость объекта

        private void Awake()
        {
            _gravityDirection = Vector2.down; // Начальное направление гравитации - вниз
        }

        public void SwitchGravity() => ToggleGravity();

        private void FixedUpdate()
        {
            _velocity += _gravityDirection * (gravityForce * Time.fixedDeltaTime);
            _rigidbody.MovePosition(_rigidbody.position + _velocity * Time.fixedDeltaTime);
        }

        private void ToggleGravity()
        {
            _isGravityInverted = !_isGravityInverted;
            _gravityDirection = _isGravityInverted ? Vector2.up : Vector2.down;
            _velocity = _gravityDirection * (gravityForce * Time.fixedDeltaTime);
        }
    }
}