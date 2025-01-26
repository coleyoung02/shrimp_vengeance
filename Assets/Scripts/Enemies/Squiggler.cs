using UnityEngine;

public class Squiggler : EnemyMovement
{
    [SerializeField] private float squiggleAngle;
    [SerializeField] private float squiggleFrequency;

    public override void Move()
    {
        Vector2 straight = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = ((Vector2)(Quaternion.Euler(new Vector3(0, 0, squiggleAngle * Mathf.Sin(Time.time * Mathf.PI * 2 * squiggleFrequency))) * straight)).normalized * moveSpeed;
    }
}
