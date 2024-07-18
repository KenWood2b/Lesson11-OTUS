using Components;
using UnityEngine;

namespace Character
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField]
        private int damage = 1;
        
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"SPIKES ENTERED {other.gameObject.name}");
            HealthComponent healthComponent = other.gameObject.GetComponentInParent<HealthComponent>();
            
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }
}