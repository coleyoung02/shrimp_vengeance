using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference gunshotSound;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private float reloadTime;
    [SerializeField] private RageBubble rage;

    [SerializeField] private RectTransform bulletMeterTransform;
    [SerializeField] private GameObject winUI;

    private float reloadClock;

    private float reloadRate;
    private float bulletVelocityMultiplier;

    private float timeScaleFactor;
    private float timeOffsetFactor;

    private float damageMult;
    private float fireRateMult;

    private bool rageReady;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rageReady = false;
        reloadRate = 1f;
        damageMult = 1f;
        fireRateMult = 1f;
        bulletVelocityMultiplier = 1;

        reloadClock = reloadTime;
        timeScaleFactor = bulletMeterTransform.rect.width / reloadTime;
        timeOffsetFactor = bulletMeterTransform.rect.width / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        reloadClock += Time.deltaTime * reloadRate * fireRateMult;
        foreach (RectTransform t in bulletMeterTransform)
        {
            if (t.localPosition.x + t.rect.width / 2 + timeOffsetFactor < timeScaleFactor * reloadClock)
            {
                t.gameObject.SetActive(true);
            }
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            if (reloadClock > reloadTime)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rageReady)
            {
                StartRageInUse();
            }
        }
        if (Time.timeScale > .01f)
        {
            sprite.flipX = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position).x < 0;
        }
    }

    private void HideWinUI()
    {
        Time.timeScale = 1;
        winUI.SetActive(false);
    }

    public float GetDamage()
    {
        return damageMult;
    }

    public void DamageBoost()
    {
        damageMult *= 1.5f;
        HideWinUI();
    }

    public void RateBoost()
    {
        fireRateMult *= 1.5f;
        HideWinUI();
    }

    public void SizeBoost()
    {
        rage.gameObject.transform.localScale *= Mathf.Pow(1.3f, .5f);
        HideWinUI();
    }

    public void SetRageReady()
    {
        rageReady = true;
    }

    private void StartRageInUse()
    {
        Debug.Log("go");
        rageReady = false;
        rage.StartRageInUse();
        reloadRate = 4;
        bulletVelocityMultiplier = 2;
    }

    public void SetRageDone()
    {
        reloadRate = 1;
        bulletVelocityMultiplier = 1;
    }

    private void Shoot()
    {
        FMODUnity.RuntimeManager.PlayOneShot(gunshotSound);
        Vector2 aimAt = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 normAim = (aimAt - (Vector2)transform.position).normalized;
        Bullet b = Instantiate(bulletPrefab, transform.position, 
            Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(aimAt.y, aimAt.x) * Mathf.Rad2Deg))).GetComponent<Bullet>();
        b.StartMoving(normAim * bulletSpeed * bulletVelocityMultiplier);
        reloadClock = 0f;
        foreach (Transform t in bulletMeterTransform)
        {
            t.gameObject.SetActive(false);
        }
    }
}
