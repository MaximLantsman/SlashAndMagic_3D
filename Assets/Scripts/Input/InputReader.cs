using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using static InputSystem_Actions;

[CreateAssetMenu(fileName = "InputReader", menuName = "Platformer/InputReader")]
public class InputReader : ScriptableObject,IPlayerActions
{
    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction<bool> Attack = delegate { };
    public event UnityAction<bool> Dash = delegate { };
    
    private InputSystem_Actions inputSystemActions;
    
    public Vector3 Direction => inputSystemActions.Player.Move.ReadValue<Vector2>();

    private void OnEnable()
    {
        if (inputSystemActions == null)
        {
            inputSystemActions = new InputSystem_Actions();
            inputSystemActions.Player.SetCallbacks(this);
        }
    }

    public void EnablePlayerActions()
    {
        inputSystemActions.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
            Attack.Invoke(true);
            break;
            case InputActionPhase.Canceled:
            Attack.Invoke(false);
            break;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //noop
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Dash.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Dash.Invoke(false);
                break;
        }
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        //noop
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        //noop
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        //noop
    }
}
