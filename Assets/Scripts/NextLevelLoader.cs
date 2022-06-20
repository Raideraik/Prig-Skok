using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Ball _ball;
    [SerializeField] private LevelConfiguration[] _config;

    private void OnEnable()
    {
        _ball.Finished += OnTowerSizeChanged;
    }

    private void OnDisable()
    {
        _ball.Finished -= OnTowerSizeChanged;

    }

    private void OnTowerSizeChanged() 
    {


        Level1.Load(_config[Random.Range(0, _config.Length)]);
    } 
}
