using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameID = "4880532";
    private string RewardedID = "Rewarded_iOS";
    private string bannerID = "Banner_iOS";
#else 
    private string gameID = "4880533";
    private string rewardedID = "Rewarded_Android";
    private string bannerID = "Banner_Android";
#endif

    private Main main;
    public GameObject rewardButton;
    public Animator rewardAnimation;

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("GameHandler").GetComponent<Main>();
        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
        PlayBanner();
    }

    public void PlayRewardedAD()
    {
        if(Advertisement.IsReady(rewardedID))
        {
            Advertisement.Show(rewardedID);
        }
        else
        {
            //Debug.Log("Rewarded Ad not ready");
        }
    }

    public void PlayBanner()
    {
        if(Advertisement.IsReady(bannerID))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerID);
        }    
        else
        {
            StartCoroutine(RepeatPlayBanner());
        }
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatPlayBanner()
    {
        yield return new WaitForSeconds(1f);
        PlayBanner();
    }

    public void OnUnityAdsReady(string placementId)
    {
        //Debug.Log("Ad Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        //Debug.Log("Error " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //Debug.Log("Ad Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == rewardedID && showResult == ShowResult.Finished)
        {
            main.advertReward();

            main.SetBool(false);

            rewardAnimation.SetBool("spawn", false);
        }
    }
}
