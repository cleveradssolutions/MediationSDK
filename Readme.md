# CleverAdsSolutions Unity - Deprecated

## Migrate to new [Clever Ads Solutions Unity Package](https://github.com/cleveradssolutions/CAS-Unity)


***
#### Namespace: ~~PSV~~ -> `CAS`

### ADS Settings
~~Window -> PSV Ads Settings -> Android / iOS~~  
`Assets -> CleverAdsSolutions -> Settings...`

### Initialization
~~Automatic initialization at the start of the game.~~  
The new CAS needs to be initialized manually, see [Step 4](https://github.com/cleveradssolutions/CAS-Unity#step-4-initialize-cas-sdk)

### Check Ad Availability
~~PSV.AdsManager.isAdReady(AdType.Interstitial);~~
```csharp
bool ready = CAS.MobileAds.manager.IsReadyAd( AdType.Interstitial ); // Check any AdType
```

### Banner ad
~~PSV.AdsManager.ShowSmallBanner(AdPosition.Bottom_Center);~~
```csharp
CAS.MobileAds.manager.ShowAd(AdType.Banner);
```
For change the size or position the banner on screen use following code:
~~PSV.AdsManager.RefreshSmallBanner(AdPosition.Bottom_Center, AdSize.Adaptive );~~
```csharp
CAS.MobileAds.manager.bannerSize = AdSize.Banner;
CAS.MobileAds.manager.bannerPosition = AdPosition.BottomCenter;
```
For hide a banner from the screen using the following code:
~~PSV.AdsManager.HideSmallBanner()~~
```csharp
CAS.MobileAds.manager.HideBanner();
```

### Interstitial Ad
Invoke the following method to show an Interstitial ad:  
~~PSV.AdsManager.ShowInterstitial(forece);~~  
OR ~~PSV.AdsManager.Show(AdType.Interstitial);~~
```csharp
CAS.MobileAds.manager.ShowAd(AdType.Interstitial);
```
You can subscribe to Interstitial global events that are invoked for each impression:  
~~PSV.AdsManager.OnInterstitialShown~~  
~~PSV.AdsManager.OnInterstitialClosed~~
```csharp
CAS.MobileAds.manager.OnInterstitialAdShown; += () => { Debug.Log("Interstitial are shown") };
CAS.MobileAds.manager.OnInterstitialAdClosed += () => { Debug.Log("Interstitial are closed") };
```

### Rewarded Video Ad
Rewarded Video Ad has such global events that are invoked for each impression:
~~PSV.AdsManager.OnRewardedShown~~  
~~PSV.AdsManager.OnRewardedClosed~~  
~~PSV.AdsManager.OnRewardedComplete~~
```csharp
CAS.MobileAds.manager.OnRewardedAdShown += () => { Debug.Log("Rewarded Ad are shown") };
CAS.MobileAds.manager.OnRewardedAdClosed += () => { Debug.Log("Rewarded Ad are closed") };
CAS.MobileAds.manager.OnRewardedAdCompleted += () => { Debug.Log("Congratulations, you watched the video to the end. Get reward.") };
```
Invoke the following method to show an Rewarded Ad:  
~~PSV.AdsManager.ShowRewardedVideoAd();~~  
~~PSV.AdsManager.Show(AdType.Rewarded);~~
```csharp
CAS.MobileAds.manager.ShowAd(AdType.Rewarded);
```

~~PSV.AdsManager.TryShowRewardedVideoAd(successful, fail, successOnAdDisabled);~~  
~~PSV.AdsManager.ShowRewardedElseInterAd(successful, fail, successOnAdDisabled);~~  
**No longer supported.**

### Migrate API
#### ~~PSV.AdsSettings~~ -> CAS.MobileAds.settings
| Deprecated | New API |
|---------------|-----------|
| IsTaggedForChildren() | taggedAudience |
| SetTaggedForChildren(bool forChildren) | taggedAudience |
| SetConsent(bool consent) | userConsent |
| GetConsent() | userConsent |
| SetNativeDebug(bool debug) | isDebugMode |
| IsNativeDebugEnabled() | isDebugMode |
| SetMutedAdSounds(bool muted) | isMutedAdSounds |
| SetInterstitialInterval(float seconds) | interstitialInterval |
| GetInterstitialInterval() | interstitialInterval |
| IsAdTypeEnabled(AdType type, bool defaultValue) | IsEnabledAd(AdType adType) |
| IsCollectResponseInfo() | Deprecated |
| IsDesignedForFamilies() | Deprecated |
| SetDesignedForFamilies(bool forFamilies) | Deprecated |
| GetContentRating() | Deprecated |
| SetContentRating(ContentRating rating) | Deprecated |
| AddFiltersListener(IListener listener) | Deprecated |
| RemoveFiltersListener(IListener listener) | Deprecated |
| AddOptionsListener(IOptionsListener listener) | Deprecated |
| RemoveOptionsListener(IOptionsListener listener) | Deprecated |

#### ~~PSV.AdsManager~~ -> CAS.MobileAds.manager
| Deprecated | New API |
|---------------|-----------|
| IsAdsProcessing(AdType type, bool enabled) | IsEnabledAd(AdType adType) |
| IsAdsEnabled(AdTypeFlags types) | IsEnabledAd(AdType adType) |
| Show(AdType type, string network = null) | ShowAd(AdType adType) |
| IsAdReady(AdType type) | IsReadyAd(AdType adType) |
| GetInfoLastActiveAd(AdType type) | GetLastActiveMediation(AdType adType) |
| GetAdSize() | bannerSize |
| GetBannerSizeInPX() | new Vector2(GetBannerWidthInPixels(), GetBannerHeightInPixels()) |
| GetAdPos() | bannerPosition |
| HideSmallBanner() | HideBanner() |
| RefreshSmallBannerForCurrentScene() | Deprecated |
| GetBannerVisible() | Deprecated |

#### ~~PSV.ADS.AdSize~~ -> CAS.AdSize
| Deprecated | New API |
|---------------|-----------|
| Smart_banner | SmartBanner |
| Standard_banner_320x50 | Banner |
| Adaptive_banner | AdaptiveBanner |

#### Other API
| Deprecated | New API |
|---------------|-----------|
| PSV.NextFrameCall.Add() | CAS.EventExecutor.Add() |
| PSV.ConstSettings.version | CAS.MobileAds.GetSDKVersion() |

## Support
Technical support: Max  
Skype: m.shevchenko_15  

Network support: Vitaly  
Skype: zanzavital  

mailto:support@cleveradssolutions.com  
