﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _speed;

    private void Start()
    {
        Application.targetFrameRate = 120;

    }
    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, _ball.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
