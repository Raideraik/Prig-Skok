using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private int _valule;

    public int GivePoints() 
    {
        return _valule;
    }

}
