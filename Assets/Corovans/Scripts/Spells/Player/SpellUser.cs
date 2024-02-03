using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Corovans.Scripts.Spells.Player
{
    public class SpellUser : MonoBehaviour
    {
        private PlayerControls _playerControls;
        
        [SerializeField] private Spell spells;

        private void Awake()
        {
            _playerControls = new();
            _playerControls.Enable();
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
            spells.UseSpell();
        }
    }
}
