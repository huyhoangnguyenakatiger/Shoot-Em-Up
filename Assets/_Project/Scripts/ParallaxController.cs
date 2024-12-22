using UnityEngine;
namespace shmup
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds;
        [SerializeField] float smoothing = 10f;
        [SerializeField] float multiplier = 15f;
        Transform cam;
        Vector3 previousCamPos;

        void Awake() => cam = Camera.main.transform;

        void Start() => previousCamPos = cam.position;

        void Update()
        {
            for (var i = 0; i < backgrounds.Length; i++)
            {
                var parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                var targetY = backgrounds[i].position.y + parallax;

                var targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}