using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menuController : MonoBehaviour
{
    //Menus
    public GameObject menuMain;
    public GameObject menuArmoury;
    public GameObject menuIssue;
    public GameObject LevelType;
    public GameObject menuLevelTeam;
    public GameObject menuLevelVS;
    public GameObject MurrayClgMenuLevelTeam;
    public GameObject MurrayClgMenuLevelVS;
    public GameObject SaroshClgMenuLevelVS;
    public GameObject SaroshClgMenuLevelTeam;
    public Image Item;  //Item Main Image (Guns/Armour etc)
    public Text SelectedGunName;    //name of Selected Item
    public int Score;   //MainScore
    public Text MainScore;

    //Armoury Select Gun/Armour/Granade
    public int SelectionChoise;

    //Gun Sprites

    public int GunNumber;
    public Sprite[] GunSprites;
    public Image[] GunStatsImage;
    public Image[] GunStatsImageMax;


    //rmour/Health Sprites

    public int ArmourNumber;
    public Sprite[] Armoursprites;
    public Image[] ArmourStatsImage;
    public Image[] ArmourStatsImageMax;



    //Gun Saved Preferences
    public int[] GunDamage;
    public int[] GunRange;

    public Image LevelPicM;
    public Sprite[] LevelSpritesM;
    public int a = 0, b = 0;
    public Text LevelInfoM;
    public string[] infoMsg;
    public string[] levelName;


    public Image LevelPicS;
    public Sprite[] LevelSpritesS;
    public int aS = 0, bS = 0;
    public Text LevelInfoS;

    public GameObject MusicController;
    public Image musicImage;
    public Sprite[] musicSprite;
    public Text levelNameText;
    public Text remainingScoreNeededText;
    public GameObject remainingScoreNeededCanvas;
    // Start is called before the first frame update
    void Start()
    {
        a = 0;
        b = 0;
        aS = 0;
        bS = 0;
        GunDamage = new int[4];
        GunRange = new int[4];
        infoMsg = new string[4];
        levelName = new string[4];
        infoMsg[0] = "Unleash your adrenaline. Rush through the armed militants, killing them in-order to free this block.";
        infoMsg[1] = "Put the pedal to the metal. Rush through the armed militants, killing them in-order to free this block.";
        infoMsg[2] = "Gear up for the Next Level! Face More Armed Militants and defeat them.";
        infoMsg[3] = "Gather your allys for this action packed level where there is very less to hide and very less to run to.";

        levelName[0] = "BS OFFICE";
        levelName[1] = "INTERMEDIATE BLOCK";
        levelName[2] = "BBA BLOCK";
        levelName[3] = "OPEN GROUND";

        CheckMainScore();
        menuArmoury.SetActive(false);
        menuIssue.SetActive(false);
        menuLevelTeam.SetActive(false);
        menuLevelVS.SetActive(false);
        //Show Latest Changes
        ChangeGun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void music()
    {
        if (MusicController.activeInHierarchy == false) {
            MusicController.SetActive(true);
            musicImage.sprite = musicSprite[0];

        }
        else
        {
            MusicController.SetActive(false);
            musicImage.sprite = musicSprite[1];

        }

    }
    public void OpenLevelType()
    {
        menuMain.SetActive(false);
        LevelType.SetActive(true);
    }
    public void team()
    {
        menuLevelTeam.SetActive(true);
    }
    public void vs()
    {
        menuLevelVS.SetActive(true);

    }
    public void NextLevelM()
    {
        a++;
        b++;
        if (a > LevelSpritesM.Length-1)
        {
            a = 0;
            b = 0;
        }
        LevelPicM.sprite = LevelSpritesM[a];
        LevelInfoM.text = infoMsg[b];
        levelNameText.text = levelName[a].ToString();
    }
        public void PreviousLevelM()
        {
            a--;
            b--;
            if (a < 0)
            {
                a = LevelSpritesM.Length-1;
                b = LevelSpritesM.Length - 1;

            }
        LevelPicM.sprite = LevelSpritesM[a];
        LevelInfoM.text = infoMsg[b];
        levelNameText.text = levelName[a].ToString();

    }




    public void NextLevelS()
    {
        aS++;
        bS++;
        if (aS > LevelSpritesS.Length - 1)
        {
            aS = 0;
            bS = 0;
        }
        LevelPicS.sprite = LevelSpritesS[aS];
        LevelInfoS.text = infoMsg[bS];
    }
    public void PreviousLevelS()
    {
        aS--;
        bS--;
        if (aS < 0)
        {
            aS = LevelSpritesS.Length - 1;
            bS = LevelSpritesS.Length - 1;

        }
        LevelPicS.sprite = LevelSpritesS[aS];
        LevelInfoS.text = infoMsg[bS];

    }
    public void coOpLevelMVS()
    {
        if (a == 0)
        {
            SceneManager.LoadScene("LevelOneVS");

        }
        else if (a == 1)
        {
            SceneManager.LoadScene("LevelTwoVS");

        }
        else if (a == 2)
        {
            SceneManager.LoadScene("LevelThreeVS");

        }
        else if (a == 3)
        {
            SceneManager.LoadScene("LevelFourVS");

        }

    }
    public void coOpLevelMTeam()
    {
        if (a == 0)
        {
            SceneManager.LoadScene("LevelOne");

        }
        else if (a == 1)
        {
            SceneManager.LoadScene("LevelTwo");

        }
        else if (a == 2)
        {
            SceneManager.LoadScene("LevelThree");

        }
        else if (a == 3)
        {
            SceneManager.LoadScene("LevelFour");

        }

    }

    public void coOpLevelSVS()
    {
        if (aS == 0)
        {
            SceneManager.LoadScene("LevelOne2VS");

        }
        else if (aS == 1)
        {
            SceneManager.LoadScene("LevelOne2VS");

        }
        else if (aS == 2)
        {
            SceneManager.LoadScene("LevelThreeVS");

        }
        else if (aS == 3)
        {
            SceneManager.LoadScene("LevelFourVS");

        }

    }
    public void coOpLevelSTeam()
    {
        if (aS == 0)
        {
            SceneManager.LoadScene("LevelOne2");

        }
        else if (aS == 1)
        {
            SceneManager.LoadScene("LevelOne2");

        }
        else if (aS == 2)
        {
            SceneManager.LoadScene("LevelThree");

        }
        else if (aS == 3)
        {
            SceneManager.LoadScene("LevelFour");

        }

    }
    //if MainScore is not created (i.e Player is New), it creates MainScore
    public void CheckMainScore()
    {
        Score = PlayerPrefs.GetInt("MainScore");
        if (Score == 0)
        {
            PlayerPrefs.SetInt("MainScore", 0);

        }
        for (int i = 0; i <= 3; i++)
        {
            LoadSpec(i);
        }

    }
    public void SelectionChoiseFunctionGun()
    {
        SelectionChoise = 0;
    }
    public void SelectionChoiseFunctionArmour()
    {
        SelectionChoise = 1;
    }

    public void OpenMenuArmoury()
    {
        menuMain.SetActive(false);

        menuArmoury.SetActive(true);
        Score = PlayerPrefs.GetInt("MainScore");

        MainScore.text = "Cash: " + Score.ToString();
    }

    public void OpenMenuIssue()
    {
      //  menuIssue.SetActive(true);
    }
   
    public void OpenMurrayClgMenuTeam()
    {
        menuMain.SetActive(false);

        MurrayClgMenuLevelTeam.SetActive(true);
    }
    public void OpenSaroshClgMenuTeam()
    {
        menuMain.SetActive(false);

        SaroshClgMenuLevelTeam.SetActive(true);
    }
    public void OpenMurrayClgMenuVS()
    {
        menuMain.SetActive(false);

        MurrayClgMenuLevelVS.SetActive(true);
    }
    public void OpenSaroshClgMenuVS()
    {
        menuMain.SetActive(false);

        SaroshClgMenuLevelVS.SetActive(true);
    }
    public void OpenMainMenu()
    {
        menuArmoury.SetActive(false);
        menuIssue.SetActive(false);
        menuLevelTeam.SetActive(false);
        menuLevelVS.SetActive(false);
        LevelType.SetActive(false);
        MurrayClgMenuLevelTeam.SetActive(false);
        MurrayClgMenuLevelVS.SetActive(false);
        SaroshClgMenuLevelTeam.SetActive(false);
        SaroshClgMenuLevelVS.SetActive(false);

        menuMain.SetActive(true);
    }

    //Armoury Section

    //1: Change Gun (Next)
    public void nextGun()
    {
        GunNumber++;
        ChangeGun();
        Score = PlayerPrefs.GetInt("MainScore");


    }
    public void previousGun()
    {
        GunNumber--;
        ChangeGun();
        Score = PlayerPrefs.GetInt("MainScore");


    }
    public void ChangeGun()
    {
        MainScore.text = "Cash: " + Score.ToString();

        if (SelectionChoise == 0)
        {
            if (GunNumber >= GunSprites.Length)
            {
                GunNumber = 0;
            }
            if (GunNumber <0)
            {
                GunNumber = 3;
            }
            Item.sprite = GunSprites[GunNumber];
            if (GunSprites[GunNumber].name == "ak47")
            {
                SelectedGunName.text = "AK-47";
                LoadSpec(0);
                //Current Status of Gun
                GunStatsImage[0].fillAmount = (float)(GunDamage[GunNumber]/100f);
                GunStatsImage[1].fillAmount = (float)(GunRange[GunNumber] / 100f);
                //Max Upgradable Length
                GunStatsImageMax[0].fillAmount = 50f/100f;
                GunStatsImageMax[1].fillAmount = 40f / 100f;

                Debug.Log(GunRange[GunNumber]);
            }
            if (GunSprites[GunNumber].name == "rifle")
            {
                SelectedGunName.text = "RIFLE";

                LoadSpec(1);

                GunStatsImage[0].fillAmount = (float)(GunDamage[GunNumber]/100f);
                GunStatsImage[1].fillAmount = (float)(GunRange[GunNumber] / 100f);
                //Max Upgradable Length
                GunStatsImageMax[0].fillAmount = 60f / 100f;
                GunStatsImageMax[1].fillAmount = 50f / 100f;

                Debug.Log(GunRange[GunNumber]);

            } if (GunSprites[GunNumber].name == "Shotgun")
            {
                SelectedGunName.text = "SHOTGUN";

                LoadSpec(2);

                GunStatsImage[0].fillAmount = (float)(GunDamage[GunNumber]/100f);
                GunStatsImage[1].fillAmount = (float)(GunRange[GunNumber] / 100f);
                //Max Upgradable Length
                GunStatsImageMax[0].fillAmount = 70f / 100f;
                GunStatsImageMax[1].fillAmount = 60f / 100f;
                Debug.Log(GunRange[GunNumber]);

            } if (GunSprites[GunNumber].name == "sniper")
            {
                SelectedGunName.text = "SNIPER";

                LoadSpec(3);

                GunStatsImage[0].fillAmount = (float)(GunDamage[GunNumber]/100f);
                GunStatsImage[1].fillAmount = (float)(GunRange[GunNumber] / 100f);
                //Max Upgradable Length
                GunStatsImageMax[0].fillAmount = 90f / 100f;
                GunStatsImageMax[1].fillAmount = 90f / 100f;
                Debug.Log(GunRange[GunNumber]);

            }
        }
        if (SelectionChoise == 1)
        {
            ArmourNumber++;
            if (ArmourNumber >= Armoursprites.Length)
            {
                ArmourNumber = 0;
            }
            Item.sprite = Armoursprites[ArmourNumber];
        }

    }

    public void LoadSpec(int gunNumber)
    {
        if (gunNumber == 0)
        {
            GunDamage[0] = PlayerPrefs.GetInt("ak47Damage",0);
            GunRange[0] = PlayerPrefs.GetInt("ak47Range", 0);
            if (GunDamage[0] == 0)
            {
                PlayerPrefs.SetInt("ak47Damage", 45);
                PlayerPrefs.SetInt("ak47Range", 20);


            }
            GunDamage[0] = PlayerPrefs.GetInt("ak47Damage", 0);
            GunRange[0] = PlayerPrefs.GetInt("ak47Range", 0);

        }
        if (gunNumber == 1)
        {
            GunDamage[1] = PlayerPrefs.GetInt("rifleDamage", 0);
            GunRange[1] = PlayerPrefs.GetInt("rifleRange", 0);

            if (GunDamage[1] == 0)
            {
                PlayerPrefs.SetInt("rifleDamage", 50);
                PlayerPrefs.SetInt("rifleRange", 40);


            }
            GunDamage[1] = PlayerPrefs.GetInt("rifleDamage", 0);
            GunRange[1] = PlayerPrefs.GetInt("rifleRange", 0);


        }

        if (gunNumber == 2)
        {
            GunDamage[2] = PlayerPrefs.GetInt("ShotgunDamage", 0);
            GunRange[2] = PlayerPrefs.GetInt("ShotgunRange", 0);
            if (GunDamage[2] == 0)
            {
                PlayerPrefs.SetInt("ShotgunDamage", 60);
                PlayerPrefs.SetInt("ShotgunRange", 50);

            }
            GunDamage[2] = PlayerPrefs.GetInt("ShotgunDamage", 0);
            GunRange[2] = PlayerPrefs.GetInt("ShotgunRange", 0);

        }
        if (gunNumber == 3)
        {
            GunDamage[3] = PlayerPrefs.GetInt("sniperDamage", 0);
            GunRange[3] = PlayerPrefs.GetInt("sniperRange", 0);
            if (GunDamage[3] == 0)
            {
                PlayerPrefs.SetInt("sniperDamage", 80);
                PlayerPrefs.SetInt("sniperRange", 80);


            }
            GunDamage[3] = PlayerPrefs.GetInt("sniperDamage", 0);
            GunRange[3] = PlayerPrefs.GetInt("sniperRange", 0);

        }
      
    }
    public void RemainingScoreNeeded(int S)
    {
        PlayerPrefs.GetInt("MainScore", Score);
        remainingScoreNeededText.text = (S - Score).ToString()+ " COINS";
    }
    public void closeRemainingScoreNeeded()
    {
        remainingScoreNeededCanvas.SetActive(false);
    }

    //Upgrade Selected Weapon
    public void UpgradeItem()
    {

        if (GunNumber == 0)
        {
            if (GunDamage[0] == 60)
            {

            }
            else if (GunDamage[0] == 45)
            {


                if (Score >= 1000)
                {
                    PlayerPrefs.SetInt("ak47Damage", 50);
                    PlayerPrefs.SetInt("ak47Range", 40);
                    Score -= 1000;
                    PlayerPrefs.SetInt("MainScore", Score);
                    ChangeGun();
                }
                else
                {
                    remainingScoreNeededCanvas.SetActive(true);

                    RemainingScoreNeeded(1000);
                }
            }
        }
       
        if (GunNumber == 1)
        {
            if (GunDamage[1] == 60)
            {

            }
            else if (GunDamage[1] == 50)
            {
                if (Score >= 2000)
                {
                    PlayerPrefs.SetInt("rifleDamage", 60);
                    PlayerPrefs.SetInt("rifleRange", 50);
                    Score -= 2000;
                    PlayerPrefs.SetInt("MainScore", Score);
                    ChangeGun();

                }
                else
                {
                    remainingScoreNeededCanvas.SetActive(true);

                    RemainingScoreNeeded(2000);
                }
            }
        }
       
        if (GunNumber == 2)
        {
            if (GunDamage[2] == 70)
            {

            }
            else if (GunDamage[2] == 60)
            {
                if (Score >= 3000)
                {
                    PlayerPrefs.SetInt("ShotgunDamage", 70);
                    PlayerPrefs.SetInt("ShotgunRange", 60);
                    Score -= 3000;
                    PlayerPrefs.SetInt("MainScore", Score);
                    ChangeGun();

                }
                else
                {
                    remainingScoreNeededCanvas.SetActive(true);

                    RemainingScoreNeeded(3000);
                }
            }
        }

        if (GunNumber == 3)
        {
            if (GunDamage[3] == 90)
            {

            }
            else if (GunDamage[3] == 80)
            {
                if (Score >= 4000)
                {
                    PlayerPrefs.SetInt("sniperDamage", 90);
                    PlayerPrefs.SetInt("sniperRange", 90);
                    Score -= 4000;
                    PlayerPrefs.SetInt("MainScore", Score);
                    ChangeGun();

                }
                else
                {
                    remainingScoreNeededCanvas.SetActive(true);

                    RemainingScoreNeeded(4000);
                }
            }
        
        }
        
    }
}
