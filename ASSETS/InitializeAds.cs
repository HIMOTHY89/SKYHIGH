using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InitializeAds : MonoBehaviour,IUnityAdsInitializationListener
{
   [SerializeField] public string gameAndroidID;
   [SerializeField] public string gameiosID;
   [SerializeField] public bool IsTesting;

   private string GameID;

    

    private void Awake()
    {
        #if Unity_IOS 
        GameID =gameiosID;
        #elif UNITY_ANDROID
        GameID=gameAndroidID;
        #elif UNITY_EDITOR
        GameID=gameAndroidID;
        #endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(GameID,IsTesting,this);
        }

    }

    public void OnInitializationComplete()
    {
       Debug.Log("Ads Initialized...");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) {   }







}
