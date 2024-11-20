using System;
using System.Threading.Tasks;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _destroySprite;
    [SerializeField] private BoxCollider2D _boxCollider;
    private bool _iDestroy = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMove playerMove))
        {
            if (_boxCollider == null)
            {
                return;
            }
            _boxCollider.isTrigger = false;
            StartDestroy();
        }
    }

    private async void StartDestroy()
    {
        var delay = TimeSpan.FromSeconds(3f);
        while (!_iDestroy)
        {
            _spriteRenderer.sprite = _destroySprite;
            await Task.Delay(delay);
            _iDestroy = true;
          //  gameObject.SetActive(false);
        }
    }
}