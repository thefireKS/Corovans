using System.Collections;
using Corovans.Scripts.Entities.Defenders.Wagon;
using UnityEngine;

namespace Corovans.Scripts.Entities.Enemies
{
    public class EnemyFollower : MonoBehaviour
    {
        private Animator _animator;
        
        private Transform _target;
        
        private bool _isAttacking;
        private bool _isWalk;
        private bool _isResting;

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
            _animator = GetComponent<Animator>();

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
                    _isWalk = false;
                    _animator.SetBool("IsWalking", _isWalk);
                }
                else
                {
                    var direction = (_target.position - transform.position).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    // Проверяем, есть ли коллизии перед объектом
                    if (!HasCollisionAhead())
                    {
                        // Если нет коллизий, перемещаем объект с использованием Translate
                        transform.Translate(Vector2.right * (speed * Time.deltaTime));
                        _isWalk = true;
                        _animator.SetBool("IsWalking", _isWalk);
                    }
                }
            }
        }

        private IEnumerator AttackCoroutine()
        {
            _isAttacking = true;
            _animator.SetBool("IsAttacking", _isAttacking);
            
            
            Attack();
            yield return new WaitForSeconds(0.625f);
            // Противник останавливается после атаки

            // Здесь можно добавить логику атаки, например, вызов метода нанесения урона игроку

            yield return StartCoroutine(AttackRest());

            _isAttacking = false;
            _animator.SetBool("IsAttacking", _isAttacking);

            // Противник может снова пускаться в погоню после отдыха
        }
        
        private IEnumerator AttackRest()
        {
            _isResting = true;
            _animator.SetBool("IsResting", _isResting);
            _rigidbody2D.simulated = false;

            yield return new WaitForSeconds(restDuration);
            
            _rigidbody2D.simulated = true;
            _isResting = false;
            _animator.SetBool("IsResting", _isResting);
        }

        private void Attack()
        {
            _wagonController.TakeDamage(damageAmount: damage);
        }
        
        private bool HasCollisionAhead()
        {
            // Определяем, есть ли коллизии перед объектом
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.5f);
            // Если есть коллизии, возвращаем true, иначе false
            return hit.collider != null;
        }
    }
}
