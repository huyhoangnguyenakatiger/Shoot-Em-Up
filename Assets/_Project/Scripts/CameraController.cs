using UnityEngine;

namespace shmup
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float speed = 2f;
        void Awake() => transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        void LateUpdate()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}