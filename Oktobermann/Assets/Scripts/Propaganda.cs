using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class Propaganda : MonoBehaviour
{
    public string placementId = "rewardedVideo";

    string gameId = "3090471";
    bool testMode = false;


    void Start()
    {
       
        if (Monetization.isSupported)
        {
            Monetization.Initialize(gameId, testMode);
        }
    }

    public void ShowAd()
    {
        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
        ad.Show(options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            // Reward the player
            GetComponent<GameController>().RecompensarJogador();
            //Debug.Log("Ficou Rico");
        }
        else if (result == ShowResult.Skipped)
        {
            //Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            //Debug.LogError("Video failed to show");
        }
    }

    /////
    ///
    public string placementId2 = "video";

    public void ShowAd2()
    {
        StartCoroutine(ShowAdWhenReady());
    }

    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementId2))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId2) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
        }
    }













    /*
    public string placementId = "video";

    public void ShowAd () {
        StartCoroutine (ShowAdWhenReady ());
        Advertisement.Show ();
    }

    private IEnumerator ShowAdWhenReady () {
        while (!Monetization.IsReady (placementId)) {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;

        if(ad != null) {
            ad.Show ();
        }
    }

    //Propaganda com recompensa para o programador\\

    public string placementId2 = "rewardedVideo";

    public void ShowAd2 () {
        StartCoroutine (WaitForAd ());
    }

    IEnumerator WaitForAd () {
        while (!Monetization.IsReady (placementId2)) {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (placementId2) as ShowAdPlacementContent;

        if (ad != null) {
            ad.Show (AdFinished);
        }
    }
    //Recompensa para o jogador\\
    void AdFinished (ShowResult result) {
        if (result == ShowResult.Finished) {
            // Reward the player
            Debug.Log("JOGADOR FICOU RICO!");
            GetComponent<GameController>().RecompensarJogador();
        }
    }*/
}
