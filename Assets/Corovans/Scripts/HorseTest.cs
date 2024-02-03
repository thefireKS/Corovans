using UnityEngine;

namespace Corovans.Scripts
{
    public class HorseTest : MonoBehaviour
    {
        [SerializeField] private int horseLevel;
        [SerializeField] private int horseQuantity;

        private const int baseVes = 8;

        private int _load;
        
        void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                horseLevel = i;
                horseQuantity = horseLevel / 2;
                _load = CalculateLoad();
                Debug.Log($"Hlvl: {horseLevel}\nLoad: {_load}\nHq: {horseQuantity}");
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private int CalculateLoad()
        {
            if (horseLevel % 2 == 1)
            {
                return (baseVes * (horseQuantity + 1) * 2) - (horseQuantity - 4);
            }
            else
            {
                return (baseVes * (horseQuantity + 1)) - (horseQuantity - 4);
            }
        }
    }
}
