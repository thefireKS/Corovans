using UnityEngine;

namespace Corovans.Scripts.Entities.Deffenders.Wagon
{
    public class WagonModel
    {
        private readonly float _maxHealth;
        private float _currentHealth;

        public float MaxHealth => _maxHealth;

        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = Mathf.Clamp(value, 0f, _maxHealth);
        }

        public WagonModel(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }
    }
}
