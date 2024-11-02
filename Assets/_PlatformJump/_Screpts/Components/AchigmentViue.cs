using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchigmentViue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _discription;
    [SerializeField] private Image _imageStatus;
    [SerializeField] private Sprite _complited;
    [SerializeField] private Sprite _fall;

    public void SetData(string Header, string Discription, bool status)
    {
        _header.text = Header;
        _discription.text = Discription;
        if (status)
            _imageStatus.sprite = _complited;
        else
            _imageStatus.sprite = _fall;
    }
}