using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float distanceToTarget;

    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(distanceToTarget >= (_target.position - transform.position).magnitude) return;
        var direction = (_target.position - transform.position).normalized;
        _rigidbody2D.velocity = direction * speed;
    }
}
