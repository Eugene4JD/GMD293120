namespace DeathManager.DeathManagerTypes
{
    using HealthControl.HealthControllerType;
    using UnityEngine;

    public class HeroDeathManager : BaseDeathManager
    {
        private void Awake()
        {
            var healthController = GetComponent<HeroHealthController>();
            if (healthController == null) return;
            GetComponent<HeroHealthController>().OnDie += HandleShipDeath;
        }

        protected override void HandleShipDeath()
        {
            var obj = Instantiate(deathParticleSystemPrefab, transform.position, Quaternion.identity);
            Destroy(obj, 5f);
        }
    }
}