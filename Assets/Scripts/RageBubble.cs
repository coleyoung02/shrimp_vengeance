using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RageBubble : MonoBehaviour
{
    [SerializeField] private int enemiesIn;
    [SerializeField] private Slider slider;
    [SerializeField] private Gun gun;
    [SerializeField] private float rageIncreaseRate;
    [SerializeField] private float rageDecreaseRate;

    private float rage;
    private bool rageInUse;
    private bool canGetRage;

    private void Start()
    {
        rage = 0f;
        canGetRage = true;
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
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("chaosmode", 0);
                gun.SetRageDone();
                rageInUse = false;
                StartCoroutine(DelayAfter());
            }
        }
        else
        {
            if (canGetRage)
            {
                rage += Mathf.Pow(enemiesIn, .75f) * Time.deltaTime * rageIncreaseRate;
            }
            slider.value = rage;
            if (rage >= slider.maxValue)
            {
                gun.SetRageReady();
            }
        }
    }

    public void StartRageInUse()
    {
        canGetRage = false;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("chaosmode", 1);
        Debug.Log("raging");
        rageInUse = true;
        rage = slider.maxValue;
    }

    private IEnumerator DelayAfter()
    {
        yield return new WaitForSeconds(2f);
        canGetRage = true;
    }
}
