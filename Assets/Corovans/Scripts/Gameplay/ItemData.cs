using UnityEngine;


namespace Corovans.Scripts.Gameplay
{
    [CreateAssetMenu(menuName = "Data/Item", fileName = "SO_ItemData_ItemName")]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public int weight;
    }
}
