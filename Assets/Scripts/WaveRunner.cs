using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Wave", menuName = "New Wave")]
public class WaveRunner : ScriptableObject
{
    [SerializeField] private List<GameObject> sideEnemies;
    [SerializeField] private float sidePeriod;
    [SerializeField] private float sideOffset;
    [SerializeField] private List<GameObject> topEnemies;
    [SerializeField] private float topPeriod;
    [SerializeField] private float topOffset;
    [SerializeField] private List<GameObject> bottomEnemies;
    [SerializeField] private float bottomPeriod;
    [SerializeField] private float bottomOffset;
    [SerializeField] private float duration;
}
