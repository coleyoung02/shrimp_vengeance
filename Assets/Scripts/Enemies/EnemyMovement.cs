using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] private bool overrideFlip;
    [SerializeField] private bool overrideRotate;
    [SerializeField] private bool overrideRotateFlip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        enemy.GetSprite().flipX = true;
        player = FindAnyObjectByType<Gun>().gameObject;
        if (!overrideFlip)
        {
            enemy.GetSprite().flipX = transform.position.x < player.transform.position.x;
        }
    }

    public virtual void Update()
    {
        Move();
        if (rb.linearVelocity.x != 0f)
        {
            if (!overrideRotate)
            {
                if (enemy.GetSprite().flipX && !overrideRotateFlip)
                {
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg));
                }
                else
                {
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-rb.linearVelocity.y, -rb.linearVelocity.x) * Mathf.Rad2Deg));
                }
            }
        }
    }

    public abstract void Move();
}
