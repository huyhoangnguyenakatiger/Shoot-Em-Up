using UnityEngine;

namespace Shmup
{
    public class HealthItem : Item
    {
        void OnTriggerEnter(Collider other)
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                other.GetComponent<Player>().AddHealth(50);
                Destroy(gameObject);
            }

        }
    }
}