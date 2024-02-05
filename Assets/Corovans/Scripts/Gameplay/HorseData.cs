using UnityEngine;

namespace Corovans.Scripts.Gameplay
{
    [CreateAssetMenu(menuName = "Data/Horse", fileName = "SO_HorseData_HorseName")]
    public class HorseData : ScriptableObject
    {
        [field:SerializeField] public float SpeedModifier { get; private set; }
        [field:SerializeField] public int MaxWeight { get; private set; }
    }
}
