## Description 📖
### Main mediation SDK:
* [Admob](https://admob.google.com/home)
* [AppLovin](https://www.applovin.com)
* [Chartboost](https://www.chartboost.com)
* [KIDOZ](https://kidoz.net)
* [UnityAds](https://unity.com/solutions/unity-ads)
* [Vungle](https://vungle.com)
* [AdColony](https://www.adcolony.com)
* [StartApp](https://www.startapp.com)
* [SuperAwesome](https://www.superawesome.com)
* [IronSource](https://www.ironsrc.com)

### Mediation Not Childish applications:
* [Facebook Audience](https://www.facebook.com/business/marketing/audience-network)
* [Yandex Ad](https://yandex.ru/dev/mobile-ads)
* [MyTarget](https://target.my.com)

## Supported Unity
*  Min version Unity 2017.4
*  Android MinSdkVersion 16  
*  Gradle 3.2.0+  
*  useAndroidX = true  
*  enableJetifier = true  

## Installation ⚙️
### 1. Download unitypackage.
[In section Release](https://github.com/cleveradssolutions/MediationSDK/releases/latest)  
Package contains all required modules for mediation. <br>
### 2. SDK Installer.
After import installer will be lauched automaticaly. <br>

![ads_android_setting](http://drive.google.com/uc?export=view&id=14EE42oMzu4gUNqp0k5ozqvh8KJO-NZkQ)

There must be no compillation errors for success automatic installation launcher. Otherwise you can lauch installer manually or manually import all required packages from Assets/PSV/MediationInstaller.

![image](https://drive.google.com/uc?export=view&id=14DCo0I8rFFJgesQ0fAZPFcbR6INchVOV)

Installation process:

1. Install DLL Basement for Unity 2017 or 2018+ (Require)
1. Install main Mediation SDK of networks (Require)
1. Clean Assets (Require)

<b>Important!</b>
For successful work min <b>gradle</b> 3.2.0 required!  
If you using Unity 2018.3 and less you should check you gradle version. Go to

<b>"*Unity Folder*\Editor\Data\PlaybackEngines\AndroidPlayer\Tools\GradleTemplates"</b> 

in file  <b>mainTemplate.gradle</b>  you will find line with version  

<b>"classpath 'com.android.tools.build:gradle:3.2.0'"</b> . 

If your gradle version less than 3.2.0 you'l have to update gradle manually or use newer Unity version.
 
### 3. Setup.
For settings editing go to Window -> PSV Ads Settings -> Android / IOs

![ads_android_setting](http://drive.google.com/uc?export=view&id=1dCyMybCKjIBRBpYpQKivhCkqQqQzqW0C)

|Action|Description|
| --- | --- |
| Update | Download config from server|
| Set Dummy| Create testing configuration|
| Layers identified | On/Off ads types |
| Interstital delay | Delay between interstitial can be shown (sec) |

If you want to use debug configuration select <b>Set Dummy</b> otherwise <b>for final release app must be connected to ads networks.  
Please [CONTACT](https://github.com/cleveradssolutions/MediationSDK/blob/master/Readme.md#support) us using skype or email below and send us Google Play app link.</b> Then you'll able select Update in PSV ADS Settings and refresh final configuration. 

In section <b>Publishing Settings</b> set <b>Custom Gradle Template</b>. 

![image](https://drive.google.com/uc?export=view&id=1TiqVJbkK9u06uTmAtWNOrFkX45um2-OD)

After that config <b>mainTemplate</b> will be added to <b>Plugins/Android</b>.

![image](https://drive.google.com/uc?export=view&id=1pmKf2gZ_iPDgxgEvgBnegFcUkivxp0jw)
 
 In section Android Resolver Settings enable <b>Patch mainTemplate.gradle</b> and Use <b>Jetifier</b>.
 
 ![image](https://drive.google.com/uc?export=view&id=1pXrwhX2cgB0mHU_h5fTgYL7E2hondAQ8)
 
### Done
Now you can use mediation in your project. 😊

For testing you can add scene <b>PSVMediationTest</b> from <b>Assets/PSV/MediationTest</b> to Scenes in Build and check state of all networks. 

There you will see different states for all ads types. If you'll see "Error | No Fill, Error | Request timeout" - this is normal situation means in present time there is no ad from concrete network. Please wait a little bit state will be updated.
 
![image](https://drive.google.com/uc?export=view&id=1tGYqyJgCgg65hfbXDeHyHM743tIw7vP0)

## Functions
### AdsSettings
```csharp
/// Get Demo Id for Android or IOs platform 
string PSV.AdsSettings.GetDemoAdmobAppId(RuntimePlatform platform)

///Get Platform simple string name
string PSV.AdsSettings.GetPlatformName(RuntimePlatform platform)

///Init networks types
PSV.AdsSettings.FindNetworkTypes(MediationInfo[] filter, Func<IAdProvider>[] result, bool[] singleton)

///Init networks types
PSV.AdsSettings.FindNetworkTypes(Assembly assembly, MediationInfo[] filter, Func<IAdProvider>[] result, bool[] singleton)

///Init networks types
PSV.AdsSettings.FindNetworkTypes(out List<AdsProviderNetAttribute> attributes, out List<Type> types)

///Init networks types
PSV.AdsSettings.FindNetworkTypes(Assembly assembly, out List<AdsProviderNetAttribute> attributes, out List<Type> types)

///Init load AdsSettingsData
PSV.AdsSettings.Load(Action<AdsSettingsData> complete)

///Init load AdsSettingsData from json cache
PSV.AdsSettings.LoadFromChache(string local_path, AdsSettingsData result, Action<AdsSettingsData> complete)

///Get request Ad url
PSV.AdsSettings.GetRemoteUrl(string location, RuntimePlatform platform)

///Save current params to json
PSV.AdsSettings.SaveRemoteToCache(string json_data)

``` 
### AdsManager
```csharp
/// Enable or disable Ads
PSV.AdsManager.SetAdsEnabled(bool param)

///Enable or disable Ads by certain type
PSV.AdsManager.SetAdsEnabled(AdType type, bool param)

///Check is Ads enabled
PSV.AdsManager.IsAdsEnabled()

///Check is Ads enabled by certain type
PSV.AdsManager.IsAdsEnabled(AdType type)

/// Set GDPR Consent SDK Implementation for ads in session.
PSV.AdsManager.SetConsent(bool consent)

///Set dubug mode. Better for debug recomended set dummy in settings.
PSV.AdsManager.SetDebugMode(bool debug)

///Check is Ad by certain type is ready
 bool PSV.AdsManager.IsAdReady(AdType type)
``` 

### Banner
```csharp
///Get small banner lifecycle
SmallBannerAdLifecycle smallBannerLifecycle

///Show small banner
PSV.AdsManager.ShowSmallBanner(AdPosition ad_pos = AdPosition.Undefined)

/// Check is banner visible now
bool PSV.AdsManager.GetBannerVisible()

///Get current banner size
AdSize PSV.AdsManager.GetAdSize()

/// Get current banner size in pixels
Vector2 PSV.AdsManager.GetBannerSizeInPX()

///Get current banner position
AdPosition PSV.AdsManager.GetAdPos()

///Hide small banner
PSV.AdsManager.HideSmallBanner()

///Refresh small banner
PSV.AdsManager.RefreshSmallBannerForCurrentScene()

///Refresh banner with new params
PSV.AdsManager.RefreshSmallBanner(AdPosition ad_pos, AdSize ad_size)

``` 
 
Position by default - **Undefined**<br/>
Possible banner positions:

| |AdPosition| |
| --- | --- | --- |
| Top_Left | Top_Centered | Top_Right |
| Bottom_Right| Bottom_Center| Bottom_Right|

### Interstitial
```csharp
///Show Interstitial Ads banner.
PSV.AdsManager.ShowInterstitial()

///Show Interstitial Ads banner.
/// Return value indicates whether show the ads succeeded.
bool PSV.AdsManager.ShowInterstitial(bool ignore_delay = false)

/// Full-screen banner cached and ready to show.
bool PSV.AdsManager.IsInterstitialReady()

///The time delay after the last interstitial was passed.
bool PSV.AdsManager.IsInterDelayPassed()

///Waiting time after the last show until the next interstitial show
float PSV.AdsManager.GetInterDelayLeft()

///Is displayed right now full screen banner interstitial.
bool PSV.AdsManager.IsDisplayedInterstitial()

///Start delay between shown interstitial with the current time
PSV.AdsManager.ResetLastInterstitialTime()

///Set interval between possible interstitial call
PSV.AdsManager.SetInterstitialInterval(float seconds)

///Set delay between shown interstitial done
SetInterDelayDone()
```

Events:_ 
```csharp
⚡️ PSV.AdsManager.OnInterstitialClosed
⚡️ PSV.AdsManager.OnInterstitialShown
```

### Rewarded Video
```csharp
/// Rewarded video ad cached and ready to show.
bool PSV.AdsManager.IsRewardedReady()

/// The time delay after the last rewarded video ad was passed.
bool PSV.AdsManager.IsRewardedDelayPassed()

/// Waiting time after the last show until the next video show
float PSV.AdsManager.GetRewardedDelayLeft()

/// Start delay between shown rewarded with the current time
PSV.AdsManager.ResetLastRewardedTime()

///Set delay between shown rewarded video ad done
PSV.AdsManager.SetRewardedDelayDone()

/// Show rewarded video ad.
/// Before calling this method, subscribe to events like "OnRewardedComplete" 
/// After done or close rewarded, unsubscripted from events.
bool PSV.AdsManager.ShowRewardedVideoAd(bool ignore_delay = false)

/// Show rewarded video ad. 
/// One-time use actions without needed to unsubscripted.
/// Return value indicates whether show the video succeeded.
bool PSV.AdsManager.TryShowRewardedVideoAd(Action successful, Action fail, bool successOnAdDisabled = false, bool ignore_delay = false)

/// Is displayed right now rewarded ad video.
PSV.AdsManager.IsDisplayedRewardedVideo()

/// Show Rewarded. If Rewarded Video Ad can't be shown then show Interstitial Ad.
/// Method is ignored delay between shown Rewarded and Interstitial ad.
bool PSV.AdsManager.ShowRewardedElseInterAd(Action successful, Action fail, bool successOnAdDisabled = true)

```
Events:_

```csharp
⚡️ PSV.AdsManager.OnRewardedClosed
⚡️ PSV.AdsManager.OnRewardedComplete
⚡️ PSV.AdsManager.OnRewardedShown
```

## Support
Technical support: <br>
Max<br>
Skype: m.shevchenko_15 <br>

Network support: <br>
Vitaly<br>
Skype: zanzavital <br>
mailto:support@cleveradssolutions.com <br>
