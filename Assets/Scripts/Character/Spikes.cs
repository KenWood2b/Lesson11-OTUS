using Components;
using UnityEngine;

namespace Character
{
    public sealed class Spikes : MonoBehaviour
    {
        [SerializeField]
        private int damage = 10;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"SPIKES ENTERED {other.name}");
            HealthComponent healthComponent = other.GetComponentInParent<HealthComponent>();
            
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }
}