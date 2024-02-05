using System.Collections;
using Corovans.Scripts.Entities.Enemies;
using UnityEngine;

namespace Corovans.Scripts.Entities.Defenders
{
    public class Defender : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform spawnProjectilePoint;

        
        private Transform _currentTarget;

        [SerializeField] private float timeBetweenAttacks;
        
        private bool _canAttack = true;

        private void LateUpdate()
        {
            EnemyBase closestEnemy = null;
            
            float currentDistanceToNearbyEnemies = Mathf.Infinity;
            
            foreach (var enemy in EnemyList.instance.Enemies)
            {
                if ((enemy.transform.position - transform.position).magnitude < currentDistanceToNearbyEnemies)
                {
                    currentDistanceToNearbyEnemies = (enemy.transform.position - transform.position).magnitude;
                    closestEnemy = enemy;
                }
            }

            _currentTarget = closestEnemy ? closestEnemy.transform : null;
            
            if (_currentTarget)
            {
                Vector3 directionToTarget = _currentTarget.position - transform.position;
                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        private void Update()
        {
            if (_currentTarget && _canAttack)
            {
                Instantiate(projectile, spawnProjectilePoint.position, spawnProjectilePoint.rotation);
                
                if (_canAttack)
                {
                    StartCoroutine(AttackCooldown());
                }
            }
        }
        
        private IEnumerator AttackCooldown()
        {
            _canAttack = false; // Запрещаем атаковать
            yield return new WaitForSeconds(timeBetweenAttacks); // Ждем заданное время
            _canAttack = true; // Разрешаем атаковать снова
        }
    }
}
