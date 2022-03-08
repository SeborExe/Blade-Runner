using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 movementInput;
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Wci�ni�ty przycisk
        }

        if (context.performed)
        {
            //Przycisk jest trzymany
        }

        if (context.canceled)
        {
            //Puszczenie przycisku
        }
    }
}
