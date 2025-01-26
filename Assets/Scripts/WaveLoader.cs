using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLoader : MonoBehaviour
{
    [SerializeField] private List<WaveRunner> waves;
    [SerializeField] private GameObject winUI;

    [SerializeField] private List<Transform> sideSpawns;
    [SerializeField] private List<Transform> topSpawns;
    [SerializeField] private List<Transform> bottomSpawns;

    private int waveIndex;
    private float clock;
    private bool startWave;
    private bool done;

    private enum PosToInd
    {
        Side = 0,
        Top = 1, 
        Bottom = 2
    }

    private bool firstDone;

    // spawn indicies
    private int[] spInd;

    private void Start()
    {
        firstDone = false;
        done = false;
        spInd = new int[3]{ 0, 0, 0 };
        startWave = true;
        waveIndex = 0;
        clock = 0f;
    }

    private void Update()
    {
        if (done)
        {
            
        }
        else
        {
            if (startWave)
            {
                if (FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length <= 0)
                {
                    StartWave();
                }
            }
            if (clock > waves[waveIndex].duration)
            {
                Debug.Log("wave over");
                StopAllCoroutines();
                clock = 0f;
                waveIndex++;
                if (waveIndex < waves.Count)
                {
                    startWave = true;
                }
                else
                {
                    done = true;
                }
            }
            clock += Time.deltaTime;
        }
    }

    private void StartWave()
    {
        if (firstDone)
        {
            Time.timeScale = 0f;
            winUI.SetActive(true);
        }
        else
        {
            firstDone = true;
        }
        Debug.Log("startwave");
        startWave = false;
        if (waves[waveIndex].topEnemies.Count > 0)
        {
            Debug.Log("startwave1");
            StartCoroutine(SpawnsFromList(waves[waveIndex].topEnemies, topSpawns, waves[waveIndex].topPeriod, PosToInd.Top, waves[waveIndex].topOffset));
        }
        if (waves[waveIndex].bottomEnemies.Count > 0)
        {
            Debug.Log("startwave2");
            StartCoroutine(SpawnsFromList(waves[waveIndex].bottomEnemies, bottomSpawns, waves[waveIndex].bottomPeriod, PosToInd.Top, waves[waveIndex].bottomOffset));
        }
        if (waves[waveIndex].sideEnemies.Count > 0)
        {
            Debug.Log("startwave3");
            StartCoroutine(SpawnsFromList(waves[waveIndex].sideEnemies, sideSpawns, waves[waveIndex].sidePeriod, PosToInd.Top, waves[waveIndex].sideOffset));
        }
    }

    private IEnumerator SpawnsFromList(List<GameObject> enemyList, List<Transform> tList, float period, PosToInd position, float offset=0f)
    {
        yield return new WaitForSeconds(offset);
        Debug.Log("shpawn");
        Instantiate(enemyList[spInd[(int)position] % enemyList.Count], tList[spInd[(int)position] % tList.Count].transform.position, Quaternion.identity);
        spInd[(int)position]++;
        yield return new WaitForSeconds(period);
        StartCoroutine(SpawnsFromList(enemyList, tList, period, position));
    }
}
