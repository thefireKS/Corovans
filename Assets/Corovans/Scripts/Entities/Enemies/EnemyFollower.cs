using System.Collections;
using Corovans.Scripts.Entities.Defenders.Wagon;
using UnityEngine;

namespace Corovans.Scripts.Entities.Enemies
{
    public class EnemyFollower : MonoBehaviour
    {
        private Transform _target;
        private bool _isAttacking;

        private WagonController _wagonController;

        [SerializeField] private float distanceToAttack;
        [SerializeField] private float restDuration;
        private float _timeSinceLastAttack;

        [SerializeField] private int damage;

        private Rigidbody2D _rigidbody2D;

        [SerializeField] private float speed;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;

            _wagonController = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WagonController>();
        }

        private void Update()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _target.position);

            if (!_isAttacking)
            {
                if (distanceToPlayer <= distanceToAttack)
                {
                    StartCoroutine(AttackCoroutine());
                }
                else
                {
                    var direction = (_target.position - transform.position).normalized;
                    _rigidbody2D.velocity = direction * speed;
                }
            }
        }

        private IEnumerator AttackCoroutine()
        {
            _isAttacking = true;

            Debug.Log("Attack!!!");
            Attack();
            
            // Противник останавливается после атаки
            _rigidbody2D.velocity = Vector2.zero;

            // Здесь можно добавить логику атаки, например, вызов метода нанесения урона игроку

            yield return new WaitForSeconds(restDuration);

            _isAttacking = false;

            // Противник может снова пускаться в погоню после отдыха
        }

        private void Attack()
        {
            _wagonController.TakeDamage(damageAmount: damage);
        }
    }
}
