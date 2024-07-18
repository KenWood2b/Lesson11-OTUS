using System;
using UnityEngine;

namespace Input_System
{
    public abstract class InputSystem : MonoBehaviour
    {
        public abstract Vector2 MoveDirection { get; protected set; }
        public abstract Vector2 AimDirection { get; protected set; }

        public abstract event Action OnFire;
    }
}