using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup
{
    // [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        PlayerInput playerInput;
        InputAction moveAction;

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
        }

        public Vector2 Move => moveAction.ReadValue<Vector2>();
    }


}
