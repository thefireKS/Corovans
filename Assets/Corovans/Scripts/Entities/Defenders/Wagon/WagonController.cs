using System;
using Corovans.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Corovans.Scripts.Entities.Defenders.Wagon
{
    public class WagonController : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        
        public WagonModel Model { get; private set; }

        public event Action OnInitialized;

        private void Awake()
        {
            Model = new WagonModel(maxHealth: maxHealth);
        }

        private void Start()
        {
            OnInitialized?.Invoke();
        }

        public void TakeDamage(int damageAmount)
        {
            Model.CurrentHealth -= damageAmount;
            if (Model.CurrentHealth == 0)
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
