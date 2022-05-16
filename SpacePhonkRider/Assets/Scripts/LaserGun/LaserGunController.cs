namespace LaserGun
{
    using CustomInput;
    using UnityEngine;

    public class LaserGunController : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform ShootingPoint;
        [SerializeField] private float fireForce = 2000f;

        private Rigidbody2D bulletRigidbody;

        void Awake()
        {
            if (GetComponentInParent<PlayerInput>() != null)
                GetComponentInParent<PlayerInput>().OnFire += HandleFire;
            if (GetComponentInParent<EnemyAI>() != null)
                GetComponentInParent<EnemyAI>().OnFire += HandleFire;
        }

        private void HandleFire()
        {
            var spawnedProjectile = Instantiate(projectilePrefab, ShootingPoint.position, ShootingPoint.rotation);
            spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(spawnedProjectile.transform.up * fireForce);
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}