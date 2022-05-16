namespace DeathManager.DeathManagerTypes
{
    using Score;
    using HealthControl.HealthControllerType;
    using UnityEngine;

    public class EnemyDeathManager : BaseDeathManager
    {
        [SerializeField] private int enemyPointWeight;
        
        private void Awake()
        {
            var healthController = GetComponent<EnemyHealthController>();
            if (healthController == null) return;
            healthController.OnDie += HandleShipDeath;
            healthController.OnDie += HandleDeathPoints;
        }

        protected override void HandleShipDeath()
        {
            var obj = Instantiate(deathParticleSystemPrefab, transform.position, Quaternion.identity);
            Destroy(obj, 5f);
        }

        private void HandleDeathPoints()
        {
            GameObject.Find("PointsUI").GetComponent<ScoreManager>().AddEnemyPoints(enemyPointWeight);
        }
    }
}