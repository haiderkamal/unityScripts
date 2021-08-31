using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playfabManager : MonoBehaviour
{
    public Text[] LeaderboardListScore;
    public Text[] LeaderboardListName;
    public int i;
    public GameObject LeaderBoardCanvas;
    public GameObject ShopCanvas;
    public Image SwordBG;
    public Text LoginInText;
    public int swordNumberMenu;
    public Sprite[] swordPics;
    public Image swordPic;
    public Image SwordStateAgility;
    public Image SwordStateDamage;
    public Text SwordName;
    public bool shopcancasactive;
    public menuControllerScript menuScript;
    public InputField iField;
    public GameObject facebookCanvas;
    public String name;
    public bool mainplayerAllowLeaderboard;
    public mainPlayer mainPlayerScript;
    public int Max;
    public String FBName;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LeaderBoardCanvas.SetActive(false);
            ShopCanvas.SetActive(false);
        }
        swordNumberMenu = 0;
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Debug.LogWarning("Connected to WiFi or Carrier network");
            Login();
        }
       
       // Invoke("GetLeaderboard", 4f);
    }
    public void Update()
    {
        if (shopcancasactive == true) { SwordBG.transform.Rotate(Vector3.forward * -0.03f); }
        
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error while Loggin in/creating account");
        Debug.Log(error.GenerateErrorReport());
        LoginInText.text = ("Please Check Internet");
    }

    private void OnSuccess(LoginResult result)
    {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                LoginInText.text = ("Connection Successfull, Welcome: " + result.PlayFabId);
            }
            Debug.Log("Successfull Login/account create");
            name = null;
            if (result.InfoResultPayload.PlayerProfile != null)
            {
                name = result.InfoResultPayload.PlayerProfile.DisplayName;
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    facebook(name);
                    Getname();
                }
            }
            if (name == null)
            {
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    if (SceneManager.GetActiveScene().buildIndex == 0)
                    {
                        facebookCanvas.SetActive(true);
                    }
                }
            }
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                GetLeaderboard();
                 
            }
            else
            {
                // LeaderBoardCanvas.SetActive(true);
            }
            //Getname();
         
    }
    public void SubmitName(string name)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = name
        };
        FBName = name;
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdtate, OnError);
    }
    public void OnDisplayNameUpdtate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated Name");
        facebook(FBName);
        
        //facebookCanvas.SetActive(false);
    }
    public void SendLeaderBoard(int score)
    {
         
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, Onleaderboardupdate2, OnError);
    }

   void Onleaderboardupdate2(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfully sent LeaderBoard");
    }
    public void GetLeaderboard()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Max = 10;
        }
        else
        {
            Max = 50;
        }
            var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = Max
            };
        PlayFabClientAPI.GetLeaderboard(request, OnleaderboardGet, OnError);
    }
    public void GetShop()
    {
        ShopCanvas.SetActive(true);
        shopcancasactive = true;
        menuScript.loadCurrentCoins();
    }
    public void removeLeaderboard()
    {
        shopcancasactive = false;
        LeaderBoardCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
    }
    public void exitgame()
    {
        Application.Quit();
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("betaLevel1");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("mainMenu1");
    }
    void OnleaderboardGet(GetLeaderboardResult result)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LeaderBoardCanvas.SetActive(true);
        }
        foreach (var item in result.Leaderboard)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                string s = item.StatValue.ToString();
                LeaderboardListScore[i].text = s;
                string n = item.DisplayName.ToString();
                LeaderboardListName[i].text = n;
                i++;
                Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
            }
            else
            {
                int s = item.StatValue;
                mainPlayerScript.leaderboardPeepsScore[i] = s;
                string n = item.DisplayName.ToString();
                mainPlayerScript.leaderboardPeeps[i] = n;
                i++;
                
            }
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
           // Invoke("invokingLeadernoardSort", 4);
        
        }
            i = 0;
    }
    public void invokingLeadernoardSort()
    {
       // mainPlayerScript.sortLeaderboard();
    }
    public void swordChangeNext()
    {
        swordNumberMenu++;
        if (swordNumberMenu > 3)
        {
            swordNumberMenu = 0;
            swordPic.sprite = swordPics[0];
        }
        else
        {
            swordPic.sprite = swordPics[swordNumberMenu];
        }
        swordStatsSet(swordNumberMenu);


    }
    public void swordChangeBack()
    {
        swordNumberMenu--;
        if (swordNumberMenu < 0)
        {
            swordNumberMenu = 3;
            swordPic.sprite = swordPics[3];
        }
        else
        {
            swordPic.sprite = swordPics[swordNumberMenu];
        }
        swordStatsSet(swordNumberMenu);
    }
    public void swordStatsSet(int num)
    {
        if(num == 0)
        {
            SwordName.text = "Sword Of Azkaban";
            SwordStateAgility.fillAmount = 0.2f;
            SwordStateDamage.fillAmount = 0.4f;
        }if(num == 1)
        {
            SwordName.text = "Sword Of Dead Island";
            SwordStateAgility.fillAmount = 0.4f;
            SwordStateDamage.fillAmount = 0.6f;
        }if(num == 2)
        {
            SwordName.text = "Sword Of Exchantment";
            SwordStateAgility.fillAmount = 0.6f;
            SwordStateDamage.fillAmount = 0.8f;
        }if(num == 3)
        {
            SwordName.text = "Sword Of King Thor";
            SwordStateAgility.fillAmount = 0.8f;
            SwordStateDamage.fillAmount = 1f;
        }
        menuScript.buttonTextChange(num);
    }
    public void buyNow()
    {
        menuScript.buySword(swordNumberMenu);
    }
    public void facebook(string name1)
    {
        
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Name", name1}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, Error);
    }

    private void Error(PlayFabError error)
    {
       
    }

    private void OnDataSend(UpdateUserDataResult resut)
    {
        Debug.Log("Seccessfull Data Send");

       // facebookCanvas.SetActive(false);
        Getname();
    }
    public void facebookshow()
    {
        facebookCanvas.SetActive(true);
    }public void facebookhide()
    {
        facebookCanvas.SetActive(false);
    }
    public void Getname()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }
    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved Data");
        if(result.Data !=null && result.Data.ContainsKey("Name"))
        {
            LoginInText.text = ("Connection Successfull, Welcome: " + result.Data["Name"].Value);
        }
        else if (result.Data == null)
        {
            facebookshow();
        }
    }
}
 
