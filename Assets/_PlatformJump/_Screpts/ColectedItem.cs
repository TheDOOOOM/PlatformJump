using UnityEngine;

public class ColectedItem : MonoBehaviour
{
    [SerializeField] private CollectionCounter _collectionCounter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMove playerMove))
        {
            _collectionCounter.AddValue();
            Destroy(gameObject);
        }
    }
}