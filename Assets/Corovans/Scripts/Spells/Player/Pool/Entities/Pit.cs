using System.Collections;
using Corovans.Scripts.Entities.Enemies;
using UnityEngine;

namespace Corovans.Scripts.Spells.Player.Pool.Entities
{
    public class Pit : MonoBehaviour
    {
        [SerializeField] private float fallDuration = 2f;
        [SerializeField] private float minScaleFactor = 0.2f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                EnemyBase enemy = other.GetComponent<EnemyBase>();
                if (enemy != null)
                {
                    StartCoroutine(FreezeEnemy(enemy));
                }
            }
        }

        private IEnumerator FreezeEnemy(EnemyBase enemy)
        {
            // Замораживаем врага на некоторое время
            enemy.GetComponent<Rigidbody2D>().simulated = false;

            // Ждем freezeDuration секунд
            float elapsedTime = 0f;

            var initScale = enemy.transform.localScale;
            
            while (elapsedTime < fallDuration)
            {
                // Интерполируем размер врага между начальным и минимальным масштабом
                float scaleFactor = Mathf.Lerp(1f, minScaleFactor, elapsedTime / fallDuration);
                enemy.transform.localScale = initScale*scaleFactor;

                // Увеличиваем прошедшее время
                elapsedTime += Time.deltaTime;

                // Ждем один кадр
                yield return null;
            }

            // Наносим урон врагу по истечении времени
            enemy.TakeDamage(9999999);
        }
    }
}
