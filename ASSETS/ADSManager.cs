using JetBrains.Annotations;
using UnityEngine;

public class ADSManager : MonoBehaviour
{
    public InitializeAds InitializeAds;
    public BannerAds bannerAds;
    public IntersitialAds intersitialAds;
    public RewardedAds rewardedAds;


    public static ADSManager Instance {get;private set; }

    private void Awake()
    {
        if (Instance !=null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
        DontDestroyOnLoad(gameObject);

        bannerAds.LoadBannerAD();
        intersitialAds.LoadIntersitialAds();
        rewardedAds.LoadRewardedAds();
    }
}
