using UnityEngine;

namespace Corovans.Scripts
{
    public class Timer : MonoBehaviour
    {
        private float _targetTime;
        private float _currentTime;
        public bool IsEnded { get; private set; }
        public bool IsPaused { get; private set; }

        private void FixedUpdate()
        {
            if (IsEnded) return;
            
            if(IsPaused) return;
            
            _currentTime += Time.fixedDeltaTime;
            if (_currentTime >= _targetTime)
            {
                IsEnded = true;
            }
        }

        public void Pause()
        {
            IsPaused = true;
        }
        
        public void Go()
        {
            IsPaused = false;
        }

        public void Complete()
        {
            IsEnded = true;
        }

        public void Reset()
        {
            _currentTime = 0;
            IsPaused = true;
            IsEnded = false;
        }

        public void SetTargetTime(float newTargetTime)
        {
            _targetTime = newTargetTime;
        }
    }
}