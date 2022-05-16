namespace Spawners
{
    using UnityEngine;

    public class WeightForSpawn : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float MinWeight;
        [SerializeField] [Range(0, 1)] private float MaxWeight;


        public float GetWeight()
        {
            return Random.Range(MinWeight, MaxWeight);
        }

    }
}