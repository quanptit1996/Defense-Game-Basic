using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace LQ.DefenseBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private float spawnTime;
        [SerializeField] private Enemy[] _enemyPrefabs;
        [SerializeField] private Button btn_PlayGame;
        
        
        private PlayerController _curPlayer;

        private bool _isGameOver;

        private int _score;

        private void Awake()
        {
            if (Instance != null && Instance != this) 
            {
                Destroy(this.gameObject);
            }
 
            Instance = this;
          //  DontDestroyOnLoad( this.gameObject );
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        void Start()
        {
            if (IsComponentsNull()) return;

            GUIManager.Instance.ShowGameGUI(false);
            GUIManager.Instance.UpdateMainCoins();
            btn_PlayGame.onClick.AddListener(PlayGame);
        }

        void PlayGame()
        {
            if(IsComponentsNull()) return;
                
            ActivePlayer();
            GUIManager.Instance.ShowGameGUI(true);
            StartCoroutine(SpawnEnemy());
            GUIManager.Instance.UpdateGameplayCoins();
            AudioController.Instance.PlayBGMusic();
        }

        public void ActivePlayer()
        {
            if (IsComponentsNull()) return;

            if (_curPlayer)
            {
                Destroy(_curPlayer.gameObject);
            }

            var shopItems = ShopManager.Instance.items;
            if (shopItems == null || shopItems.Length <= 0) return;

            var newPlayerPrefab = shopItems[Pref.curPlayerId].playerPrefab;
            if (newPlayerPrefab)
                Instantiate(newPlayerPrefab, new Vector3(-7, 0, 0), Quaternion.identity);
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
                        Instantiate(enemyPrefabs, new Vector3(8, 2, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
        }

        public bool IsComponentsNull()
        {
            return GUIManager.Instance == null;
        }

        public void GameOver()
        {
            if(_isGameOver) return;
            _isGameOver = true;

            Pref.bestScore = _score;
            if(GUIManager.Instance._gameOverDialog) GUIManager.Instance._gameOverDialog.ShowHide(true);
        }
    }
}

