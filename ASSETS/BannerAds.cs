using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
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

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
       public void LoadBannerAD()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback=BannerLoaded,
            errorCallback=BannerLoadedError
        };
        
        Advertisement.Banner.Load(ADUNITid,options);
    }

    public void showBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback=Bannershown,
            clickCallback=BannerClicked,
            hideCallback=BannerHidden
        };
        Advertisement.Banner.Show(ADUNITid,options);
    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }


    #region ShowCallBacks
    private void BannerHidden() { }

    private void Bannershown() { }

    private void BannerClicked(){ }
    #endregion

    #region loadCallBacks
    private void BannerLoaded()  { }

    private void BannerLoadedError(string message)
    {
        Debug.Log("Banner ADS LOADED");
    }
    #endregion
}
