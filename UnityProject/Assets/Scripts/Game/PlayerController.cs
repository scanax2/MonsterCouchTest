using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Moveable moveable;


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveable.AddVelocity(horizontal, vertical);
    }
}
