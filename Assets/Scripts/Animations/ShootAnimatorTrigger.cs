using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class ShootAnimatorTrigger : MonoBehaviour
    {
        [SerializeField]
        private ShootComponent shootComponent;
        
        private Animator _animator;
        
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            shootComponent.OnShoot += SetShootTrigger;
        }

        private void OnDisable()
        {
            shootComponent.OnShoot -= SetShootTrigger;
        }
        
        private void SetShootTrigger()
        {
            _animator.SetTrigger(Shoot);
        }
    }
}