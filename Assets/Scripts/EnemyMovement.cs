using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        player = FindAnyObjectByType<Gun>().gameObject;
    }

    public virtual void Update()
    {
        Move();
    }

    public abstract void Move();
}
