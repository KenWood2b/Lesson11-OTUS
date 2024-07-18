using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private Vector3 moveDirection;

        [SerializeField]
        private float moveSpeed;
        
        public Vector3 MoveDirection
        {
            get => moveDirection;
            set => moveDirection = value;
        }

        public bool IsMoving => MoveDirection != Vector3.zero;

        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnDisable()
        {
            Vector3 bodyVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(0, bodyVelocity.y, 0);
        }

        private void FixedUpdate()
        {
            Vector3 bodyVelocity = _rigidbody.velocity;
            Vector3 moveStep = moveDirection.normalized * moveSpeed;
            
            float speedY = bodyVelocity.y;
            float speedX = moveStep.x;
            float speedZ = moveStep.z;
            
            _rigidbody.velocity = new Vector3(speedX, speedY, speedZ);
        }
    }
}