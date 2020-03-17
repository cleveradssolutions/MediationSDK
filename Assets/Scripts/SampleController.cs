using UnityEngine;
using UnityEngine.UI;
using PSV;
using PSV.ADS;

public class SampleController : MonoBehaviour
{
    public bool userConsent;
    public Text versionText;
    public Text bannerStatus;
    public Text interstitialStatus;
    public Text rewardedStatus;

    public void Start()
    {
        versionText.text = ConstSettings.version;

        AdsSettings.SetConsent(userConsent);

        InvokeRepeating("OnRefreshStatus", 1.0f, 1.0f);
    }

    public void ShowBanner()
    {
        AdsManager.Show(AdType.Small);
    }

    public void HideBanner()
    {
        AdsManager.HideSmallBanner();
    }

    public void SetBannerPosition(int positionEnum)
    {
        AdsManager.RefreshSmallBanner((AdPosition)positionEnum, default(AdSize));
    }

    public void SetBannerSize(int sizeID)
    {
        AdSize size;
        switch (sizeID)
        {
            case 0:
                size = AdSize.Standard_banner_320x50;
                break;
            case 1:
                size = AdSize.Adaptive_banner;
                break;
            default:
                return;
        }
        AdsManager.RefreshSmallBanner(AdPosition.Undefined, size);
    }

    public void ShowInterstitial()
    {
        AdsManager.Show(AdType.Interstitial);
    }

    public void ShowRewarded()
    {
        if (AdsManager.TryShowRewardedVideoAd(RewardedSuccessful, RewardedCanceled))
        {
            Debug.LogError("Rewarded are not ready. Please try again later.");
        }
    }

    public void ShowRewardedElseInter()
    {
        AdsManager.ShowRewardedElseInterAd(RewardedSuccessful, RewardedSuccessful);
    }

    private void OnRefreshStatus()
    {
        bannerStatus.text = AdsManager.IsAdReady(AdType.Small) ? "Ready" : "Loading";
        interstitialStatus.text = AdsManager.IsAdReady(AdType.Interstitial) ? "Ready" : "Loading";
        rewardedStatus.text = AdsManager.IsAdReady(AdType.Rewarded) ? "Ready" : "Loading";
    }

    private void RewardedSuccessful()
    {
        Debug.Log("Rewarded Successful");
    }

    private void RewardedCanceled()
    {
        Debug.Log("Rewarded Canceled");
    }
}
