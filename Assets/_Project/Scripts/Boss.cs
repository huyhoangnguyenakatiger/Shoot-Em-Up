using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shmup
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] float maxHealth = 100f;
        [SerializeField] GameObject explosionPrefab;
        float health;

        Collider bossCollider;

        public BossStage bossStage;

        public event Action OnHealthChanged;

        void Awake()
        {
            bossCollider = GetComponent<Collider>();
            bossStage = GetComponentInChildren<BossStage>();
        }

        void Start()
        {
            health = maxHealth;
            bossCollider.enabled = true;
        }

        public float GetHealthNormalized() => health / maxHealth;

        void OnCollisionEnter(Collision other)
        {
            health -= 10;
            OnHealthChanged?.Invoke();
            if (health <= 0)
            {
                BossDefeated();
            }
        }

        void BossDefeated()
        {
            GameManager.Instance.AddScore(100);
            Debug.Log("Boss defeated!");
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}