## Описание 📖
**Mediation Library содержит:**
* SDK рекламных площадок:
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
*  Минимальная версия Unity 2017

## Installation ⚙️
### 1. Скачать unitypackage.
[В разделе Release](https://github.com/cleveradssolutions/MediationSDK/releases/latest)  
Пакет содержит все необходимые модули для работы медиации. <br>
### 2. Установщик SDK Installer.
После импорта пакета автоматически запуститься установщик. <br>

![ads_android_setting](http://drive.google.com/uc?export=view&id=14EE42oMzu4gUNqp0k5ozqvh8KJO-NZkQ)

В случае если установка не запустилась автоматически либо была прервана установку можно продолжить запустив принудительно.

![image](https://drive.google.com/uc?export=view&id=14DCo0I8rFFJgesQ0fAZPFcbR6INchVOV)

Процесс установки:

1. Install DLL Basement for Unity 2017 or 2018+ (Require)
1. Install main Mediation SDK of networks (Require)
1. Install Play Service Resolver (Require)
1. Clean Assets (Require)

### 3. Настройка.
Для просмотра настроек нужно перейти в Window -> PSV Ads Settings -> Android / IOs

![ads_android_setting](http://drive.google.com/uc?export=view&id=1dCyMybCKjIBRBpYpQKivhCkqQqQzqW0C)

|Action|Description|
| --- | --- |
| Update | Выгружает конфигурацию с сервера|
| Set Dummy| Создает конфигурацию для теста|
| Layers identified | Вкл/Откл типы рекламных обьявлений |

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
