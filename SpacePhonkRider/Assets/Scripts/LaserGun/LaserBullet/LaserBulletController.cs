namespace LaserGun.LaserBullet
{
    using UnityEngine;

    public class LaserBulletController : BaseBulletController
    {
        void Start()
        {
            var flash = Instantiate(ShootEffect, transform.position, Quaternion.identity); //Spawn muzzle flash
            Destroy(gameObject, 5f);
            Destroy(flash, 5f);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(FiringShip.tag) && !col.gameObject.CompareTag(FiringShipBulletPrefab.tag))
            {
                var explosion = Instantiate(HitEffect, transform.position, Quaternion.identity);
                Destroy(explosion, 5f);
            }
        }
    }
}