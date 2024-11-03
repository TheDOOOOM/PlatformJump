using UnityEngine;

public class CollisionSpriteSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite _topCollisionSprite;
    [SerializeField] private Sprite _bottomCollisionSprite;
    [SerializeField] private Sprite _leftMovementSprite;
    [SerializeField] private Sprite _rightMovementSprite;
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpThreshold = 0.1f;

    private void Update()
    {
        UpdateMovementSprite();
    }

    private void UpdateMovementSprite()
    {
        if (Mathf.Abs(_rigidbody2D.velocity.y) > _jumpThreshold)
        {
            _spriteRenderer.sprite = _jumpSprite;
        }
        else if (_rigidbody2D.velocity.x > 0.1f)
        {
            _spriteRenderer.sprite = _rightMovementSprite;
        }
        else if (_rigidbody2D.velocity.x < -0.1f)
        {
            _spriteRenderer.sprite = _leftMovementSprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                _spriteRenderer.sprite = _topCollisionSprite;
            }
            else if (contact.normal.y < -0.5f)
            {
                _spriteRenderer.sprite = _bottomCollisionSprite;
            }
        }
    }
}