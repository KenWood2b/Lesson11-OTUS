using Components;
using Input_System;
using UnityEngine;

namespace Controllers
{
    public sealed class CharacterRotationController : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;

        [SerializeField]
        private InputSystem inputSystem;

        private RotateComponent _rotateComponent;

        private void Start()
        {
            _rotateComponent = character.GetComponent<RotateComponent>();
        }

        private void FixedUpdate()
        {
            _rotateComponent.RotationDirection =
                new Vector3(inputSystem.AimDirection.x, 0, inputSystem.AimDirection.y);
        }
    }
}