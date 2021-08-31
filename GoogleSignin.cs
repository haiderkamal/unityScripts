using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GoogleSignin : MonoBehaviour
{
    public GameObject SignInSucces;
    public GameObject SignInError;
    public Text Username;
    public Image UserPic;
    public Texture2D tex;
    public GameObject[] MainMenuItems;
    public Image signInImage;
    public Text signInName;
    public Image upperInfoImage;
    public Image signInBG;
    public Sprite signinTick;
    // Start is called before the first frame update

    void Start()
    {
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        //PlayGamesPlatform.InitializeInstance(config);
        //PlayGamesPlatform.Activate();
        //SignInFunction();
        this.MainMenuItems = GameObject.FindGameObjectsWithTag("MainMenuItem");

    }
    public void SignInFunction(){

    

       

        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                SignInSucces.SetActive(true);
                Username.text = Social.localUser.userName;
               
                tex = Social.localUser.image;
                UserPic.sprite = Sprite.Create(tex ,new Rect(0, 0, tex.width, tex.height), Vector2.zero);
                upperInfoImage.sprite = signinTick;
                signInBG.color = new Color(72f, 255f, 72f);
                signInName.text = Social.localUser.userName;
            }
            else
            {
               // SignInError.SetActive(true);
               
            }
        });
    }
    public void SignInSuccesMenuClose()
    {
        SignInSucces.SetActive(false);

    }
    public void SignInErrorMenuClose()
    {
        SignInError.SetActive(false);

    }

    public void coOpLevel1()
    {
         Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                SceneManager.LoadScene("LevelOne");
            }
             else
            {

               // SignInError.SetActive(true);
               
            }
        });
    }
    public void coOpLevel2()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                SceneManager.LoadScene("LevelTwo");
            }
            else
            {

               // SignInError.SetActive(true);

            }
        });
    }
    public void HideMenus()
    {
        for (int i = 0; i < MainMenuItems.Length; i++)
        {

            MainMenuItems[i].SetActive(false);
        }
    }
    public void ShowMyLeaderboard()
    {

        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {

            // show specific leaderboard UI
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI58OU1ukQEAIQAQ");


        }
        else
        {
            Debug.Log("Cannot show Leaderboard, not logged in");
        }
    }
    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("Cannot show Achievements, not logged in");
        }
    }
}
