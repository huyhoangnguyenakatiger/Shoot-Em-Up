using System;
using UnityEngine;

namespace Shmup
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;
        Transform parent;
        public void SetParent(Transform parent) => this.parent = parent;
        public void SetSpeed(float speed) => this.speed = speed;
        public Action Callback;


        void Awake() => parent = this.transform;
        void Start()
        {
            if (muzzlePrefab != null)
            {
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = transform.forward;
                muzzleVFX.transform.SetParent(parent);
                DestroyParticleSystem(muzzleVFX);
            }
        }

        void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);
            Callback?.Invoke();
        }

        public void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.name);
            if (hitPrefab != null)
            {
                ContactPoint contact = other.contacts[0];
                var hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);
                DestroyParticleSystem(hitVFX);
            }
            Destroy(gameObject);
        }

        public void DestroyParticleSystem(GameObject vfx)
        {
            var ps = GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }
    }
}