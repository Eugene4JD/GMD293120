namespace LaserGun
{
    using UnityEngine;
    public abstract class BaseBulletController : MonoBehaviour
    {
        [field: SerializeField] protected GameObject ShootEffect { get; set; }
        
        [field: SerializeField] protected GameObject HitEffect { get; set; }
        
        [field: SerializeField] protected GameObject FiringShip { get; set; }

        [field: SerializeField] protected GameObject FiringShipBulletPrefab { get; set; }
        
        [SerializeField] public int BulletDamage = 40;
    }
}