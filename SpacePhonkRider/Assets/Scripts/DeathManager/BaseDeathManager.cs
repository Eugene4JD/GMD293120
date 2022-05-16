namespace DeathManager
{
    using UnityEngine;
    public abstract class BaseDeathManager : MonoBehaviour {
        
        [SerializeField] protected GameObject deathParticleSystemPrefab;
        protected abstract void HandleShipDeath();
    }
}