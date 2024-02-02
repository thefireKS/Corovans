using System.Collections;
using UnityEngine;

namespace Corovans.Scripts
{
    public class Defender : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;

        
        private Transform _currentTarget;

        [SerializeField] private float timeBetweenAttacks;
        
        private bool canAttack = true;

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
            if (_currentTarget && canAttack)
            {
                Projectile currentProjectile = Instantiate(projectile, transform.position, transform.rotation)
                    .GetComponent<Projectile>();
                
                if (canAttack)
                {
                    StartCoroutine(AttackCooldown());
                }
            }
        }
        
        private IEnumerator AttackCooldown()
        {
            canAttack = false; // Запрещаем атаковать
            yield return new WaitForSeconds(timeBetweenAttacks); // Ждем заданное время
            canAttack = true; // Разрешаем атаковать снова
        }
    }
}
