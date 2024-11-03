using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPraise;
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _starZero;
    [SerializeField] private Sprite _starOne;
    [SerializeField] private Sprite _starTwo;
    [SerializeField] private Sprite _starFree;

    private DialogLauncher _dialogLauncher;
    private AudioManager _audioManager;
    private LevelsData _levelsData;

    public void Init(LevelsData levelsData, LevelStats stats)
    {
        _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        _levelsData = levelsData;
        SetDataScore(stats);
    }

    private void SetDataScore(LevelStats stats)
    {
        SetTextPraise(stats.Score);
        SetTextScore(stats.Score);
        SetStars(_levelsData.LevelConfig.Stars);
    }


    private void SetTextScore(int score)
    {
        _textScore.text = $"{score}";
    }

    private void SetStars(int countStars)
    {
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

    private void SetTextPraise(int score)
    {
        if (score > 1200)
        {
            _textPraise.text = "Perfect";
            return;
        }

        if (score > 500 && score < 1200)
        {
            _textPraise.text = "Good";
            return;
        }

        if (score > 0 && score < 500)
        {
            _textPraise.text = "Fine";
        }
    }

    public void Repeat()
    {
        _audioManager.PlayButtonClick();
        _dialogLauncher.ShowGameScreen();
        Destroy(gameObject);
    }

    public void LoadNextLevel()
    {
        _audioManager.PlayButtonClick();
        var nextLevel = _levelsData.LevelConfig.LevelIndex + 1;
        _levelsData.SetLevel(nextLevel);
        _dialogLauncher.ShowGameScreen();
    }

    public void BackLevelSelect()
    {
        _audioManager.PlayButtonClick();
        _dialogLauncher.ShowSelectLevel();
    }
}