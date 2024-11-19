using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider
{
    private PlayerInput _input = new ();

    public void Enable()
    {
        _input.Game.Move.Enable();
        _input.Game.Turn.Enable();
        _input.Game.Shoot.Enable();
    }

    public void Disable()
    {
        _input.Game.Move.Disable();
        _input.Game.Turn.Disable();
        _input.Game.Shoot.Disable();
    }

    public event Action<InputAction.CallbackContext> ShootPerformed
    {
        add
        {
            _input.Game.Shoot.performed += value;
        }
        remove
        {
            _input.Game.Shoot.performed -= value;
        }
    }

    public float MovementInput()
    {
        return _input.Game.Move.ReadValue<float>();
    }

    public float TurningInput()
    {
        return _input.Game.Turn.ReadValue<float>();
    }

}