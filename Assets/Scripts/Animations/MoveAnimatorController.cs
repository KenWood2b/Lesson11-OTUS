using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class MoveAnimatorController : MonoBehaviour
    {
        [SerializeField]
        private MoveComponent moveComponent;
        
        private Animator _animator;
        
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(IsMoving, moveComponent.IsMoving);
        }
    }
}