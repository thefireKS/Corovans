using Corovans.Scripts.Energy;
using UnityEngine;
using UnityEngine.UI;

namespace Corovans.Scripts
{
    public class EnergyBar : MonoBehaviour
    {
        [SerializeField] private EnergySystem energySystem;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.maxValue = energySystem.MaxEnergy;
        }

        private void Update()
        {
            slider.value = energySystem.CurrentEnergy;
        }
    }
}
