using PathCreation.Examples;
using UnityEngine;

namespace Corovans.Scripts
{
    public class PathObserver : MonoBehaviour
    {
        [SerializeField] private PathFollower povozka;

        private float distanceTravveled;
        private void Update()
        {
            distanceTravveled += povozka.speed * Time.deltaTime;
            var percentage = distanceTravveled / povozka.pathCreator.path.length;
            Debug.Log(percentage*100f);
        }
    }
}
