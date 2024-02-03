using UnityEngine;

namespace Corovans.Scripts.Spells
{
    public abstract class Spell : MonoBehaviour
    {
        [SerializeField] private int cost;

        public abstract void UseSpell();
    }
}
