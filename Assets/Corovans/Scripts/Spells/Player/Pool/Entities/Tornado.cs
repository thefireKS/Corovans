using System;
using System.Collections.Generic;
using Corovans.Scripts.Entities.Enemies;
using UnityEngine;

namespace Corovans.Scripts.Spells.Player.Pool.Entities
{
    public class Tornado : MonoBehaviour
    {
        private readonly List<EnemyBase> _enemies = new();
        [SerializeField] private float attractionSpeed;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemies.Add(other.GetComponent<EnemyBase>());
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemies.Remove(other.GetComponent<EnemyBase>());
            }
        }

        private void Update()
        {
            
            foreach (var enemy in _enemies)
            {
                AttractEnemy(enemy);
            }
        }
        
        private void AttractEnemy(EnemyBase enemy)
        {
            var enemyPosition = enemy.transform.position;
            var tornadoPosition = transform.position;
            var direction = tornadoPosition - enemyPosition;
            var distance = direction.magnitude;

            // Изменяем позицию врага постепенно
            enemyPosition = Vector2.Lerp(
                enemyPosition,
                tornadoPosition,
                Time.deltaTime * attractionSpeed / distance
            );
            enemy.transform.position = enemyPosition;
        }
    }
}
