namespace CustomInput
{
    using System;
    using System.Collections;
    using UnityEngine;


    public class EnemyAI : BaseInput
    {
        [SerializeField] private float ShootingDelay = 1f;

        public event Action OnFire = delegate { };

        void Start()
        {
            Vertical = -1;
            StartCoroutine(AutoFireCoroutine());
        }

        IEnumerator AutoFireCoroutine()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1);
                OnFire();
                yield return new WaitForSeconds(ShootingDelay);
            }
        }
    }
}