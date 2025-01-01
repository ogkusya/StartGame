using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool IsMove => MoveInput != Vector2.zero;
    public bool IsJump { get; private set; }

    public Action OnJumpAction;

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsJump = true;
            OnJumpAction?.Invoke();
        }
        else
        {
            IsJump = false;
        }
    }
}
