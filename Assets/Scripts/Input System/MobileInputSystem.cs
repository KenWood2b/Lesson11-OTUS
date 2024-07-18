using System;
using UnityEngine;

namespace Input_System
{
    public sealed class MobileInputSystem : InputSystem
    {
        public override Vector2 MoveDirection { get; protected set; }
        public override Vector2 AimDirection { get; protected set; }
        
        public override event Action OnFire;

        private Vector2 _initialTouchPos;
        
        private void Update()
        {
            if (Input.touchCount <= 0)
            {
                MoveDirection = Vector2.zero;
                return;
            }
            
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch current = Input.GetTouch(i);

                if (current.phase == TouchPhase.Began)
                {
                    _initialTouchPos = current.position;
                }

                Vector2 direction = (current.position - _initialTouchPos).normalized;
                
                if (current.position.x <= Screen.width * 0.5f)
                {
                    MoveDirection = direction;
                    AimDirection = direction;
                }
                else
                {
                    MoveDirection = Vector2.zero;
                    AimDirection = direction;
                    OnFire?.Invoke();
                }
            }
        }
    }
}