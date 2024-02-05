using UnityEngine;

namespace Corovans.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnInterval = 2f;

        private Camera _mainCamera;

        private void Start()
        {
            // Получаем ссылку на основную камеру
            _mainCamera = Camera.main;

            // Вызываем метод SpawnObjects с заданным интервалом
            InvokeRepeating("SpawnObjects", 0f, spawnInterval);
        }

        private void SpawnObjects()
        {
            // Получаем размеры противника
            Vector2 enemySize = enemyPrefab.GetComponent<Collider2D>().bounds.size;

            // Вычисляем границы видимой области камеры в мировых координатах
            float cameraHeight = 2f * _mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * _mainCamera.aspect;

            float maxX = _mainCamera.transform.position.x + cameraWidth / 2f;
            float minX = _mainCamera.transform.position.x - cameraWidth / 2f;
            float maxY = _mainCamera.transform.position.y + cameraHeight / 2f;
            float minY = _mainCamera.transform.position.y - cameraHeight / 2f;

            // Генерируем случайные координаты вне видимой области камеры
            float randomX = Random.Range(minX - cameraWidth / 2f - enemySize.x, maxX + cameraWidth / 2f + enemySize.x);
            float randomY = Random.Range(minY - cameraHeight / 2f - enemySize.y, maxY + cameraHeight / 2f + enemySize.y);

            // Создаем противника в случайных координатах
            Instantiate(enemyPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        }
    }
}