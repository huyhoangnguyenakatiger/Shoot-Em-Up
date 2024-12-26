using UnityEngine;


namespace Shmup
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float speed = 5f;
        [SerializeField] float smoothness = 0.1f;
        [SerializeField] float leanAngle = 15f;
        [SerializeField] float leanSpeed = 5f;
        InputReader input;
        [SerializeField] Transform cameraFollow;
        [SerializeField] float minX = -8f;
        [SerializeField] float maxX = 8f;
        [SerializeField] float minY = -4f;
        [SerializeField] float maxY = 4f;
        Vector3 targetPosition;
        Vector3 currentVelocity;
        void Awake() => input = GetComponent<InputReader>();

        void Update()
        {
            var minPlayerX = cameraFollow.position.x + minX;
            var maxPlayerX = cameraFollow.position.x + maxX;
            var minPlayerY = cameraFollow.position.y + minY;
            var maxPlayerY = cameraFollow.position.y + maxY;

            targetPosition += new Vector3(input.Move.x, input.Move.y, 0) * (Time.deltaTime * speed);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);


            var targetRotationAngle = input.Move.x * leanAngle;
            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed);
            transform.localEulerAngles = new Vector3(0, newYRotation, 0);
        }


    }
}