using Corovans.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Corovans.Scripts.Entities.Enemies
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        private int _health;

        private bool _isDying;

        private void Awake()
        {
            _health = maxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            if(_isDying) return;
            
            _health -= damageAmount;
            if (_health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            _isDying = true;
            Destroy(gameObject);
        }

        private void OnBecameVisible()
        {
            EnemyList.instance.AddToEnemiesList(this);
        }
        
        private void OnBecameInvisible()
        {
            EnemyList.instance.RemoveFromEnemiesList(this);
        }
    }
}
