using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "LevelData")]
public class LevelsData : ScriptableObject
{
    [SerializeField] private List<LevelConfig> _levelsConfigs;
    [SerializeField] private LevelConfig _defaultConfig;

    private LevelConfig _activeLevel;

    public void SetLevel(int index)
    {
        _activeLevel = _levelsConfigs[index];
    }

    public LevelConfig GetLevelConfig()
    {
        if (_activeLevel == null)
        {
            return _defaultConfig;
        }

        return _activeLevel;
    }
}