using UnityEngine;

public class BasicEnemyMovement : EnemyMovement
{
    public override void Move()
    {
        rb.linearVelocity = (player.transform.position - transform.position).normalized * moveSpeed;
    }
}
