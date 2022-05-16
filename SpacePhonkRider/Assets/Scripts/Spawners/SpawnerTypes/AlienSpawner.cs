namespace Spawners.SpawnerTypes
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Score;


    public class AlienSpawner : BaseSpawner
    {
        private ScoreManager scoreManager;

        [SerializeField] private float minSpawnTime;

        private float difficultyMultiplier;

        private void Awake()
        {
            weights = new float[prefabsToSpawn.Count];
            difficultyMultiplier = (respawnTime - minSpawnTime) / 100;
        }

        private void Start()
        {
            areas = new List<Area>();
            scoreManager = GameObject.Find("PointsUI").GetComponent<ScoreManager>();
            scoreManager.DifficultyUpgrade += UpgradeDifficulty;
            ConstructAreas();
            ResetSpawnWeights();
            StartCoroutine(AlienWave());
        }

        private IEnumerator AlienWave()
        {
            while (true)
            {
                yield return new WaitForSeconds(respawnTime);
                SpawnWeightedItem();
            }
        }

        private void UpgradeDifficulty()
        {
            if (respawnTime > minSpawnTime)
            {
                respawnTime -= difficultyMultiplier;
            }
        }
    }
}