using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBall : MonoBehaviour
{
    [SerializeField] private List<ChoosedBall> _customBalls;
    
    
    private void Start()
    {
        for (int i = 0; i < _customBalls.Count; i++)
        {
            if (_customBalls[i].Id == PlayerPrefs.GetInt("ChoosedBall"))
            {
                _customBalls[i].gameObject.SetActive(true);
            }
        }
    }
}
