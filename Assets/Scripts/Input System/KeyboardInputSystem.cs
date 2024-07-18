using System;
using UnityEngine;

namespace Input_System
{
    public sealed class KeyboardInputSystem : InputSystem
    {
        public override Vector2 MoveDirection { get; protected set; }
        public override Vector2 AimDirection { get; protected set; }
        
        public override event Action OnFire;

        [SerializeField]
        private Transform characterSkeleton;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if (TryGetAimDirection(out Vector2 aimDirection))
            {
                AimDirection = aimDirection;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }
        }

        private bool TryGetAimDirection(out Vector2 aimDirection)
        {
            Plane plane = new(Vector3.up, characterSkeleton.position);

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float enter))
            {
                Vector3 direction = (ray.GetPoint(enter) - characterSkeleton.position).normalized;
                aimDirection = new Vector2(direction.x, direction.z);
                
                return true;
            }

            aimDirection = Vector2.zero;
            return false;
        }
    }
}