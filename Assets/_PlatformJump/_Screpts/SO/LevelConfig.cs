using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private GameLevel _levelPrefab;
    [SerializeField] private int _jumpMaximum;
    [SerializeField] private int _maximumSwitch;
    [SerializeField] private int _minimumScore;
    [SerializeField] private int _stars;
    [SerializeField] private int _levelIndex;

    public int Stars => _stars;
    public int LevelIndex => _levelIndex;
    public GameLevel GameLevel => _levelPrefab;

    public void SetStars(int jumps, int switchMaximum, int score)
    {
        if (_stars >= 3)
        {
            return;
        }

        if (jumps <= _jumpMaximum)
        {
            _stars++;
        }

        if (switchMaximum >= _maximumSwitch)
        {
            _stars++;
        }

        if (_minimumScore > score)
        {
            _stars++;
        }
    }
}