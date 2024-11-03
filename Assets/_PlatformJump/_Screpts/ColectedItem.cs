using System;
using Services;
using UnityEngine;

public class ColectedItem : MonoBehaviour
{
     private CollectionCounter _collectionCounter;

    private void Start()
    {
        _collectionCounter = ServiceLocator.Instance.GetService<CollectionCounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMove playerMove))
        {
            _collectionCounter.AddValue();
            Destroy(gameObject);
        }
    }
}