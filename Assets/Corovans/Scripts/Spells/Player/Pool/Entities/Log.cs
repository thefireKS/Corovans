using System;
using Corovans.Scripts.Entities.Enemies;
using UnityEngine;

namespace Corovans.Scripts.Spells.Player.Pool.Entities
{
    public class Log : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;

        private void Update()
        {
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x, position.y + Time.deltaTime * speed,
                position.z);
            transform1.position = position;
        }

        private void Awake()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyBase>().TakeDamage(9999999);
            }
        }
    }
}
