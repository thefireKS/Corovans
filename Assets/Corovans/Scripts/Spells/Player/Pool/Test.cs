using System.Collections;

namespace Corovans.Scripts.Spells.Player.Pool
{
    public class Test : Spell
    {
        public override void UseSpell()
        {
            UnityEngine.Debug.Log("Test spell");
        }
    }
}
