using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAdsButton Instance { get; private set; }

    [SerializeField]
    private string _androidAdUnitId = "Rewarded_Android";
    [SerializeField]
    private string _iOsAdUnitId = "Rewarded_iOs";
    private string _adUnitId;
    private bool isAdLoaded = false;

    [SerializeField]
    private Button _showAdButton;

    private void Awake()
    {
        Instance = this;
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _adUnitId = _iOsAdUnitId;
        }
        else
        {
            _adUnitId = _androidAdUnitId;
        }
        _showAdButton.interactable = false;
        _showAdButton.onClick.AddListener(ShowAd);
        StartCoroutine(WaitBeforeShowingNextAd());
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad loading is complete");
        isAdLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading ad unit: {_adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("The ad is finished");
        if (placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            GameController.Instance.AddCoins(100);
        }
        LoadAd();
        StartCoroutine(WaitBeforeShowingNextAd());
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing ad unit: {_adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Advertisement has started loading...");
    }

    private IEnumerator WaitBeforeShowingNextAd()
    {
        yield return new WaitForSeconds(3);

        yield return new WaitUntil(() => isAdLoaded);

        _showAdButton.interactable = true;
    }

    public void LoadAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd() 
    {
        _showAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);
    }
}
