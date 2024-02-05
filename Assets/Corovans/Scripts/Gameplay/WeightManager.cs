using Corovans.Scripts.Gameplay.Wagon;
using UnityEngine;

namespace Corovans.Scripts.Gameplay
{
    public class WeightManager : MonoBehaviour
    {
        public static WeightManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public float CalculateModifier()
        {
            if (Inventory.Instance.CalculateCurrentLoad() > HorseManager.Instance.CurrentHorse.MaxWeight)
            {
                return Mathf.Clamp((float)HorseManager.Instance.CurrentHorse.MaxWeight/Inventory.Instance.CalculateCurrentLoad(),0.2f,1f);
            }
            else
            {
                return 1;
            }
        }
    }
}
