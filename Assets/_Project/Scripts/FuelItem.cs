using UnityEngine;

namespace Shmup
{
    public class FuelItem : Item
    {
        void OnTriggerEnter(Collider other)
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                other.GetComponent<Player>().AddFuel(10);
                Destroy(gameObject);
            }

        }
    }
}