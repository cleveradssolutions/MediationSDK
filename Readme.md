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

## Supported Unity versions
*  Unity 2017.4.24+
*  Unity 2018.4.X

###  Android 
*  MinSdkVersion 16  
*  Gradle 3.2.0+  
*  useAndroidX = true  
*  enableJetifier = true  

### IOS
* Min OS 10.0

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
///Is enabled forces sdk to filter ads with violence, drugs, etc
PSV.AdsSettings.IsTaggedForChildren()

/// Set forces sdk to filter ads with violence, drugs, etc
PSV.AdsSettings.SetTaggedForChildren(bool forChildren)

/// Is enabled forces SDK to request on family ads (poor fill rate).
/// Not recomended for used, low fill rate.
PSV.AdsSettings.IsDesignedForFamilies()

/// Set enabled forces SDK to request on family ads (poor fill rate).
/// Not recomended for used, low fill rate.
PSV.AdsSettings.SetDesignedForFamilies(bool forFamilies)

///Get Content Rating 
PSV.AdsSettings.GetContentRating()

/// Setting a maximum ad content rating
/// Some types of ads may be more suitable for your app’s audience than others.
/// Showing users ads that are a better fit can improve their overall ad experience and help maximize your app’s revenue.
/// That rating will override any rating set in the AdMob user interface. 
PSV.AdsSettings.SetContentRating(ContentRating rating)

/// Subscribe listener on content filters changed.
PSV.AdsSettings.AddFiltersListener(IListener listener)

/// Unsubscribe listener on content filters changed.
PSV.AdsSettings.RemoveFiltersListener(IListener listener)

/// Set GDPR user Consent SDK Implementation for ads on session.
PSV.AdsSettings.SetConsent(bool consent)

/// Is wait SetConsent(bool)  call to begin initialize ADS.
/// Return true only before initialize ads.
PSV.AdsSettings.SetConsent(bool consent)

/// Get current state of GDPR user Consent SDK Implementation for ads on session.
PSV.AdsSettings.GetConsent()

/// Set debug log mode for native mediation SDK
PSV.AdsSettings.SetNativeDebug(bool debug)

/// Is debug log mode enabled for native mediation SDK
bool PSV.AdsSettings.IsNativeDebugEnabled()

/// Set muted sounds in ads
PSV.AdsSettings.SetMutedAdSounds(bool muted)

/// Is sounds muted in ads
bool PSV.AdsSettings.SetMutedAdSounds(bool muted)

/// Delay between "AdType.Interstitial" impressions
/// and after application launch
PSV.AdsSettings.SetInterstitialInterval(float seconds)

/// Get delay between  "AdType.Interstitial"  impressions
/// and after application launch
float PSV.AdsSettings.GetInterstitialInterval()

/// Delay between  AdType.Rewarded impressions
/// and after application launch
PSV.AdsSettings.SetRewardedVideoInterval(float seconds)

/// Get delay between  "AdType.Rewarded"  impressions
/// and after application launch
float PSV.AdsSettings.GetRewardedVideoInterval()

/// Subscribe listener on options changed.
PSV.AdsSettings.AddOptionsListener(IOptionsListener listener)

/// Unsubscribe listener on options changed.
PSV.AdsSettings.RemoveOptionsListener(IOptionsListener listener)

/// Get Remote value by "remote_key_interstitial_delay" 
PSV.AdsSettings.RemoveOptionsListener(IOptionsListener listener)

/// Get Remote value by "remote_key_rewarded_delay" 
float PSV.AdsSettings.RemoveOptionsListener(IOptionsListener listener)

/// Get Remote value by key for selected "AdType" 
bool PSV.AdsSettings.IsAdTypeEnabled(AdType type, bool defaultValue)

/// Get Remote value by "remote_key_collect_response_info" 
bool PSV.AdsSettings.IsCollectResponseInfo()


``` 
### AdsManager
```csharp
/// Set available ad types to processing of "AdTypeFlags.Everything"
/// This method will be leave <see cref="AdType.Rewarded"/> on set false argument.
/// The state will be saved between sessions.
/// Recommended use "EnableAdTypes(AdTypeFlags)"
/// OR "DisableAdTypes(AdTypeFlags)" instead to check the selected type.
PSV.AdsManager.SetAdsEnabled(bool param)
 
/// Check available any ad types.
/// Recommended use <see cref="IsAdsEnabled(AdTypeFlags)"/> instead to check the selected type.
/// OR "IsAdsProcessing(AdType)" to validate currently processing and caching of ad type.
bool PSV.AdsManager.IsAdsEnabled()
 
/// Check available selected ad types.
/// To find out currently enabled processing and caching of ad type use <see cref="IsAdsProcessing(AdType)"/>
bool PSV.AdsManager.IsAdsEnabled(AdTypeFlags types)

/// Check currently processing and caching of selected ad type.
bool PSV.AdsManager.IsAdsProcessing(AdType type)

/// Set available ad types to processing of selected types.
/// The state will be saved between sessions.
/// For set available of all types use <see cref="AdTypeFlags.Everything"/>
PSV.AdsManager.EnableAdTypes(AdTypeFlags types)

/// Set NOT available ad types to processing of selected types.
/// The state will be saved between sessions.
/// For set NOT available of all types use <see cref="AdTypeFlags.Everything"/>
PSV.AdsManager.DisableAdTypes(AdTypeFlags types)

/// Force show ad by selected type and network. 
/// Ignored delay between displayed ad.
bool PSV.AdsManager.Show(AdType type, string network = null)

/// Check ready
bool PSV.AdsManager.IsAdReady(AdType type)

/// Get last active mediation ad name of selected type.
/// Can return "string.Empty".
string PSV.AdsManager.GetInfoLastActiveAd(AdType type)

``` 

#### Banner
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

#### Interstitial
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

#### Rewarded Video
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
