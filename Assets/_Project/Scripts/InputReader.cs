using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup
{
    // [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        PlayerInput playerInput;
        InputAction moveAction;
        InputAction fireAction;

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            fireAction = playerInput.actions["Fire"];
        }

        public Vector2 Move => moveAction.ReadValue<Vector2>();

        public bool Fire => fireAction.IsPressed();
    }


}
