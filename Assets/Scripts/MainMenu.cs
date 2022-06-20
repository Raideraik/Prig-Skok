using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private GameObject _shop;

    public void LevelChooser()
    {
        SceneManager.LoadScene(_levelNumber);
    }

    public void Shop() 
    {
        _shop.SetActive(true);
    }


    public void Exit() 
    {
        Application.Quit();
    }

}
