using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class unityads : MonoBehaviour
{
 /*
    public snakemovements script;
    public TimeBody timeb;
    private string gameId = "ca-app-pub-7906655820945626/5259512181";
    public Text message;
    public Button AdButton;
    public string placementId = "rewardedVideo";

    void Start()
    {
        
        script = GameObject.FindGameObjectWithTag("mainsnakeo").GetComponent<snakemovements>();
        timeb = GameObject.FindGameObjectWithTag("timebody").GetComponent<TimeBody>();
     //   if (Advertisement.isSupported)
        //{
       //     Advertisement.Initialize(gameId, false);
        //}
      
    }

    void Update()
    {
        //if (AdButton) AdButton.interactable = Advertisement.IsReady(placementId);
     
    }

    public void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show(placementId, options);
        Start();
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");
                    timeb.rewinder();
                    script.diebool = false;
                    script.scorer += 20;
                    script.SaveCount();
           
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");
            message.text = "Hey Smarty Pants... We know you Skiped the Reward Ad.";

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
            message.text = "I think the Internet is down Right?";
        }
    }
 */
}