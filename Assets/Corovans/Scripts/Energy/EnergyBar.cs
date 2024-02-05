using Corovans.Scripts.Energy;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Corovans.Scripts
{
    public class EnergyBar : MonoBehaviour
    {
        [FormerlySerializedAs("energySystem")] [SerializeField] private EnergyManager energyManager;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.maxValue = energyManager.MaxEnergy;
        }

        private void Update()
        {
            slider.value = energyManager.CurrentEnergy;
        }
    }
}
