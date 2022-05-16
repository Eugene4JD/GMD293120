namespace HealthControl
{
    using System;
    using LaserGun;
    using UnityEngine;

    public abstract class BaseHealthController : MonoBehaviour
    {
        [field: SerializeField] public int MaxHealth { get; private set; } = 8;
        [field: SerializeField] public int ShipCollisionDamage { get; set; }

        [SerializeField] protected GameObject BulletPrefab;

        public event Action OnHealthChanged = delegate { };
        public event Action OnDamageTaken =delegate {  };
        public event Action OnHeal = delegate {  };


        public int Health { get; set; }

        void Awake()
        {
            Health = MaxHealth;
        }

        private void OnWillRenderObject()
        {
            OnHealthChanged();
        }


        protected void DealDamageByIncomingCollider(Collider2D col)
        {
            if (col.gameObject.GetComponent<BaseBulletController>() != null)
            {
                TakeDamage(col.gameObject.GetComponent<BaseBulletController>().BulletDamage);
            }
            else if (col.gameObject.GetComponent<BaseHealthController>() != null)
            {
                TakeDamage(col.gameObject.GetComponent<BaseHealthController>().ShipCollisionDamage);
            }
        }

        private void TakeDamage(int damage)
        {
            OnDamageTaken();
            Health -= damage;
            OnHealthChanged();
            if (Health <= 0)
                Die();
        }

        public void Heal(int heal)
        {
            if (Health + heal > MaxHealth)
                Health = MaxHealth;
            else
                Health += heal;
            OnHealthChanged();
            OnHeal();
        }

        protected abstract void Die();
    }
}