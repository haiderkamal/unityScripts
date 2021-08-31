using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DataInserter : MonoBehaviour {
    /*
    public InputField Selfname;
   
	
    public string name;
    public string country;
    public string score;
    public int HighScore;
    public int curScore;
    public int playerID = 1;
    public GameObject LoginCanvas;
    public GameObject infoimage;
    public DataLoader loader;
    public GameObject popup;
    public DataLoader leader;
    public GameObject leaderboardd;

    public Text info;

    string updatee = "http://sourcehouse.org/www/UpdatePlayer.php";
    string create = "http://sourcehouse.org/www/addPlayer.php";

    void Start()
    {
        popup.SetActive(false);
        LoginCanvas.SetActive(false);
        findName();
        setHighscore();
        uploadScore();
        
    }
    public void retrievee(int scoreR)
    {
        curScore = scoreR;

    
    }
    public void closeleaderboard()
    {
        leaderboardd.SetActive(false);

    }
    public void LoginCanvasfunction()
    {
        if (name == "" && country == "")
        {
            LoginCanvas.SetActive(true);
        }
        else
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("no Internet");
            }
            else
            {
                leaderboardd.SetActive(true);

                leader.RetrieveLeaderBoard();
            }
        }
    }
    public void LoginCanvasOfffunction()
    {
        leaderboardd.SetActive(false);
    }
        public void findName()
    {
        name = PlayerPrefs.GetString("name");
        country = PlayerPrefs.GetString("country");
      
        if (name == "" && country == "")
        {
            popup.SetActive(true);
           // LoginCanvas.SetActive(true);

        }
        else
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("no Internet");
            }
            else
            {
              //  StartCoroutine(onetimeUpload());

            }

        }
        infoimage.SetActive(true);
        info.text = name.ToString();


    }
    public void MulLogin(){
        country = PlayerPrefs.GetString("country");
        name = Selfname.text;
        

        PlayerPrefs.SetString("name", name);

        StartCoroutine(onetimeUpload());

        LoginCanvas.SetActive(false);
    }
    public void setHighscore()
    {
        HighScore = PlayerPrefs.GetInt("Storedscorerr");
        if (HighScore <= 0)
        {
            HighScore = 0;
            PlayerPrefs.SetInt("Storedscorerr", HighScore);
        }
    }
    public void uploadScore()
    {

       // curScore = PlayerPrefs.GetInt("scorerr");
        HighScore = PlayerPrefs.GetInt("Storedscorerr");
        if (curScore > HighScore)
        {

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                PlayerPrefs.SetInt("Storedscorerr", curScore);
            }
            else
            {
                PlayerPrefs.SetInt("Storedscorerr", curScore);
                StartCoroutine(updateScore());
            }

        }
    }

    IEnumerator onetimeUpload()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no Internet");
        }
        else
        {

            // Create a Web Form
            var form = new WWWForm();
            form.AddField("np", name);
            form.AddField("cp", country);

            HighScore = PlayerPrefs.GetInt("Storedscorerr");
            form.AddField("sp", HighScore);

            Debug.Log("submitting " + form + " to " + create);
            WWW request = new WWW(create, form);
            yield return request;

            findName();

            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.Log(request + " error:\n" + request.error);
            }
            else
            {
                Debug.Log("Sent " + request + " successfully, result:\n" + request.text + "datainserter");
            }
        }
    }

    IEnumerator updateScore()
    {

        // Create a Web Form
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no Internet");
        }
        else
        {
            var form = new WWWForm();

            form.AddField("np", name);
            form.AddField("cp", country);

            HighScore = PlayerPrefs.GetInt("Storedscorerr");
            Debug.Log(HighScore);
            form.AddField("sp", HighScore);
            Debug.Log("submitting " + form + " to " + updatee);
            WWW request = new WWW(updatee, form);
            yield return request;
            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.Log(request + " error:\n" + request.error);
            }
            else
            {
                Debug.Log("Sent " + request + " successfully, result:\n" + request.text + "datainserter");
            }
        }
    }
    */
   
}
 
     
         
     
 
   
 
