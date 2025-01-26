using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Wave", menuName = "New Wave")]
public class WaveRunner : ScriptableObject
{
    public List<GameObject> sideEnemies;
    public float sidePeriod;
    public float sideOffset;
    public List<GameObject> topEnemies;
    public float topPeriod;
    public float topOffset;
    public List<GameObject> bottomEnemies;
    public float bottomPeriod;
    public float bottomOffset;
    public float duration;
}
