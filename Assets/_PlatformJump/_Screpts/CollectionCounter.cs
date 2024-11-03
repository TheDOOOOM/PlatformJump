using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectionCounter : MonoBehaviour, IService
{
    [SerializeField] private TextMeshProUGUI _textCount;

    private int _count = 0;
    public int Count => _count;

    public void AddValue()
    {
        _count++;
        _textCount.text = $"{_count}";
    }
}