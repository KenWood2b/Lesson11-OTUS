using UnityEngine;

namespace Controllers
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera mainCamera;

        [SerializeField]
        private Transform moveTarget;
        
        [SerializeField]
        private Transform lookTarget;

        [SerializeField]
        private Vector3 offset = new (0, 10, -15);

        [SerializeField, Min(0.01f)]
        private float positionSmoothTime = 0.15f;
        
        [SerializeField, Min(0.01f)]
        private float rotationSmoothTime = 0.15f;
        
        private Vector3 _positionVelocity;
        
        private void LateUpdate()
        {
            Transform cam = mainCamera.transform;

            Vector3 nextPos = moveTarget.position + offset;
            cam.position = Vector3.SmoothDamp(cam.position, nextPos, ref _positionVelocity, positionSmoothTime);

            Vector3 viewDirection = (lookTarget.position - cam.position).normalized;
            
            Quaternion nextRotation = Quaternion.LookRotation(viewDirection, Vector3.up);
            cam.rotation = Quaternion.Slerp(cam.rotation, nextRotation, Time.deltaTime / rotationSmoothTime);
        }
    }
}