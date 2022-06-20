using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public event UnityAction ClickedOnRestart;
    public void Restart() 
    {
        ClickedOnRestart?.Invoke();
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetBestTime() 
    {
        PlayerPrefs.SetInt("BestTime",0);

        
    }
}
