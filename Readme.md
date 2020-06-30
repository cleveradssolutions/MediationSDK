# CleverAdsSolutions - Unity SDK Integration


## Before You Start  
**Support Unity versions: Unity 2017.4.24+; Unity 2018.4.X; Unity 2019.2.X**  
Please upgrade the intermediate versions to those that we support.  

Support Android OS Version 4.2 (API level 17) and up.
Support IOS Version 10.0 and up.

### AndroidX
As of SDK 18.0.0, AdMob migrated from Android Support Libraries to Jetpack (AndroidX) Libraries. Refer to the [Google Play services release notes](https://developers.google.com/android/guides/releases#june_17_2019) for more information.  

Due to this, we working with the AdMob adapter it’s required that your project migrates from Android Support Libraries to Jetpack Libraries (Android X) if you are using any. Please refer to [Migrating to AndroidX](https://developer.android.com/jetpack/androidx/migrate) for more information. 

In case you can not migrate the project using this tool, you can use the following flags in gradle.properties, to build your project using AndroidX. 
*  android.useAndroidX = true  
*  android.enableJetifier = true  

## Step 1 Add the CAS SDK to Your Project

[Download unitypackage from release page](https://github.com/cleveradssolutions/MediationSDK/releases/latest)   
Package contains all required modules for mediation.   
There must be no compillation errors for success automatic installation launcher.  
After import installer will be lauched automaticaly.   
Follow package installation instructions.  

Some Ad Networks target specific age ratings for your app’s content. Please select your content rating in application and follow the instructions.  
*  G - 0+ years. General audiences. Content suitable for all audiences, including families and children.  
*  PG - 7+ years. Parental guidance. Content suitable for most audiences with parental guidance, including topics like non-realistic, cartoonish violence.  
*  T - 12+ years. Teen. Content suitable for teen and older audiences, including topics such as general health, social networks, scary imagery, and fight sports.  
*  MA - 18+ years. Mature audiences. Content suitable only for mature audiences; includes topics such as alcohol, gambling, sexual content, and weapons.  
**You can be punished if you don’t comply with the partner’s content rating restrictions!**

### Step 2 Enable Gradle
Go to Build Settings -> Player Settings -> Publishing Settings and check Custom Gradle Template  
This will generate template gradle file inside Assets -> Plugins -> Android called mainTemplate.gradle  
After that, all the necessary gradle settings will be determined automatically on Build. 

### Step 3 Update AndroidManifest
Add the following permissions to your [Plugins/Android/AndroidManifest.xml](Assets/Plugins/Android/AndroidManifest.xml ), file inside the manifest tag but outside the <application> tag:
```xml
<manifest>
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
    <uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />
   
    <!--Optional Permissions-->
    
    <!--This permission is used for certain ads that vibrate during play. 
    This is a normal level permission, so this permission just needs to be defined in the manifest to enable this ad feature.-->
    <uses-permission android:name="android.permission.VIBRATE" />
    
    <!--This permission is used for certain ads that allow the user to save a screenshot to their phone. 
    Note that with this permission on devices running Android 6.0 (API 23) or higher, 
    this permission must be requested from the user. 
    See Requesting Permissions for more details. https://developer.android.com/training/permissions/requesting -->
    <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
    
    <!--This permission is not a mandatory permission, however, including it will enable accurate ad targeting-->
    <uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />
    ...
</manifest>
```
If you do not find the manifest file [Plugins/Android/AndroidManifest.xml](Assets/Plugins/Android/AndroidManifest.xml ), you can take it from the example.  

Some SDK may require a default permission, so please use the following lines to limit it.
```xml
<manifest>
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" tools:node="remove"/>
</manifest>
```

### Step 4 Add Cross Promotion SDK
Cross promotion is an app marketing strategy in which app developers promote one of their titles on another one of their titles. Cross promoting is especially effective for developers with large portfolios of games as a means to move users across titles and use the opportunity to scale each of their apps. This is most commonly used by hyper-casual publishers who have relatively low retention, and use cross promotion to keep users within their app portfolio.

Start your cross promotion campaign with CAS [here](https://cleveradssolutions.com).

### Additional Settings for iOS
In iOS9, Apple has added in controls around ‘ATS’. In order to ensure uninterrupted support for CAS Ad delivery across all Mediation Networks, it’s important to make the following changes in your info.plist:  
*  Add in a dictionary called ‘NSAppTransportSecurity‘. Make sure you add this dictionary on the ‘Top Level Key‘.  
*  Inside this dictionary, add a Boolean called ‘NSAllowsArbitraryLoads‘ and set it to YES.  

 >Note: Make sure that your info.plist does not contain any other exceptions besides ‘NSAllowsArbitraryLoads‘, as this might create a conflict.   
 
### ADS Settings
For settings editing go to Window -> PSV Ads Settings -> Android / iOS

| Option | Description |
| --- | --- |
| Update | Download config from server |
| Set Demo| Create testing configuration |
| Layers identified | On/Off ads types. Disable not used types to increase system performance. |
| Children tagged | Set forces sdk to filter ads with violence, drugs, etc. Can be changed by AdsSettings.SetTaggedForChildren. Enabled mode will reduces ad fill. |
| GDPR compiliance | Start user consent mode. Can be changed by AdsSettings.SetConsent. |
| Banner size | Start banner size |
| Interstital delay | Delay between interstitial can be shown (sec) |
| Refresh Banner | Refresh banner rate (sec) |
| Loading Mode | CAS loading mode |

If you want to use debug configuration select **Set Demo** otherwise for final release app must be connected to ads networks.    
Please [CONTACT](#support) us using skype or email below and send us Google Play app link.</b> Then you'll able select Update in PSV ADS Settings and refresh final configuration. 

In section <b>Publishing Settings</b> set <b>Custom Gradle Template</b>.  
After that config <b>mainTemplate</b> will be added to <b>Plugins/Android</b>.   
 
 ## GDPR Managing Consent
 CAS mediation platform supports publisher communication of a user’s consent choice to mediated networks.  
 A detailed article on the use of user data can be found in the [Privacy Policy](https://github.com/cleveradssolutions/CAS-Android/wiki/Privacy-Policy).

Recomended use mode: "Wait consent to 
 To use CAS API to update a user’s consent status, use this functions:  
 ```java
 PSV.AdsSettings.SetConsent(true);
 ```
 If the user provided consent, please set the following flag to true:  
 ```java
 PSV.AdsSettings.SetConsent(false);
 ```
 
 **It’s recommended to set the API prior to SDK Initialization.**
 
By default, the CAS SDK initializes app measurement with FALSE user consent and begin caching ads automatically.   
However, if your app requires user consent before these events can be sent, you can delay app measurement until you explicitly PSV.AdsSettings.SetConsent.  
To delay app measurement set "Wait consent to initialize" on  Window -> PSV Ads Settings -> Android / iOS GDPR compliance.

## Implement our Ad Units
CAS SDK is loading advertising content automatically after initialize.  
Therefore, you need to wait until the advertisement is ready for display.  

### Check Ad Availability
```csharp
bool ready = PSV.AdsManager.isAdReady(AdType.Interstitial); // Check any AdType
```

### Banner ad
```csharp
PSV.AdsManager.ShowSmallBanner(AdPosition.Bottom_Center);
```
For change the size or position the banner on screen use following code:
```csharp
PSV.AdsManager.RefreshSmallBanner(AdPosition.Bottom_Center, AdSize.Adaptive );
// OR change AdSize only
PSV.AdsManager.RefreshSmallBanner(AdPosition.Undefined, AdSize.Adaptive );
// OR change position only
PSV.AdsManager.RefreshSmallBanner(AdPosition.Bottom_Center, default(AdSize) );
```
For hide a banner from the screen using the following code:
```csharp
PSV.AdsManager.HideSmallBanner()
```

#### Adaptive Banner Size
Adaptive banners are the next generation of responsive ads, maximizing performance by optimizing ad size for each device.  
To pick the best ad size, adaptive banners use fixed aspect ratios instead of fixed heights. This results in banner ads that occupy a more consistent portion of the screen across devices and provide opportunities for improved performance. [You can read more in this article.](https://developers.google.com/admob/android/banner/adaptive)

### Interstitial Ad
Invoke the following method to show an Interstitial ad:  
```csharp
bool forceShow = false; // Set True for ignore timeout after previous show or initialize SDK.
PSV.AdsManager.ShowInterstitial(forece);
// OR
PSV.AdsManager.Show(AdType.Interstitial);
```
You can subscribe to Interstitial global events that are invoked for each impression:  
```csharp
PSV.AdsManager.OnInterstitialShown += () => { Debug.Log("Interstitial are shown") };
PSV.AdsManager.OnInterstitialClosed += () => { Debug.Log("Interstitial are closed") };
```

### Rewarded Video Ad
Rewarded Video Ad has such global events that are invoked for each impression:
```csharp
PSV.AdsManager.OnRewardedShown += () => { Debug.Log("Rewarded Ad are shown") };
PSV.AdsManager.OnRewardedClosed += () => { Debug.Log("Rewarded Ad are closed") };
PSV.AdsManager.OnRewardedComplete += () => { Debug.Log("Congratulations, you watched the video to the end. Get reward.") };
```
Invoke the following method to show an Rewarded Ad:  
```csharp
PSV.AdsManager.ShowRewardedVideoAd();
// OR
PSV.AdsManager.Show(AdType.Rewarded);
```
Or you can use callbacks only for the current impression:
```csharp
Action successful = () => { Debug.Log("Congratulations, you watched the video to the end. Get reward.") };
Action fail = () => { Debug.Log("Rewarded Ad are closed") };
bool successOnAdDisabled = false; // Set True for invoke 'successful' callback on Rewarded Ad type disabled.

PSV.AdsManager.TryShowRewardedVideoAd(successful, fail, successOnAdDisabled);
```
Sometimes there are situations when the rewarded video is not yet ready for display, but you need to show ads.  
Then you can use a special method to show Interstitial Ad on Rewarded not ready.  
Callbacks will be handled as if there was a successful ad serving.
```csharp
Action successful = () => { Debug.Log("Congratulations, you watched the video to the end. Get reward.") };
Action fail = () => { Debug.Log("Rewarded or Interstitial Ad are closed") };
bool successOnAdDisabled = false; // Set True for invoke 'successful' callback on Rewarded Ad type disabled.

PSV.AdsManager.ShowRewardedElseInterAd(successful, fail, successOnAdDisabled)
```

## Source
### AdsSettings
```csharp
// Is enabled forces sdk to filter ads with violence, drugs, etc
PSV.AdsSettings.IsTaggedForChildren()

// Set forces sdk to filter ads with violence, drugs, etc
PSV.AdsSettings.SetTaggedForChildren(bool forChildren)

// Is enabled forces SDK to request on family ads (poor fill rate).
// Not recomended for used, low fill rate.
PSV.AdsSettings.IsDesignedForFamilies()

// Set enabled forces SDK to request on family ads (poor fill rate).
// Not recomended for used, low fill rate.
PSV.AdsSettings.SetDesignedForFamilies(bool forFamilies)

// Get Content Rating 
PSV.AdsSettings.GetContentRating()

// Setting a maximum ad content rating
// Some types of ads may be more suitable for your app’s audience than others.
// Showing users ads that are a better fit can improve their overall ad experience and help maximize your app’s revenue.
// That rating will override any rating set in the AdMob user interface. 
PSV.AdsSettings.SetContentRating(ContentRating rating)

// Subscribe listener on content filters changed.
PSV.AdsSettings.AddFiltersListener(IListener listener)

// Unsubscribe listener on content filters changed.
PSV.AdsSettings.RemoveFiltersListener(IListener listener)

// Set GDPR user Consent SDK Implementation for ads on session.
PSV.AdsSettings.SetConsent(bool consent)

// Is wait SetConsent(bool)  call to begin initialize ADS.
// Return true only before initialize ads.
PSV.AdsSettings.SetConsent(bool consent)

// Get current state of GDPR user Consent SDK Implementation for ads on session.
PSV.AdsSettings.GetConsent()

// Set debug log mode for native mediation SDK
PSV.AdsSettings.SetNativeDebug(bool debug)

// Is debug log mode enabled for native mediation SDK
bool PSV.AdsSettings.IsNativeDebugEnabled()

// Set muted sounds in ads
PSV.AdsSettings.SetMutedAdSounds(bool muted)

// Is sounds muted in ads
bool PSV.AdsSettings.SetMutedAdSounds(bool muted)

// Delay between "AdType.Interstitial" impressions and after application launch
PSV.AdsSettings.SetInterstitialInterval(float seconds)

// Get delay between  "AdType.Interstitial"  impressions and after application launch
float PSV.AdsSettings.GetInterstitialInterval()

// Subscribe listener on options changed.
PSV.AdsSettings.AddOptionsListener(IOptionsListener listener)

// Unsubscribe listener on options changed.
PSV.AdsSettings.RemoveOptionsListener(IOptionsListener listener)

// Get Remote value by "remote_key_interstitial_delay" 
PSV.AdsSettings.RemoveOptionsListener(IOptionsListener listener)

// Get Remote value by "remote_key_rewarded_delay" 
float PSV.AdsSettings.RemoveOptionsListener(IOptionsListener listener)

// Get Remote value by key for selected "AdType" 
bool PSV.AdsSettings.IsAdTypeEnabled(AdType type, bool defaultValue)

// Get Remote value by "remote_key_collect_response_info" 
bool PSV.AdsSettings.IsCollectResponseInfo()
``` 

### AdsManager
```csharp
// Set available ad types to processing of "AdTypeFlags.Everything"
// This method will be leave <see cref="AdType.Rewarded"/> on set false argument.
// The state will be saved between sessions.
PSV.AdsManager.IsAdsProcessing(AdType type, bool enabled)

// Check available selected ad types.
bool PSV.AdsManager.IsAdsEnabled(AdTypeFlags types)

// Show ad by selected type and network. 
// AdNetwork name recomended use null for show high eCPM Ad.
bool PSV.AdsManager.Show(AdType type, string network = null)

// Check ready Ad type
bool PSV.AdsManager.IsAdReady(AdType type)

// Get last active mediation ad name of selected type.
// Can return "string.Empty".
string PSV.AdsManager.GetInfoLastActiveAd(AdType type)
``` 

## Adding App-ads txt file of our partners  
### "App-ads.txt: How to Make It & Why You Need It"

Last year, the ad tech industry struck back at one of its most elusive problems — widespread domain spoofing that let unauthorized developers sell premium inventory they didn’t actually have. The solution? Over two million developers adopted ads.txt — a simple-text public record of Authorized Digital Sellers for a particular publisher’s inventory — to make sure they didn’t lose money from DSPs and programmatic buyers who avoid noncompliant publishers. Thanks to buyers’ ability to [crawl ads.txt and verify seller authenticity](https://iabtechlab.com/ads-txt-about/), this has quickly become a standard for protecting brands. Ad fraud reduced by 11% in 2019 due to these efforts and publisher’s ability to implement more fraud prevention techniques.  

The time has come for ads.text to evolve in-app. The introduction of apps-ads.txt is an important method for mobile app devs to similarly eliminate fraud and improve transparency.

### What is app-ads.txt?

Like ads.txt, apps-ads.txt is a text file that app devs upload to their publisher website. It lists all ad sources authorized to sell that publisher’s inventory. [The IAB created a system](https://iabtechlab.com/press-releases/app-ads-txt-released-for-public-comment-as-next-step-to-fight-digital-advertising-inventory-fraud/) that allows buyers to distinguish the authorized sellers for specific in-app inventory, weeding out the undesirables.

### How does app-ads.txt work for mobile apps?

A DSP wanting to bid on an app’s inventory crawls the app-ads.txt file on a developer’s website to verify which ad sources are authorized to sell that app’s inventory. The DSP will only accept bid requests from ad sources listed on the file and authorized by the app developer.

### How does app-ads.txt help mobile app developers capture more ad revenue?

**Authorized in-app inventory**. An ever-increasing amount of brands are looking to advertise in-app today. Brand buyers now rely on an adherence to app-ads.txt to make sure they don’t buy unauthorized inventory from app developers and negatively impact campaign performance. Developers who don’t implement app-ads.txt can be removed from any brand buyer’s target media list. That’s why joining the app-ads.txt movement is crucial for publishers to maintain their revenue.

**Ad fraud prevention**. App-ads.txt blocks unauthorized developers who impersonate legitimate apps and mislead DSPs into spending brand budgets on fake inventory. With fraud instances minimized, authentic developers can retain more of the ad revenue from inventory genuinely targeted to their app.

### How do I create an app-ads.txt?

You must list your **Developer Website URL** in the GooglePlay and iTunes app stores. There must be a valid developer website URL in all app stores hosting your apps.

Make sure that your publisher website URL (not app specific URL)  is added in your app store listings. Advertising platforms will use this site to verify the app-ads.txt file.

We have made it easier for you to include CAS list of entries so that don’t have to construct it on your own. Please copy and paste the following text block and include in your txt file along with entries you may have from your other monetization partners:  
**[App-ads.txt](https://cleveradssolutions.com/app-ads.txt)** Updated 30.06.2020

## Mediation partners:
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
* [InMobi](https://www.inmobi.com)  
* [Facebook Audience](https://www.facebook.com/business/marketing/audience-network)  
* [Yandex Ad](https://yandex.ru/dev/mobile-ads)  

## Support
Technical support: Max  
Skype: m.shevchenko_15  

Network support: Vitaly  
Skype: zanzavital  

mailto:support@cleveradssolutions.com  
