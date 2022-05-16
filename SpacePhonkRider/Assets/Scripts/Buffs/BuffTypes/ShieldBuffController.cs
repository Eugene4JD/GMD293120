namespace Buffs.BuffTypes
{
    using HealthControl.HealthControllerType;
    using UnityEngine;

    public class ShieldBuffController : BaseBuffController
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (heroObject.CompareTag(other.gameObject.tag) || bulletPrefab.CompareTag(other.gameObject.tag))
            {
                heroObject.GetComponentInChildren<ForceShieldHealthController>(true).ActivateShield();
                Destroy(gameObject);
            }
        }
    }
}