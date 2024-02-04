using UnityEngine;

namespace Corovans.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnInterval = 2f;

        private Bounds _colliderBounds;

        private void Start()
        {
            // Получаем границы коллайдера
            Collider2D collider2D = GetComponent<Collider2D>();
            if (collider2D != null)
            {
                _colliderBounds = collider2D.bounds;
            }
            else
            {
                Debug.LogError("Collider2D component not found!");
            }

            // Вызываем метод SpawnObjects с заданным интервалом
            InvokeRepeating("SpawnObjects", 0f, spawnInterval);
        }

        private void SpawnObjects()
        {
            // Генерация случайных координат внутри границ коллайдера
            float randomX = Random.Range(_colliderBounds.min.x, _colliderBounds.max.x);
            float randomY = Random.Range(_colliderBounds.min.y, _colliderBounds.max.y);

            // Создание объекта в случайных координатах
            Instantiate(enemyPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity, transform);
        }
    }
}