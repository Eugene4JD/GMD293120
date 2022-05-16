namespace Spawners.SpawnerTypes
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlanetSpawner : BaseSpawner
    {
        private void Awake()
        {
            weights = new float[prefabsToSpawn.Count];
        }

        private void Start()
        {
            areas = new List<Area>();
            ConstructAreas();
            ResetSpawnWeights();
            StartCoroutine(PlanetWave());
        }

        private IEnumerator PlanetWave()
        {
            while (true)
            {
                yield return new WaitForSeconds(respawnTime);
                SpawnWeightedItem();
            }
        }
    }
}