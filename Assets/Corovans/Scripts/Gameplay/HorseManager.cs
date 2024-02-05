using System;
using UnityEngine;

namespace Corovans.Scripts.Gameplay
{
    public class HorseManager : MonoBehaviour
    {
        public static HorseManager Instance { get; private set; }
        
        [field:SerializeField] public HorseData CurrentHorse { get; private set; }

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
    }
}
