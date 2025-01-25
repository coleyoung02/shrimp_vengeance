using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        Vector2 aimAt = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 normAim = (aimAt - (Vector2)transform.position).normalized;
        Bullet b = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        b.StartMoving(normAim * bulletSpeed);
    }
}
