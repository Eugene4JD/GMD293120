namespace HealthControl.HealthControllerType
{
    using System;
    using UnityEngine;

    public class EnemyHealthController : BaseHealthController
    {
        public event Action OnDie = delegate { };

        protected override void Die()
        {
            OnDie();
            GameObject.Find("AlienSpawner").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            //Handling of collision damage
            if (!gameObject.CompareTag(col.gameObject.tag) && !BulletPrefab.CompareTag(col.gameObject.tag))
            {
                DealDamageByIncomingCollider(col);
            }
        }
    }
}