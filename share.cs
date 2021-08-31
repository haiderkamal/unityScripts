
using UnityEngine;
using System.Collections;
using System.IO;
 
public class share : MonoBehaviour {
 
    private bool isProcessing = false;
    private bool isFocus = false;
    public restartscript resss;
    public GameObject losescreen;
    public snakemovements mainnn;

    void Start() {
        mainnn = GameObject.FindGameObjectWithTag("mainsnakeo").GetComponent<snakemovements>();
        resss = GameObject.FindGameObjectWithTag("res").GetComponent<restartscript>();
    }
    public void ShareBtnPress()
    {
        if (!isProcessing)
        {
            mainnn.count *= 2;
            losescreen.SetActive(false);
            StartCoroutine(ShareScreenshot());
            resss.restartgame();
        }
    }
 
    IEnumerator ShareScreenshot()
    {
        isProcessing = true;
 
        yield return new WaitForEndOfFrame();
 
        ScreenCapture.CaptureScreenshot("screenshot.png", 2);
        string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");
 
        yield return new WaitForSecondsRealtime(0.3f);
 
        if (!Application.isEditor)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
                uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                "Can you beat my score? Download & Play Now https://play.google.com/store/apps/details?id=com.HKSTUDIOS.SnakeStar");
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);
 
            yield return new WaitForSecondsRealtime(1);
        }
 
        yield return new WaitUntil(() => isFocus);
        losescreen.SetActive(false);
        isProcessing = false;
    }
 
    private void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }
}