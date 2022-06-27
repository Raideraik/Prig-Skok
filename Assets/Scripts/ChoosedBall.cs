using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosedBall : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;
    [SerializeField] private Ball _ball;
    [SerializeField] private int _id;
    public int Id => _id;

    private void Start()
    {
        
        _ball.AddSound(_audio);
    }


    
}
