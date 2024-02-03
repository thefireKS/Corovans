using Corovans.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Corovans.Scripts.Entities.Defenders.Wagon
{
    public class WagonController : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        
        private WagonModel _model;

        private void Awake()
        {
            _model = new WagonModel(maxHealth: maxHealth);
        }
    
        public void TakeDamage(int damageAmount)
        {
            _model.CurrentHealth -= damageAmount;
            if (_model.CurrentHealth == 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Debug.Log("Wagon died");
        }
    }
}
