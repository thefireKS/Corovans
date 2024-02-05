using System.Collections.Generic;
using Corovans.Scripts.Energy;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Corovans.Scripts.Spells.Player
{
    public class SpellUser : MonoBehaviour
    {
        [SerializeField] private Image cardDisplay;
        [SerializeField] private TextMeshProUGUI cardNameText;
        
        private EnergyManager _energyManager;
        
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

            _energyManager = FindObjectOfType<EnergyManager>();
            
            ShuffleSpellArray();
            _currentSpell = _randomSpellQueue.Dequeue();
            cardDisplay.sprite = _currentSpell.Card;
            cardNameText.text = _currentSpell.CardName;
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
            if(Time.timeScale == 0) return;
            
            if(_currentSpell.Cost > _energyManager.CurrentEnergy) return;
            
            _currentSpell.UseSpell();
            AudioSource.PlayClipAtPoint(_currentSpell.PlaySound, transform.position);
            _energyManager.ConsumeEnergy(_currentSpell.Cost);
            
            if (_randomSpellQueue.Count == 0)
            {
                ShuffleSpellArray();
            }
            
            _currentSpell = _randomSpellQueue.Dequeue();
            cardDisplay.sprite = _currentSpell.Card;
            cardNameText.text = _currentSpell.CardName;
        }
    }
}
