using UnityEngine;

namespace Corovans.Scripts.GameCamera
{
    public class CameraFollower : MonoBehaviour
    {
        [field:SerializeField] public Transform Target { get; private set; }

        private void Update()
        {
            var cameraTransform = transform;
            var position = cameraTransform.position;
            position = new Vector3(position.x, Target.position.y, position.z);
            cameraTransform.position = position;
        }
    }
}