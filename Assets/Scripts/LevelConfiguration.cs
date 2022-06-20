using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Config", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private int _towerSize;
    [SerializeField] private Segment _segment;
    

    public int TowerSize => _towerSize;
    public Segment Segment => _segment;

}
