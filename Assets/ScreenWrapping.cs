using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ScreenWrapping : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the screen position of object in Pixels
        Vector3 screenPos = Camera.main.WorldToScreenPoint(myRigidBody.position);

        // Get the side of the screen in world units
        Vector2 topRightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 bottomLeftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        // If object moving through left side
        if (screenPos.x <= 0 && myRigidBody.linearVelocityX < 0)
        {
            transform.position = new Vector2 (topRightSideOfScreenInWorld.x, transform.position.y);
        }
        // If object moving through right side
        else if (screenPos.x >= Screen.width && myRigidBody.linearVelocityX > 0)
        {
            transform.position = new Vector2(bottomLeftSideOfScreenInWorld.x, transform.position.y);
        }
        // If object moving through top side
        if (screenPos.y <= 0 && myRigidBody.linearVelocityY < 0)
        {
            transform.position = new Vector2(transform.position.x, topRightSideOfScreenInWorld.y);
        }
        // If object moving through left side
        else if (screenPos.y >= Screen.height && myRigidBody.linearVelocityY > 0)
        {
            transform.position = new Vector2(transform.position.x, bottomLeftSideOfScreenInWorld.y);
        }
    }
}
