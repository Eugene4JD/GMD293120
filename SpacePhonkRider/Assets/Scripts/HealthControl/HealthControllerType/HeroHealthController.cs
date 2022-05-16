namespace HealthControl.HealthControllerType
{
    using System;
    using UnityEngine;

    public class HeroHealthController : BaseHealthController
    {
        public event Action OnDie = delegate { };

        private void Start()
        {
            OnDamageTaken += PlayDamageSound;
            OnHeal += PlayHealSound;
        }

        protected override void Die()
        {
            OnDie();
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            //Handling of collision damage
            if (!gameObject.CompareTag(col.gameObject.tag) && !BulletPrefab.CompareTag(col.gameObject.tag))
            {
                if (gameObject.GetComponentInChildren<ForceShieldHealthController>() == null)
                {
                    DealDamageByIncomingCollider(col);
                }
                else
                {
                    if (!gameObject.GetComponentInChildren<ForceShieldHealthController>().gameObject.activeInHierarchy)
                    {
                        DealDamageByIncomingCollider(col);
                    }
                }
            }
        }

        private void PlayDamageSound()
        {
            GetComponent<AudioSource>().Play();
        }

        private void PlayHealSound()
        {
            GameObject.Find("BuffSpawner").GetComponent<AudioSource>().Play();
        }
    }
}