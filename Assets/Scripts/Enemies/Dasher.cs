using System.Collections;
using UnityEngine;

public class Dasher : EnemyMovement
{
    [SerializeField] private float dashLength;
    [SerializeField] private float pauseLength;
    [SerializeField] private float dashAngle = 35f;
    private float angleMult = 1;
    private float speedMult = 1;

    public override void Start()
    {
        base.Start();
        StartCoroutine(DashAdjust());
    }

    public override void Move()
    {
        Vector2 straight = (player.transform.position - transform.position).normalized;
        if (dashLength * moveSpeed < (player.transform.position - transform.position).magnitude)
        {
            rb.linearVelocity = (straight).normalized * moveSpeed * speedMult;
        }
        rb.linearVelocity = ((Vector2)(Quaternion.Euler(new Vector3(0, 0, dashAngle * angleMult)) * straight)).normalized * moveSpeed * speedMult;
    }

    private IEnumerator DashAdjust()
    {
        while (true)
        {
            for (float f = 0; f < dashLength; f += Time.deltaTime)
            {
                speedMult = 1.15f - Mathf.Pow(2 * f / dashLength - 1f, 2f);
                yield return new WaitForEndOfFrame();
            }
            speedMult = .15f;
            if (angleMult < 0)
            {
                for (float f = 0; f < .2f; f += Time.deltaTime)
                {
                    angleMult = f * 10 - 1;
                    yield return new WaitForEndOfFrame();
                }
                angleMult = 1;
            }
            else
            {
                for (float f = 0; f < .2f; f += Time.deltaTime)
                {
                    angleMult = -f * 10 + 1;
                    yield return new WaitForEndOfFrame();
                }
                angleMult = -1;
            }
            yield return new WaitForSeconds(pauseLength);
        }
    }
}
