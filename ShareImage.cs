using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
public class ShareImage : MonoBehaviour
{
    
       


    public Button shareButton;

    private bool isFocus = false;
    private bool isProcessing = false;

    public void OnShareButtonClick()
    {
        ShareText();
    }
  
  
        
        void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }

    private void ShareText()
    {
        Debug.Log("sharing");

           // StartCoroutine(ShareTextInAnroid());
       
    }



#if UNITY_ANDROID
    public IEnumerator ShareTextInAnroid()
    {

        var shareSubject = "The Best Game I seen\n";
        var shareMessage = "JUST PLAY IT , it's my Promise You love it \n\n" +
                           "https://play.google.com/store/apps/details?id=com.HKSTUDIOS.SnakeStar3d1";

        isProcessing = true;

        if (!Application.isEditor)
        {
            //Create intent for action send
            AndroidJavaClass intentClass =
                new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject =
                new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>
                ("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

            //put text and subject extra
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>
                ("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
            intentObject.Call<AndroidJavaObject>
                ("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

            //call createChooser method of activity class
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity =
                unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser =
                intentClass.CallStatic<AndroidJavaObject>
                ("createChooser", intentObject, "Share your high score");
            currentActivity.Call("startActivity", chooser);
        }

        yield return new WaitUntil(() => isFocus);
        isProcessing = false;
    }
#endif
}