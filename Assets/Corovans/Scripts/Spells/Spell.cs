using UnityEngine;

namespace Corovans.Scripts.Spells
{
    public abstract class Spell : MonoBehaviour
    {
        [field:SerializeField] public int Cost { get; private set; }

        public abstract void UseSpell();
    }
}
