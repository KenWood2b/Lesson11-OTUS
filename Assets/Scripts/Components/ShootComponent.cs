using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    public sealed class ShootComponent : MonoBehaviour
    {
        public event Action OnShoot;
        
        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private float bulletForce = 10;

        [SerializeField]
        private float delay = 1;

        [SerializeField]
        private ForceMode forceMode;

        private Coroutine _fireRoutine;

        private void OnDisable()
        {
            if (_fireRoutine != null)
            {
                StopCoroutine(_fireRoutine);
                _fireRoutine = null;
            }
        }

        public void Fire()
        {
            if (!enabled)
                return;

            if (_fireRoutine == null)
                _fireRoutine = StartCoroutine(FireRoutine());
        }

        private IEnumerator FireRoutine()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Vector3 force = firePoint.forward * bulletForce;
            bullet.GetComponent<Rigidbody>().AddForce(force, forceMode);
                
            OnShoot?.Invoke();

            yield return new WaitForSeconds(delay);

            _fireRoutine = null;
        }
    }
}