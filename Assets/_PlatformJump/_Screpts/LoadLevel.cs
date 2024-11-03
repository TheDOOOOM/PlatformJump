using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _starZero;
    [SerializeField] private Sprite _starOne;
    [SerializeField] private Sprite _starTwo;
    [SerializeField] private Sprite _starFree;

    private LevelsData _levelsData;
    private DialogLauncher _dialogLauncher;
    private int _index;

    private void Start()
    {
        _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
    }

    public void SetIndexLevel(int index, LevelConfig dataConfig, LevelsData levelsData)
    {
        _index = index;
        SetStars(dataConfig.Stars);
        _levelsData = levelsData;
    }

    private void SetStars(int countStars)
    {
        Debug.Log(countStars);
        switch (countStars)
        {
            case 0:
                _image.sprite = _starZero;
                break;
            case 1:
                _image.sprite = _starOne;
                break;
            case 2:
                _image.sprite = _starTwo;
                break;
            case 3:
                _image.sprite = _starFree;
                break;
            default:
                _image.sprite = _starZero;
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _levelsData.SetLevel(_index);
        _dialogLauncher.ShowGameScreen();
    }
}