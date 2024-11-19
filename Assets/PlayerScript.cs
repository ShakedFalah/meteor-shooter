using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private InputProvider _inputProvider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _bullet;
    
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _accelerationSpeed = 500;
    [SerializeField] private float _deccelerationSpeed = 1;
    [SerializeField] private float _turningSpeed = 200;
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
        _rigidbody.linearDamping = _deccelerationSpeed;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigidbody.AddRelativeForceY(_inputProvider.MovementInput() * _accelerationSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        _rigidbody.linearVelocity = Vector2.ClampMagnitude(_rigidbody.linearVelocity, _maxSpeed);
        transform.Rotate(new Vector3(0,0,_inputProvider.TurningInput() * _turningSpeed * Time.fixedDeltaTime));
    }

    void shoot(InputAction.CallbackContext context)
    {
        Instantiate(_bullet,transform.position, transform.rotation);
    }
}
