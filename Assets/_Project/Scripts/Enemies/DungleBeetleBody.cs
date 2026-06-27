using UnityEngine;

public class DungBeetleBody : MonoBehaviour
{
    [SerializeField] private GameObject beetleGroup;
    [SerializeField] private float stompBounceForce = 8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player == null) return;

        bool playerIsAbove = collision.transform.position.y > transform.position.y + 0.3f;

        if (playerIsAbove)
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, stompBounceForce);

            beetleGroup.SetActive(false);
        }
        else
        {
            player.Die();
        }
    }
}