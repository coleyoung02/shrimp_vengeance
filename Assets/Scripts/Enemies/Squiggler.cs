using UnityEngine;

public class Squiggler : EnemyMovement
{


    public override void Move()
    {
        Vector2 straight = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = ((Vector2)(Quaternion.Euler(new Vector3(0, 0, 65*Mathf.Sin(Time.time * 2))) * straight)).normalized * moveSpeed;
    }
}
