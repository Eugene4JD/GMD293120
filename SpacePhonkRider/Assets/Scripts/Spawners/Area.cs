namespace Spawners
{
    using UnityEngine;

    public class Area
    {
        [field: SerializeField] public float StartPosition { get; private set; }
        [field: SerializeField] public float EndPosition { get; private set; }

        public Area(float startPosition, float endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
    }
}