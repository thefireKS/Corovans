using System.Collections;
using System.Collections.Generic;
using Corovans.Scripts.Entities.Enemies;
using UnityEngine;

namespace Corovans.Scripts.Spells.Player.Pool.Entities
{
    public class Thunder : MonoBehaviour
    {
        private readonly List<EnemyBase> _enemies = new();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemies.Add(other.GetComponent<EnemyBase>());
            }
        }

        private void OnEnable()
        {
            StartCoroutine(KillAll());
        }

        private IEnumerator KillAll()
        {
            yield return new WaitForSeconds(0.3f);
            if (_enemies.Count > 0)
            {
                foreach (var enemy in _enemies)
                {
                    enemy.TakeDamage(99999);
                }
            }
            Destroy(gameObject);
        }
    }
}
