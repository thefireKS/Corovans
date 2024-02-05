using Corovans.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Corovans.Scripts.Energy
{
    [ExecuteInEditMode]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int damage;

        private void Update()
        {
            if (Application.isPlaying)
            {
                transform.position += transform.right * (speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<IDamageable>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
