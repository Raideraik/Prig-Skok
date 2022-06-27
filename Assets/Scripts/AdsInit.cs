using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour, IUnityAdsInitializationListener
{
    private string gameId = "4816848";
    private bool testMode = false;


    void Start()
    {
        Advertisement.Initialize(gameId, testMode, this);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady() 
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("Main");
    }

    public void OnInitializationComplete()
    {
       // Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
       // Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
