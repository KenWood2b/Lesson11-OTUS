using System;
using Components;
using Input_System;
using UnityEngine;

namespace Controllers
{
    public sealed class CharacterShootController : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;

        [SerializeField]
        private InputSystem inputSystem;

        private ShootComponent _shootComponent;

        private void Start()
        {
            _shootComponent = character.GetComponent<ShootComponent>();
        }

        private void OnEnable()
        {
            inputSystem.OnFire += Fire;
        }

        private void OnDisable()
        {
            inputSystem.OnFire -= Fire;
        }

        private void Fire()
        {
            _shootComponent.Fire();
        }
    }
}