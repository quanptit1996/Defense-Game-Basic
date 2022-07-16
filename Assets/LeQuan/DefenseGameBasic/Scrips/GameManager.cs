using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LQ.DefenseBasic
{
    public class GameManager : MonoBehaviour,IComponentChecking
    {
        public GUIManager guiManager;
        
        [SerializeField] private float spawnTime;
        [SerializeField] private Enemy [] _enemyPrefabs;
        [SerializeField] private Button btn_PlayGame;
        

        private bool _isGameOver;

        private int _score;

        public int Score
        {
            get => _score;
            set => _score = value;
        }
        // Start is called before the first frame update
        void Start()
        {
            if(IsComponentsNull()) return;
            
            guiManager.ShowGameGUI(false);
            guiManager.UpdateMainCoins();
            btn_PlayGame.onClick.AddListener(PlayGame);
        }

        void PlayGame()
        {
            guiManager.ShowGameGUI(true);
            StartCoroutine(SpawnEnemy());
            guiManager.UpdateGameplayCoins();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        IEnumerator SpawnEnemy()
        {
            while (!_isGameOver)
            {
                if (_enemyPrefabs != null)
                {
                    int randomEnemy = Random.Range(0, _enemyPrefabs.Length);
                    Enemy enemyPrefabs = _enemyPrefabs[randomEnemy];
                    if (enemyPrefabs)
                    {
                        Instantiate(enemyPrefabs, new Vector3(8, 0, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
        }

        public bool IsComponentsNull()
        {
            return guiManager == null;
        }

        public void GameOver()
        {
            if(_isGameOver) return;
            _isGameOver = false;

            Pref.bestScore = _score;
            if(guiManager._gameOverDialog) guiManager._gameOverDialog.ShowHide(true);
        }
    }
}

