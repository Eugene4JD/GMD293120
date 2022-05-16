namespace Buffs
{
    using UnityEngine;

    public abstract class BaseBuffController : MonoBehaviour
    {
        [field: SerializeField] public int BuffValue { get; private set; } = 1;

        [field: SerializeField] public int BuffDropSpeed { get; set; } = 2;

        protected GameObject heroObject;
        [SerializeField] protected GameObject bulletPrefab;

        private void Start()
        {
            heroObject = GameObject.Find("SpaceShip");
        }

        void Update()
        {
            var temp = transform.position;
            temp.y -= BuffDropSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }
}