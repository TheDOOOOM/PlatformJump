using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private GameLevel _levelPrefab;
    [SerializeField] private int _jumpMaximum;
    [SerializeField] private int _colectbleItems;
    [SerializeField] private int _minimumScore;

    private int _stars;
    
    public int Stars => _stars;

    public GameLevel GetLevel()
    {
        return _levelPrefab;
    }

    public void SetStars(int jumps, int colectbleItems, int score)
    {
        if (jumps <= _jumpMaximum)
        {
            _stars++;
        }

        if (colectbleItems >= _colectbleItems)
        {
            _stars++;
        }

        if (_minimumScore > score)
        {
            _stars++;
        }
    }
}