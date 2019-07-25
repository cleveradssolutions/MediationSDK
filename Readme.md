# CleverAdsSolutions
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
Пакет содержит все необходимые модули для работы медиации. <br>
### 2. Установщик SDK Installer.
После импорта пакета автоматически запуститься установщик. <br>

![ads_android_setting](http://drive.google.com/uc?export=view&id=14EE42oMzu4gUNqp0k5ozqvh8KJO-NZkQ)

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
ShowSmallBanner()
/// Show in a certain place
ShowSmallBanner(ad_pos = AdPosition.Top_Centered) 
HideSmallBanner()
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
ShowInterstitial()
/// Full-screen banner cached and ready to show.
IsInterstitialReady()
/// The time delay after the last interstitial was passed.
IsInterDelayPassed()
/// Start delay between shown interstitial with the current time.
ResetLastInterstitialTime()
/// Is displayed right now full screen banner interstitial.
IsDisplayedInterstitial()
```

_События:_ 
```csharp
⚡️ OnInterstitialClosed
⚡️ OnInterstitialShown
```

### Rewarded Video
```csharp
TryShowRewardedVideoAd()
/// Rewarded video ad cached and ready to show.
IsRewardedReady()
/// The time delay after the last rewarded video ad was passed.
IsRewardedDelayPassed()
/// Start delay between shown rewarded with the current time.
ResetLastRewardedTime()
/// Is displayed right now rewarded ad video.
IsDisplayedRewardedVideo()
/// Show Rewarded. If Rewarded Video Ad can't be shown then show Interstitial Ad.
/// Method is ignored delay between shown Rewarded and Interstitial ad.
ShowRewardedElseInterAd()
```
_События:_

```csharp
⚡️ OnRewardedClosed
⚡️ OnRewardedComplete
⚡️ OnRewardedShown
```
