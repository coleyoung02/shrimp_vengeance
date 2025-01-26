using UnityEngine;
using UnityEngine.UI;

public class RageBubble : MonoBehaviour
{
    [SerializeField] private int enemiesIn;
    [SerializeField] private Slider slider;
    [SerializeField] private Gun gun;
    [SerializeField] private float rageDecreaseRate;
    private float rage;
    private bool rageInUse;

    private void Start()
    {
        rage = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemiesIn++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemiesIn--;
    }

    private void Update()
    {
        if (rageInUse)
        {
            rage -= Time.deltaTime * rageDecreaseRate;
            slider.value = rage;
            if (rage <= 0)
            {
                Debug.Log("unraging");
                gun.SetRageDone();
                rageInUse = false;
            }
        }
        else
        {
            rage += enemiesIn * Time.deltaTime;
            slider.value = rage;
            if (rage >= slider.maxValue)
            {
                gun.SetRageReady();
            }
        }
    }

    public void StartRageInUse()
    {
        Debug.Log("raging");
        rageInUse = true;
        rage = slider.maxValue;
    }
}
