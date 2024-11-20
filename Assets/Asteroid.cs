using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Vector3 screenCenter;
    void Start()
    {
        screenCenter = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
        transform.up = screenCenter - transform.position;
        // transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 90);
        GetComponent<Rigidbody2D>().AddForce(transform.up * 300f);
    }

    void OnBecameInvisible() => Destroy(gameObject);
}

