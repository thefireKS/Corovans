using UnityEngine;

namespace Corovans.Scripts
{
    public class PathUI : MonoBehaviour
    {
        [SerializeField] private RectTransform pathImage;
        [SerializeField] private RectTransform pathMark;

        [SerializeField] private PathObserver pathObserver;

        private float _pathImageLength;
        
        private void Awake()
        {
            _pathImageLength = pathImage.rect.width;
        }

        private void Update()
        {
            var pathMarkTransform = pathMark.transform;
            var position = pathMarkTransform.position;
            position = new Vector3(-(_pathImageLength/2) + _pathImageLength * pathObserver.Percentage,
                0, 0);
            Debug.Log(position);
            pathMarkTransform.localPosition = position;
        }
    }
}
