using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartScript : MonoBehaviour
{
    public GameObject[] playerCam;
    public GameObject losecavasBG;
    public int bulletshot;
    public Text bulletShotText;

    public int HeadShots;
    public Text HeadshotsText;

    public Text enemyKillsText;
    public Text enemyKillsText2;


    public Text TotalScoreText;
    public Text TotalScoreText2;

    public Text Percentage;
    public Text Percentage2;
    public Image PercentageImage1;
    public Image PercentageImage2;



    public AudioSource audioSource;
    public AudioClip[] audio;
    public float percentageLevel;
    public int enemyKills = 0;
    public int TotalScore;
    public GameObject spectateCanvas;
    public int Score;
    public GPMultiplayer multiplayerscript;
    public GameObject backCanvas;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(backCanvas.activeInHierarchy == true)
            {
                backCanvas.SetActive(false);
            }
            else
            {
                backCanvas.SetActive(true);
            }
        }
    }

    public void TurnOnCam(int camNumber)
    {
        losecavasBG.SetActive(false);
        for (int i = 0; i < playerCam.Length; i++)
        {
            playerCam[i].SetActive(false);
        }
        playerCam[camNumber].SetActive(true);
        
        spectateCanvas.SetActive(true);
        
        audioSource.clip = audio[0];
        audioSource.Play();
    }

    public void bulletamountShowLose()
    {
        if (multiplayerscript.versusEnabled == false) {
            //  bulletShotText.text = "Bullets Shot: "+ bulletshot.ToString();
            percentageLevel = (enemyKills / 48f) * 100f;
            enemyKillsText.text = "Kills: " + enemyKills.ToString();
            TotalScore = (1500) - (bulletshot);
            TotalScoreText.text = "Total Score: " + TotalScore.ToString();
            percentageLevel = (int)percentageLevel;
            Percentage.text = percentageLevel.ToString() + "% Completed";
            PercentageImage1.fillAmount = percentageLevel / 100f;
            Score = PlayerPrefs.GetInt("MainScore");
            Score += TotalScore;
            PlayerPrefs.SetInt("MainScore", Score);
        }
        else if (multiplayerscript.versusEnabled == true)            {
            enemyKillsText.text = "Assassination Failed";
            TotalScore = (enemyKills * 50) - (bulletshot);
            TotalScoreText.text = "Total Score: " + TotalScore.ToString();
            percentageLevel = (int)percentageLevel;
            Percentage.text = "YOU LOSE";
            PercentageImage1.fillAmount = 0;
            Score = PlayerPrefs.GetInt("MainScore");
            Score += TotalScore;
            PlayerPrefs.SetInt("MainScore", Score);
            }
    }
    public void bulletamountShowWin()
    {
        if (multiplayerscript.versusEnabled == false)
        {

            percentageLevel = (enemyKills / 48) * 100;
            percentageLevel = (int)percentageLevel;

            Percentage2.text = percentageLevel.ToString() + "% Completed";
            PercentageImage2.fillAmount = percentageLevel / 100f;
            enemyKillsText2.text = "Kills: " + enemyKills.ToString();
            TotalScore = (enemyKills * 200) - (bulletshot);
            TotalScoreText2.text = "Total Score: " + TotalScore.ToString();
            HeadshotsText.text = "Head Shots: " + HeadShots.ToString();
            Score = PlayerPrefs.GetInt("MainScore");
            Score += TotalScore;
            PlayerPrefs.SetInt("MainScore", Score);
        }
        else if (multiplayerscript.versusEnabled == true)
        {
            

            Percentage2.text = "YOU WIN";
            PercentageImage2.fillAmount = 1f;
            enemyKillsText2.text = "Assassination Successful";
            TotalScore = (100 * 200) - (bulletshot);
            TotalScoreText2.text = "Total Score: " + TotalScore.ToString();
            HeadshotsText.text = "Head Shots: " + HeadShots.ToString();
            Score = PlayerPrefs.GetInt("MainScore");
            Score += TotalScore;
            PlayerPrefs.SetInt("MainScore", Score);
        }
        }
    public void restartButton()
    {
        this.multiplayerscript.left();
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");

    }


}