using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private InputProvider _inputProvider;

    private float _speed = 0;
    private float _maxSpeed = 100;
    private float _accelerationSpeed = 10;
    private float _deccelerationSpeed = 10;
    private void OnEnable()
    {
        _inputProvider = new InputProvider();
        _inputProvider.Enable();
        _inputProvider.ShootPerformed += shoot;
    }

    private void OnDisable()
    {
        _inputProvider.Disable();
        _inputProvider.ShootPerformed -= shoot;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shoot(InputAction.CallbackContext context)
    {

    }
}
