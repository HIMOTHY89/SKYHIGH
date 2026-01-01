using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Advertisements;

public class IntersitialAds : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
   [SerializeField] private string androidADUnitid;
   [SerializeField] private string IOSADUnitid;

   private string ADUNITid;


    private void Awake()
    {
        #if Unity_IOS
        ADUNITid=IOSADUnitid;
        #elif UNITY_ANDROID
        ADUNITid=androidADUnitid;
        #endif
    }

     public void LoadIntersitialAds()
    {
       Advertisement.Load(ADUNITid,this);
    }
    public void ShowIntersitialAds()
    {
        Advertisement.Show(ADUNITid,this);
        LoadIntersitialAds();
    }
    #region LoadCallBacks
    public void OnUnityAdsAdLoaded(string placementId)
    {
       Debug.Log("Intersitial Ad Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {  }
    #endregion

    #region SHOWCALLBACKS

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {  }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
           Debug.Log("Intersitial Ad completed");  
        
    }
    #endregion
   
    




}

