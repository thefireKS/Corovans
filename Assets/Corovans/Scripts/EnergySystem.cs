using System;
using UnityEngine;

namespace Corovans.Scripts
{
    public class EnergySystem : MonoBehaviour
    {
        [field:SerializeField] public float MaxEnergy { get; private set; }

        public float CurrentEnergy
        {
            get => _currentEnergy;
            private set => _currentEnergy = Mathf.Clamp(value, 0f, MaxEnergy);
        }

        [SerializeField] private float rechargeSpeed;
        private float _currentEnergy;

        private void Update()
        {
            if (CurrentEnergy < MaxEnergy)
            {
                CurrentEnergy += rechargeSpeed * Time.deltaTime;
            }
        }
    }
}
