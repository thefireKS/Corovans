using System.Collections.Generic;
using UnityEngine;

namespace Corovans.Scripts.Gameplay.Wagon
{
    public class Inventory : MonoBehaviour
    {
        public List<ItemData> items = new();
        
        public static Inventory Instance { get; private set; }

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

        public int CalculateCurrentLoad()
        {
            int currentLoad = 0;
            if (items.Count == 0) return currentLoad;
            foreach (var item in items)
            {
                currentLoad += item.weight;
            }

            return currentLoad;
        }
    }
}
