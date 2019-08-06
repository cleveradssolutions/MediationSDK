## Description 📖
**Mediation Library contains:**
* Ads SDK:
1. AppLovin
1. Chartbooks
1. InMobiAds
1. KIDOZ
1. UnityAds
1. Vungle
1. AdColony
1. Startapp
1. SuperAwesome
1. Facebook Audience

## Supported Unity
*  Min version Unity 2017.4 (gradle update reqired)
*  Recomended Unity 2018.4+
*  Android MinSdkVersion 16  
*  Gradle 3.2.0  
*  useAndroidX = true  
*  enableJetifier = true  

## Installation ⚙️
### 1. Download unitypackage.
[В разделе Release](https://github.com/cleveradssolutions/MediationSDK/releases/latest)  
Package contains all required modules for mediation. <br>
### 2. SDK Installer.
After import installer will be lauched automaticaly. <br>

![ads_android_setting](http://drive.google.com/uc?export=view&id=14EE42oMzu4gUNqp0k5ozqvh8KJO-NZkQ)

There must be no compillation errors for success automatic installation launcher. Otherwise you can lauch installer manually or manually import all requireв packages from Assets/PSV/MediationInstaller.

![image](https://drive.google.com/uc?export=view&id=14DCo0I8rFFJgesQ0fAZPFcbR6INchVOV)

Installation process:

1. Install DLL Basement for Unity 2017 or 2018+ (Require)
1. Install main Mediation SDK of networks (Require)
1. Install Play Service Resolver (Require)
1. Clean Assets (Require)

<b>Important!</b>
For successful work gradle 3.2.0 required! If you using Unity 2018.3 and less you should check you gradle version. Go to

<b>"*Unity Folder*\Editor\Data\PlaybackEngines\AndroidPlayer\Tools\GradleTemplates"</b> 

in file  <b>mainTemplate.gradle</b>  you will find line with version  

<b>"classpath 'com.android.tools.build:gradle:3.2.0'"</b> . 

If your gradle version less than 3.2.0 you'l have to update gradle manually or use newer Unity version.
 
### 3. Setup.
Для просмотра настроек нужно перейти в Window -> PSV Ads Settings -> Android / IOs

![ads_android_setting](http://drive.google.com/uc?export=view&id=1dCyMybCKjIBRBpYpQKivhCkqQqQzqW0C)

|Action|Description|
| --- | --- |
| Update | Выгружает конфигурацию с сервера|
| Set Dummy| Создает конфигурацию для теста|
| Layers identified | Вкл/Откл типы рекламных обьявлений |
| Interstital delay | Задержка между возможным показом interstital (сек) |

В разделе Build Settings необходимо выставить Build System -> Gradle.
 
![image](https://drive.google.com/uc?export=view&id=1BxWC8Ic3gvUxK5NeN16Ifwuu5dsmlvOA)

В разделе Publishing Settings необходимо выставить Custom Gradle Template. 

![image](https://drive.google.com/uc?export=view&id=1TiqVJbkK9u06uTmAtWNOrFkX45um2-OD)

После этого библиотеки в папки Plugins/Android будут заменены на конфиг mainTemplate. 

![image](https://drive.google.com/uc?export=view&id=1pmKf2gZ_iPDgxgEvgBnegFcUkivxp0jw)
 
### Все готово.
Теперь Вы можете использовать медиацию у себя в проекте 😊


## Functions
### Banner
```csharp
PSV.AdsManager.ShowSmallBanner()
/// Show in a certain place
PSV.AdsManager.ShowSmallBanner(ad_pos = AdPosition.Top_Centered) 
PSV.AdsManager.HideSmallBanner()
``` 
Позиция по умолчанию - **Undefined**<br/>
Возможные позиции баннера:

| |AdPosition| |
| --- | --- | --- |
| Top_Left | Top_Centered | Top_Right |
| Middle_Left| Middle_Centered| Middle_Right|
| Bottom_Right| Bottom_Center| Bottom_Right|

### Interstitial
```csharp
PSV.AdsManager.ShowInterstitial()
/// Full-screen banner cached and ready to show.
PSV.AdsManager.IsInterstitialReady()
/// The time delay after the last interstitial was passed.
PSV.AdsManager.IsInterDelayPassed()
/// Start delay between shown interstitial with the current time.
PSV.AdsManager.ResetLastInterstitialTime()
/// Is displayed right now full screen banner interstitial.
PSV.AdsManager.IsDisplayedInterstitial()
```

_События:_ 
```csharp
⚡️ PSV.AdsManager.OnInterstitialClosed
⚡️ PSV.AdsManager.OnInterstitialShown
```

### Rewarded Video
```csharp
PSV.AdsManager.TryShowRewardedVideoAd()
/// Rewarded video ad cached and ready to show.
PSV.AdsManager.IsRewardedReady()
/// The time delay after the last rewarded video ad was passed.
PSV.AdsManager.IsRewardedDelayPassed()
/// Start delay between shown rewarded with the current time.
PSV.AdsManager.ResetLastRewardedTime()
/// Is displayed right now rewarded ad video.
PSV.AdsManager.IsDisplayedRewardedVideo()
/// Show Rewarded. If Rewarded Video Ad can't be shown then show Interstitial Ad.
/// Method is ignored delay between shown Rewarded and Interstitial ad.
PSV.AdsManager.ShowRewardedElseInterAd()
```
_События:_

```csharp
⚡️ PSV.AdsManager.OnRewardedClosed
⚡️ PSV.AdsManager.OnRewardedComplete
⚡️ PSV.AdsManager.OnRewardedShown
```
