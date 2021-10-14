// using GoogleMobileAds.Api;
// using System;
// using System.Collections;
// using UnityEngine;

// public class ADManager : MonoBehaviour
// {
	// public static string App_ID = "ca-app-pub-9727856365139576~2698371525";

	// public static string banner_ID = "ca-app-pub-9727856365139576/2778262572";

	// public static string Interstitial_ID = "ca-app-pub-9727856365139576/4638139157";

	// public static string Reward_ID = "";

	// private static BannerView bannerAd;

	// private static InterstitialAd InterstitialAd;

	// private static RewardBasedVideoAd rewardAd;

	// private void Start()
	// {
		// MobileAds.Initialize(App_ID);
		// RequestInterstitialAd();
	// }

	// private void RequestBannerAd()
	// {
		// bannerAd = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);
		// AdRequest request = new AdRequest.Builder().Build();
		// bannerAd.OnAdLoaded += HandleOnAdLoaded;
		// bannerAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// bannerAd.OnAdOpening += HandleOnAdOpened;
		// bannerAd.OnAdClosed += HandleOnAdClosed;
		// bannerAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
		// bannerAd.LoadAd(request);
	// }

	// private static void RequestInterstitialAd()
	// {
		// InterstitialAd = new InterstitialAd(Interstitial_ID);
		// AdRequest request = new AdRequest.Builder().Build();
		// InterstitialAd.LoadAd(request);
	// }

	// private void RequestRewardedVideoAd()
	// {
		// rewardAd = RewardBasedVideoAd.Instance;
		// AdRequest request = new AdRequest.Builder().Build();
		// rewardAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
		// rewardAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		// rewardAd.OnAdOpening += HandleRewardBasedVideoOpened;
		// rewardAd.OnAdStarted += HandleRewardBasedVideoStarted;
		// rewardAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
		// rewardAd.OnAdClosed += HandleRewardBasedVideoClosed;
		// rewardAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
		// rewardAd.LoadAd(request, Reward_ID);
	// }

	// public static void Display_Banner()
	// {
		// bannerAd.Show();
	// }

	// public static void Display_InterstitialAd()
	// {
		// if (InterstitialAd.IsLoaded())
		// {
			// InterstitialAd.Show();
		// }
		// else
		// {
			// RequestInterstitialAd();
		// }
	// }

	// public static void Display_RewardVideoAd()
	// {
		// if (rewardAd.IsLoaded())
		// {
			// rewardAd.Show();
		// }
	// }

	// public void HandleOnAdLoaded(object sender, EventArgs args)
	// {
		// Display_Banner();
	// }

	// public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	// {
		// StartCoroutine(RE_RequestBanner());
	// }

	// private IEnumerator RE_RequestBanner()
	// {
		// yield return new WaitForSeconds(3f);
		// RequestBannerAd();
	// }

	// public void HandleOnAdOpened(object sender, EventArgs args)
	// {
	// }

	// public void HandleOnAdClosed(object sender, EventArgs args)
	// {
	// }

	// public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	// {
	// }

	// public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	// {
	// }

	// public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	// {
		// StartCoroutine(RE_RequestRewarded());
	// }

	// private IEnumerator RE_RequestRewarded()
	// {
		// yield return new WaitForSeconds(3f);
		// RequestRewardedVideoAd();
	// }

	// public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	// {
	// }

	// public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	// {
	// }

	// public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	// {
	// }

	// public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	// {
	// }

	// public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	// {
	// }
// }
