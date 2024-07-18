using Components;
using Input_System;
using UnityEngine;

namespace Controllers
{
    public sealed class CharacterMoveController : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;

        [SerializeField]
        private InputSystem inputSystem;

        private MoveComponent _moveComponent;

        private void Start()
        {
            _moveComponent = character.GetComponent<MoveComponent>();
        }

        private void FixedUpdate()
        {
            _moveComponent.MoveDirection = new Vector3(inputSystem.MoveDirection.x, 0, 
                inputSystem.MoveDirection.y);
        }
    }
}