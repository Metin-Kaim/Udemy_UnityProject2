using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstract.Utilities;
using UdemyProject2.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : SingletonMonoBehaviourObj<GameManager>
    {
        [SerializeField] LevelDifficultyData[] _levelDifficultyDatas;

        public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];

        int _difficultyIndex;
        public int DifficultyIndex
        {
            get => _difficultyIndex;
            set
            {
                if(_difficultyIndex < 0 || _difficultyIndex > _levelDifficultyDatas.Length)
                {
                    LoadScene("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            }
        }

        public event System.Action OnGameStop;

        private void Awake()
        {
            SingletonThisObj(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;

            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
            Time.timeScale = 1f;
        }

        public void ExitGame()
        {
            Debug.Log("Exit on clicked");
            Application.Quit();
        }
    }
}
