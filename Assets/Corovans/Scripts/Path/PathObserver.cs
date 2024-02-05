using PathCreation.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corovans.Scripts
{
    public class PathObserver : MonoBehaviour
    {
        [SerializeField] private PathFollower povozka;

        private float _distanceTraveled;
        public float Percentage { get; private set; }
        private void Update()
        {
            _distanceTraveled += povozka.speed * Time.deltaTime;
            Percentage = _distanceTraveled / povozka.pathCreator.path.length;
            
            if(Percentage < 1) return;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
