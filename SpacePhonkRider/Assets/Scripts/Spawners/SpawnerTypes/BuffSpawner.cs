namespace Spawners.SpawnerTypes
{
    using System.Collections.Generic;
    using Score;
    using UnityEngine;
    
    public class BuffSpawner : BaseSpawner
    {
        private ScoreManager scoreManager;

        private void Awake()
        {
            weights = new float[prefabsToSpawn.Count];
        }

        private void Start()
        {
            areas = new List<Area>();
            ConstructAreas();
            ResetSpawnWeights();
            scoreManager = GameObject.Find("PointsUI").GetComponent<ScoreManager>();
            scoreManager.SpawnBuff += SpawnWeightedItem;
        }
    }
}