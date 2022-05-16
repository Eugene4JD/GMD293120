namespace HealthControl.HealthControllerType
{
    using UnityEngine;

    public class ForceShieldHealthController : BaseHealthController
    {
        private void Start()
        {
            OnDamageTaken += PlayDamageSound;
            DeactivateShield();
            Health = 0;
        }

        public void ActivateShield()
        {
            GameObject.Find("BuffSpawner").GetComponent<AudioSource>().Play();
            gameObject.SetActive(true);
            Health = MaxHealth;
        }

        private void DeactivateShield()
        {
            gameObject.SetActive(false);
        }


        protected override void Die()
        {
            DeactivateShield();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!gameObject.CompareTag(col.gameObject.tag) && !BulletPrefab.CompareTag(col.gameObject.tag))
                if (gameObject.GetComponent<ForceShieldHealthController>() != null && gameObject
                    .GetComponent<ForceShieldHealthController>().gameObject.activeInHierarchy)
                    DealDamageByIncomingCollider(col);
        }
        
        private void PlayDamageSound()
        {
            GetComponent<AudioSource>().Play();
        }
    }
}