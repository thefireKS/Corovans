using UnityEngine;

namespace Corovans.Scripts.Spells
{
    public abstract class Spell : MonoBehaviour
    {
        [field:SerializeField] public AudioClip PlaySound { get; private set; }
        [field:SerializeField] public string CardName { get; private set; }
        [field:SerializeField] public Sprite Card { get; private set; }
        [field:SerializeField] public int Cost { get; private set; }

        public abstract void UseSpell();
    }
}
