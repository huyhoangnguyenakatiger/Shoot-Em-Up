using UnityEngine;

namespace Shmup
{

    [CreateAssetMenu(fileName = "EnemyType", menuName = "Shmup/EnemyType")]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}