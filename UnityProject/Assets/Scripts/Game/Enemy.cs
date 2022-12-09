using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float chaseDistance;

    [SerializeField]
    private Moveable moveable;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Collider2D boundsCollider;

    private PlayerController player;

    private bool isAlive;


    private void Start()
    {
        isAlive = true;
        boundsCollider.enabled = false;
    }

    public void AddPlayerDependency(PlayerController player)
    {
        this.player = player;
    }
    
    private void Update()
    {
        if (!isAlive)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < chaseDistance)
        {
            boundsCollider.enabled = true;
            RunAwayFromPlayer();
        }
        else
        {
            boundsCollider.enabled = false;
        }
    }

    private void RunAwayFromPlayer()
    {
        Vector3 moveDir = transform.position - player.transform.position;
        moveable.AddVelocity(moveDir.normalized.x, moveDir.normalized.y);
    }

    private void Die()
    {
        spriteRenderer.color = Color.black;
        boundsCollider.enabled = true;
        isAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            Die();
        }
    }
}
