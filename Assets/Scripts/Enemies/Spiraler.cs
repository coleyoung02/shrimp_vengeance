using UnityEngine;

public class Spiraler : EnemyMovement
{
    [SerializeField] private float attackAngle;

    public override void Move()
    {
        Vector2 straight = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = ((Vector2)(Quaternion.Euler(new Vector3(0, 0, attackAngle)) * straight)).normalized * moveSpeed;
    }
}
