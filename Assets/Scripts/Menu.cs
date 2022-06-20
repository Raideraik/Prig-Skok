using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Restart() 
    {
        SceneManager.LoadScene(0);
    }

    public void ResetBestTime() 
    {
        PlayerPrefs.SetInt("BestTime",0);

        
    }
}
