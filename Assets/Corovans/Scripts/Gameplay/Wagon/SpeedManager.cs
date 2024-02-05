using PathCreation.Examples;
using UnityEngine;

namespace Corovans.Scripts.Gameplay.Wagon
{
    public class SpeedManager : MonoBehaviour
    {
        [SerializeField] private PathFollower wagonFollower;

        [SerializeField] private float targetSpeed;

        private void Awake()
        {
            wagonFollower.speed =
                targetSpeed; // * HorseManager.Instance.CurrentHorse.SpeedModifier * WeightManager.Instance.CalculateModifier();
        }
    }
}
