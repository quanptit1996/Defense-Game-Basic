using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LQ.DefenseBasic
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float spawnTime;
        [SerializeField] private Enemy [] _enemyPrefabs;

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
            StartCoroutine(SpawnEnemy());
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
    }
}

