using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _bulletSpeed = 1000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody.AddRelativeForceY(_bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
