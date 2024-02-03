using System;
using Corovans.Scripts.Entities.Defenders.Wagon;
using UnityEngine;
using UnityEngine.UI;

namespace Corovans.Scripts
{
    public class WagonHealthBar : MonoBehaviour
    {
        [SerializeField] private WagonController wagon;
        [SerializeField] private Slider slider;

        private void OnEnable()
        {
            wagon.OnInitialized += Subscribe;
        }
        
        private void OnDisable()
        {
            wagon.OnInitialized -= Subscribe;
        }

        private void Subscribe()
        {
            slider.maxValue = wagon.Model.MaxHealth;
        }

        private void Update()
        {
            slider.value = wagon.Model.CurrentHealth;
        }
    }
}
