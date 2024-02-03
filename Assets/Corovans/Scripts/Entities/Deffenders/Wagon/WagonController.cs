using Corovans.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Corovans.Scripts.Entities.Deffenders.Wagon
{
    public class WagonController : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        
        private WagonModel _model;

        private void Awake()
        {
            // Задаем максимальное здоровье при создании повозки
            _model = new WagonModel(maxHealth: maxHealth); // Замените значение на ваше
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
