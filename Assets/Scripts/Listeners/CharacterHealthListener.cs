using Components;
using UnityEngine;

namespace Listeners
{
    public sealed class CharacterHealthListener : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent healthComponent;
        
        [SerializeField]
        private MoveComponent moveComponent;

        [SerializeField]
        private RotateComponent rotateComponent;

        [SerializeField]
        private ShootComponent shootComponent;

        private void OnEnable()
        {
            healthComponent.OnDeath += OnDeath;
        }

        private void OnDisable()
        {
            healthComponent.OnDeath -= OnDeath;
        }

        private void OnDeath()
        {
            moveComponent.enabled = false;
            rotateComponent.enabled = false;
            shootComponent.enabled = false;
            Destroy(gameObject, 3);
        }
    }
}