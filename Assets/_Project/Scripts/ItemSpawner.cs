using System.Collections.Generic;
using MEC;
using UnityEngine;
using Utilities;
namespace Shmup
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] float spawnRadius = 3f;
        private CoroutineHandle spawnCoroutine;
        void Start() => spawnCoroutine = Timing.RunCoroutine(SpawnItems());

        IEnumerator<float> SpawnItems()
        {

            while (true)
            {
                yield return Timing.WaitForSeconds(spawnInterval);
                var item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
                item.transform.position = (transform.position + Random.insideUnitSphere).With(z: 0) * spawnRadius;
            }
        }

        void OnDestroy()
        {
            Timing.KillCoroutines(spawnCoroutine); // Sử dụng CoroutineHandle để hủy
        }
    }
}