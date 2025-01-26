using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private float lowerHeight;
    [SerializeField] private float riseHeight;
    [SerializeField] private GameObject nextBossAttack;
    [SerializeField] private int points;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float descentSpeed;
    [SerializeField] private float rotateRate;

    private float angle;
    private bool riseMode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angle = transform.rotation.eulerAngles.z;
        riseMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!riseMode)
        {
            if (transform.position.y > lowerHeight)
            {
                rb.linearVelocity = Vector2.down * descentSpeed;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                angle += rotateRate * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.y < riseHeight)
            {
                rb.linearVelocity = Vector2.up * 2 * descentSpeed;
            }
            else
            {
                gameObject.SetActive(false);
                if (nextBossAttack != null)
                {
                    nextBossAttack.SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene("WinScene");
                }
            }
        }
    }

    public void NotifyDead()
    {
        points--;
        if (points <= 0)
        {
            riseMode = true;
        }
    }
}
