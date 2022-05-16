namespace Spawners
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class BaseSpawner : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> prefabsToSpawn;

        [SerializeField] protected float respawnTime = 1.0f;

        [SerializeField] private float minX, maxX;

        [SerializeField] private int numberOfSpawnAreas;

        [SerializeField] private float SpawnCoordinateY;

        [SerializeField] protected float[] weights;

        [SerializeField] private float destroyTime = 5f;


        [SerializeField] protected List<Area> areas;

        private Area previoslyUsedArea;

        protected void SpawnWeightedItem()
        {
            float value = Random.value;

            for (int i = 0; i < weights.Length; i++)
            {
                if (value < weights[i])
                {
                    DoSpawnAtNextPosition(prefabsToSpawn[i]);
                    return;
                }

                value -= weights[i];
            }

            Debug.LogError("Invalid weight configuration");
        }

        private void DoSpawnAtNextPosition(GameObject obj)
        {
            var genObj = Instantiate(obj);
            var nextArea = GetNextArea();
            genObj.transform.position =
                new Vector2(Random.Range(nextArea.StartPosition, nextArea.EndPosition), SpawnCoordinateY);
            Destroy(genObj, destroyTime);
        }


        protected void ResetSpawnWeights()
        {
            float TotalWeigt = 0;
            for (int i = 0; i < prefabsToSpawn.Count; i++)
            {
                weights[i] = prefabsToSpawn[i].GetComponent<WeightForSpawn>().GetWeight();
                TotalWeigt += weights[i];
            }

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = weights[i] / TotalWeigt;
            }
        }

        protected void ConstructAreas()
        {
            for (int i = 0; i < numberOfSpawnAreas; i++)
            {
                areas.Add(new Area(minX + (maxX - minX) / numberOfSpawnAreas * i,
                    minX + (maxX - minX) / numberOfSpawnAreas * i + 1));
            }
        }

        private Area GetNextArea()
        {
            var random = new System.Random();
            var dynamicAreasFree = new List<Area>(areas);
            if (previoslyUsedArea != null)
            {
                dynamicAreasFree.Remove(previoslyUsedArea);
                var index = random.Next(dynamicAreasFree.Count);
                previoslyUsedArea = dynamicAreasFree[index];
                return dynamicAreasFree[index];
            }
            else
            {
                var index = random.Next(dynamicAreasFree.Count);
                previoslyUsedArea = dynamicAreasFree[index];
                return dynamicAreasFree[index];
            }
        }
    }
}