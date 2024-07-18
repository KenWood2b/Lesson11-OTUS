using UnityEngine;

namespace Animations.VFX
{
    public sealed class ShootWeaponVFXAnimationEvent : MonoBehaviour
    {
        [SerializeField]
        private AnimationEventListener animationEventListener;
        
        [SerializeField]
        private ParticleSystem vfx;

        private const string FireEvent = "fire_event";

        private void OnEnable()
        {
            animationEventListener.OnMessageReceived += PlayShootVFX;
        }

        private void OnDisable()
        {
            animationEventListener.OnMessageReceived -= PlayShootVFX;
        }

        private void PlayShootVFX(string message)
        {
            if (string.Equals(message, FireEvent))
            {
                vfx.Play(true);
            }
        }
    }
}