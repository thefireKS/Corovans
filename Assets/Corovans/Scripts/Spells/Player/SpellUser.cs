using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Corovans.Scripts.Spells.Player
{
    public class SpellUser : MonoBehaviour
    {
        private EnergySystem _energySystem;
        
        private PlayerControls _playerControls;
        
        private Queue<Spell> _randomSpellQueue;
        private Spell _currentSpell;
        
        [SerializeField] private Spell[] spells;
        
        private void ShuffleSpellArray()
        {
            _randomSpellQueue = new Queue<Spell>();
            List<Spell> spellList = new List<Spell>(spells);
            
            System.Random random = new System.Random();
            int n = spellList.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (spellList[k], spellList[n]) = (spellList[n], spellList[k]);
            }
            
            foreach (var spell in spellList)
            {
                _randomSpellQueue.Enqueue(spell);
            }
        }

        private void Awake()
        {
            _playerControls = new();
            _playerControls.Enable();

            _energySystem = FindObjectOfType<EnergySystem>();
            
            ShuffleSpellArray();
            _currentSpell = _randomSpellQueue.Dequeue();
        }

        private void OnEnable()
        {
            _playerControls.Gameplay.UseSpell.started += UseCurrentSpell;
        }
        
        private void OnDisable()
        {
            _playerControls.Gameplay.UseSpell.started -= UseCurrentSpell;
        }

        private void UseCurrentSpell(InputAction.CallbackContext callbackContext)
        {
            if(_currentSpell.Cost > _energySystem.CurrentEnergy) return;
            _currentSpell.UseSpell();
            
            if (_randomSpellQueue.Count == 0)
            {
                ShuffleSpellArray();
            }
            
            _currentSpell = _randomSpellQueue.Dequeue();
        }
    }
}
