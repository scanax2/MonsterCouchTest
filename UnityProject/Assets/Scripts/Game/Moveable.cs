using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float velocityDrag;

    [SerializeField]
    private float maxSpeed;

    private Vector2 velocity = Vector2.zero;


    public void AddVelocity(float x, float y)
    {
        velocity.x += x * Time.deltaTime * moveSpeed;
        velocity.y += y * Time.deltaTime * moveSpeed;
    }

    private void FixedUpdate()
    {
        velocity *= (1 - Time.fixedDeltaTime * velocityDrag);
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        MoveEntityOnScreen(velocity * Time.fixedDeltaTime);
    }

    private void MoveEntityOnScreen(Vector2 offsetValue)
    {
        rigidbody2D.AddForce(offsetValue * 500f);
    }
}
