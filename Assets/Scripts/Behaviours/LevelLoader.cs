using UnityEngine;
using Data;
using Helpers;

namespace Behaviours
{
    class LevelLoader : ILevelLoader
    {
        private GameObject _level;
        private LevelData _levelData;
        private LevelsBundle _levelsBundle;

        private int _levelIndex = 0;

        public LevelLoader()
        {
            _levelsBundle = Services.Instance.DatasBundle.ServicesObject.GetData<LevelsBundle>();
        }

        public void LoadLevelByIndex(int index)
        {
            LoadLevelVisuals(index);
        }
        public bool LoadNextLevel()
        {
            if (!IsLastLevel())
            {
                _levelIndex++;
                LoadLevelByIndex(_levelIndex);
                return true;
            }
            return false;
        }
        public void ResetLevels()
        {
            _levelIndex = 0;
        }
        public void ClearLevelFull()
        {
            if (!ReferenceEquals(_level, null))
            {
                GameObject.Destroy(_level.gameObject);
                _level = null;
                Services.Instance.Level.SetObject(null);
            }
        }
        public bool IsLastLevel()
        {
            return _levelsBundle.IsLastLevelByIndex(_levelIndex);
        }

        private void LoadLevelVisuals(int index)
        {
            _levelData = _levelsBundle.GetRandomLevelData();
            _level = GameObject.Instantiate(_levelData.LevelPrefab, _levelData.LevelPosition, Quaternion.identity);
            _level.transform.localPosition = _levelData.LevelPosition;
            _level.transform.localRotation = Quaternion.identity;
            Services.Instance.Level.SetObject(_level);
        }
    }
}
