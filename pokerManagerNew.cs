using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class pokerManagerNew : MonoBehaviour
{
    public Sprite[] Deck;
    public Image[] playerCards;
    public Image[] AICards;
    public Image[] CenterCards;

    public String[] playerCardsString;
    public String[] CenterCardsString;
    public String[] AICardsString;


    public int[] loadedCards;
    public int randomCard;
    public int loadedCardsNum;

    public int PlayerCoins;
    public int PlayerBidOfferCoins;

    public int AICoins;
    public int AIBidOfferCoins;

    public int InBidCoins;
    public int startBid;

    public int raise;

    public Text playerCoinsT;
    public Text aiCoinsT;

    public Text aiBidOfferT;
    public Text PlayerBidOfferT;

    public Text inbidCoinsT;
    public GameObject loadingImage;
    public bool player;
    public bool firstTurn;
    public bool secondTurn;

    public Text callORCheck;
    public bool CheckBool;
    public bool CheckBoolcnf;
    public bool Threecards;
    public bool Fourcards;
    public bool Fivecards;
    public String[] CardTypes;
    public String[] AICardsStringHolder;
    public String[] PlayerCardsStringHolder;
    public String[] CenterCardsStringHolder;
    public bool game;

    public int[] playerHand;
    public int[] AIhand;
    public int[] centerhand;

    public int playerHandScore;
    public int AIHandscore;

 
    public int isFirstTime;


    public void LoadGame()
    {
       
        if (!PlayerPrefs.HasKey("firstGame"))
        {
            PlayerCoins = 1000;
            AICoins = 1000;
            playerCoinsT.text = PlayerCoins.ToString();
            aiCoinsT.text = AICoins.ToString();
            PlayerPrefs.SetInt("firstGame", 0);
            PlayerPrefs.Save();
            isFirstTime = 1;
        }
        else
        {
            PlayerCoins = PlayerPrefs.GetInt("pcoins");
            AICoins = PlayerPrefs.GetInt("aicoins");
            playerCoinsT.text = PlayerCoins.ToString();
            aiCoinsT.text = AICoins.ToString();
            isFirstTime = 0;
        }
    }
    public void saveGame()
    {
        PlayerPrefs.SetInt("pcoins", PlayerCoins);
        PlayerPrefs.SetInt("aicoins", AICoins);
        PlayerPrefs.Save();

    }


    void Start()
    {
       

        LoadGame();
        loadedCards = new int[11];
        playerCardsString = new String[2];
        playerHand = new int[2];
        CenterCardsString = new String[5];
        AICardsString = new String[2];
        AICardsStringHolder = new String[2];
        PlayerCardsStringHolder = new String[2];
        loadedCardsNum = 0;
        
        startBid = 50;
        raise = 10;
        player = false;
        firstTurn = true;
        secondTurn = true;
        game = true;
        CardTypes = new String[] { "cardSpades", "cardDiamonds", "cardHearts", "cardClubs" };
        LoadCards();
        randomCardP();
        randomCardA();
        randomCardC();
        Invoke("AIBetOffer", 1f);
    }
    void LoadCards()
    {
        object[] loadedCards = Resources.LoadAll("playingcards", typeof(Sprite));
        Deck = new Sprite[loadedCards.Length];
        //this
        for (int x = 0; x < loadedCards.Length; x++)
        {
            Deck[x] = (Sprite)loadedCards[x];
        }
    }
    public void randomCardP()
    {
        //Player
        for (int i = 0; i < 2; i++)
        {
            Debug.Log(i);
            randomCard = UnityEngine.Random.Range(0, 51);

            int pos = Array.IndexOf(loadedCards, randomCard);
            if (pos > -1)
            {
                if (loadedCardsNum > 0)
                {
                    loadedCardsNum--;
                }
                randomCardP();
                Debug.Log(pos);
            }
            else
            {

                loadedCards[loadedCardsNum] = randomCard;
                loadedCardsNum++;

                playerCards[i].sprite = Deck[randomCard];
            }
        }
    }
    public void randomCardA()
    {
        //AI
        for (int i = 0; i < 2; i++)
        {
            randomCard = UnityEngine.Random.Range(0, 51);

            int pos = Array.IndexOf(loadedCards, randomCard);
            if (pos > -1)
            {
                if (loadedCardsNum > 1)
                {
                    loadedCardsNum--;
                }
                randomCardA();

            }
            else
            {
                loadedCards[loadedCardsNum] = randomCard;
                loadedCardsNum++;

                AICards[i].sprite = Deck[randomCard];

            }
            showAICards();
        }
    }
    public void showAICards()
    {
        int card = 0;
        for (int i = 2; i < 4; i++)
        {
            AICards[card].sprite = Deck[loadedCards[i]];
            card++;
        }
    }

    public void show3CenterCards()
    {
        int card = 0;
        for (int i = 4; i < 7; i++)
        {
            CenterCards[card].sprite = Deck[loadedCards[i]];
            card++;
        }
    }
    public void show4thCenterCard()
    {

        CenterCards[3].sprite = Deck[loadedCards[7]];
        Fourcards = false;
        CenterCardsString[3] = Deck[loadedCards[7]].name.ToString();
        for (int jj = 0; jj < 4; jj++)
        {
            CenterCardsStringHolder[3] = (String)CenterCardsStringHolder[3].Replace((String)CardTypes[jj], "");
        }
    }
    public void show5thCenterCard()
    {

        CenterCards[4].sprite = Deck[loadedCards[8]];
        CenterCardsString[4] = Deck[loadedCards[8]].name.ToString();
        Fivecards = false;
        player = false;
        game = false;
        Invoke("result", 1f);
        
    }
    public void randomCardC()
    {
        int i = 0;
        loadedCardsNum = 4;
        //Center
        for (i = 0; i < 5; i++)
        {
            randomCard = UnityEngine.Random.Range(0, 51);

            int pos = Array.IndexOf(loadedCards, randomCard);
            if (pos > -1)
            {



                Debug.Log("Same Found");
                randomCardC();
                break;

            }
            else
            {
                //Debug.Log("Center: " + i);
                loadedCards[loadedCardsNum] = randomCard;
                loadedCardsNum++;

                //CenterCards[i].sprite = Deck[randomCard];
                //show3CenterCards();
                //show4thCenterCard();
                //show5thCenterCard();
            }
        }
    }
    public void initialBetting()
    {
        /*
         InBidCoins += startBid;
         AICoins -= startBid;
         InBidCoins += startBid;
         playerCoinsT.text = PlayerCoins.ToString();
         aiCoinsT.text = AICoins.ToString();
         inbidCoinsT.text = InBidCoins.ToString();
         loadingImage.SetActive(false);
        */
    }
    public void AIBetOffer()
    {

        AIBidOfferCoins = 50;


        aiBidOfferT.text = "Betting: " + AIBidOfferCoins;
        player = true;
    }
    public void call()
    {
        if (AIBidOfferCoins > 0)
        {
            if (CheckBoolcnf == false)
            {
                CheckBool = false;
            }

        }
        else
        {
            CheckBool = true;
        }
        if (player)
        {
            if (CheckBool == false) //CALL
            {
                PlayerCoins -= AIBidOfferCoins;
                //AIBidOfferCoins = PlayerBidOfferCoins;
                InBidCoins += AIBidOfferCoins * 2;
                PlayerBidOfferT.text = "Call: " + AIBidOfferCoins;
                callORCheck.text = "CALL";
                player = false;
                AICoins -= AIBidOfferCoins;
                CheckBoolcnf = false;
                Invoke("UpdateInBidCoins", 1f);

                if (!secondTurn)
                {
                    Fivecards = true;
                    show5thCenterCard();
                }
                if (!firstTurn)
                {
                    Fourcards = true;
                    show4thCenterCard();
                    secondTurn = false;
                }
            }
            else if (CheckBool == true) //CHECK
            {
                if (!secondTurn)
                {
                    Fivecards = true;
                    show5thCenterCard();
                }
                if (!firstTurn)
                {
                    Fourcards = true;
                    show4thCenterCard();
                    secondTurn = false;
                }
                callORCheck.text = "CHECK";
                player = false;
                CheckBoolcnf = false;
                Invoke("UpdateInBidCoins", 1f);
            }
        }

    }
    public void UpdateInBidCoins()
    {
        playerCoinsT.text = PlayerCoins.ToString();
        aiCoinsT.text = AICoins.ToString();

        PlayerBidOfferT.text = "";
        aiBidOfferT.text = "";


        if (firstTurn)
        {
            show3CenterCards();
            Threecards = true;
            firstTurn = false;
        }
        CheckBoard();
        inbidCoinsT.text = InBidCoins.ToString();
    }
    public void checkshow()
    {
        aiBidOfferT.text = "Check";
        //AICoins -= PlayerBidOfferCoins;
        //InBidCoins += PlayerBidOfferCoins;
        player = true;
        callORCheck.text = "CHECK";
        CheckBool = true;
        CheckBoolcnf = true;
        Invoke("UpdateInBidCoins", 1f);
    }
    public void raiseBidPlus()
    {
        if (player == true)
        {
            //PlayerCoins -= 50;
            //playerCoinsT.text = PlayerCoins.ToString();

            PlayerBidOfferCoins += 50;
            PlayerBidOfferT.text = "Raise: " + PlayerBidOfferCoins;
        }

    }
    public void raiseBidMinus()
    {
        if (player == true)
        {
            //PlayerCoins += 50;
            //playerCoinsT.text = PlayerCoins.ToString();
            PlayerBidOfferCoins -= 50;
            playerCoinsT.text = PlayerCoins.ToString();

            PlayerBidOfferT.text = "Raise: " + PlayerBidOfferCoins;
        }
    }
    public void startRaiseBidP()
    {
        if (player == true)
        {
            Invoke("raiseBid", 1f);
        }
    }
    public void raiseBidAI(int courage)
    {
        if (courage == 0)
        {

            Invoke("checkshow", 1f);

        }
        else if (courage == 1)
        {
            int choise = UnityEngine.Random.Range(0, 10);
            if (choise <= 7)
            {
                AIBidOfferCoins = 100;
                //InBidCoins += AIBidOfferCoins;
                //AICoins -= 100;
                callORCheck.text = "Call";
                aiBidOfferT.text = "Raise: " + AIBidOfferCoins;
                player = true;
            }
            else if (choise > 7)
            {
                Invoke("checkshow", 1f);
            }


        }
        else if (courage == 2)
        {
            int choise = UnityEngine.Random.Range(0, 10);
            if (choise <= 7)
            {
                AIBidOfferCoins = 200;
                //InBidCoins += AIBidOfferCoins;
                //AICoins -= 100;
                callORCheck.text = "Call";
                aiBidOfferT.text = "Raise: " + AIBidOfferCoins;
                player = true;
            }
            else if (choise > 7)
            {
                Invoke("checkshow", 1f);
            }

        }
    }
    public void raiseBid()
    {
        if (PlayerBidOfferCoins != 0)
        {
            int choise = UnityEngine.Random.Range(0, 10);

            if (choise <= 7)
            {
                InBidCoins += PlayerBidOfferCoins * 2;
                AICoins -= PlayerBidOfferCoins;
                PlayerCoins -= PlayerBidOfferCoins;
                aiCoinsT.text = AICoins.ToString();
                aiBidOfferT.text = "Call: " + PlayerBidOfferCoins;
                if (!secondTurn)
                {
                    Fivecards = true;
                    show5thCenterCard();

                }
                if (!firstTurn)
                {
                    Fourcards = true;
                    show4thCenterCard();
                    secondTurn = false;
                }
                Invoke("UpdateInBidCoins", 1f);
                player = false;
            }
            else if (choise > 7)
            {
                Debug.Log("FOLD");
            }
        }
    }
    public void CheckBoard()
    {
        if (game)
        {
            if (player)
            {
                int i = 0;
                foreach (Image item in playerCards)
                {
                    playerCardsString[i] = item.sprite.name.ToString();
                    i++;
                }
            }
            if (!player)
            {
                int iiii = 0;
                foreach (Image item in playerCards)
                {
                    playerCardsString[iiii] = item.sprite.name.ToString();
                    iiii++;
                }
                int i = 0;
                int ii = 0;
                foreach (Image item in AICards)
                {
                    AICardsString[i] = item.sprite.name.ToString();
                    i++;
                }
                if (Threecards)
                {
                    Debug.Log("Im here Three");
                    foreach (Image item in CenterCards)
                    {
                        CenterCardsString[ii] = item.sprite.name.ToString();
                        ii++;
                    }
                    Threecards = false;
                }
                if (Fourcards)
                {
                    Debug.Log("Im here Four");
                    foreach (Image item in CenterCards)
                    {
                        CenterCardsString[ii] = item.sprite.name.ToString();
                        ii++;
                    }
                    Fourcards = false;
                }
                if (Fivecards)
                {
                    foreach (Image item in CenterCards)
                    {
                        CenterCardsString[ii] = item.sprite.name.ToString();
                        ii++;
                    }
                    Fivecards = false;
                }
            }
            if (!player)
            {
                if (game)
                {
                    AIDecisions();
                }
            }
        }
    }
    public void AIDecisions()
    {
        //matching two
        {
            AICardsStringHolder = AICardsString;
            PlayerCardsStringHolder = playerCardsString;
            CenterCardsStringHolder = CenterCardsString;

            for (int j = 0; j < 2; j++)
            {
                for (int jj = 0; jj < 4; jj++)
                {
                    AICardsStringHolder[j] = (String)AICardsStringHolder[j].Replace((String)CardTypes[jj], "");
                }


            }

            for (int j = 0; j < 2; j++)
            {
                for (int jj = 0; jj < 4; jj++)
                {
                    PlayerCardsStringHolder[j] = (String)PlayerCardsStringHolder[j].Replace((String)CardTypes[jj], "");
                }


            }
            for (int j = 0; j < 5; j++)
            {
                for (int jj = 0; jj < 4; jj++)
                {
                    CenterCardsStringHolder[j] = (String)CenterCardsStringHolder[j].Replace((String)CardTypes[jj], "");
                }


            }
            

            int i = 0;



            for (int f = 0; f < 2; f++)
            {
                for (int ff = 0; ff < 5; ff++)
                {
                    if (AICardsStringHolder[f] == CenterCardsStringHolder[ff])
                    {
                        i++;
                        Debug.Log("We found same: " + i);

                    }
                    else
                    {

                    }
                }

            }
            Debug.Log("Checked");
            raiseBidAI(i);
        }


    }
    public void resultMaxValue()
    {
       

        for (int j = 0; j < 2; j++)
        {
            for (int jj = 0; jj < 4; jj++)
            {
                AICardsStringHolder[j] = (String)AICardsStringHolder[j].Replace((String)CardTypes[jj], "");
            }


        }
        for (int j = 0; j < 5; j++)
        {
            for (int jj = 0; jj < 4; jj++)
            {
                CenterCardsStringHolder[j] = (String)CenterCardsStringHolder[j].Replace((String)CardTypes[jj], "");
            }


        }
        for (int j = 0; j < 2; j++)
        {
            for (int jj = 0; jj < 4; jj++)
            {
                PlayerCardsStringHolder[j] = (String)PlayerCardsStringHolder[j].Replace((String)CardTypes[jj], "");
            }


        }

        int AIResult = 0;
        int PlayerResult = 0;

        //checking how many are same

       
        if(AIResult == 0)
        {
            if(PlayerResult == 0)
            {
                result();
            }
        }

        //checking how many are in sequence

    }
    public void result()
    {
        int AIResult = 0;
        int PlayerResult = 0;
        for (int j = 0; j < 2; j++)
        {
            for (int jj = 0; jj < 4; jj++)
            {
                AICardsStringHolder[j] = (String)AICardsStringHolder[j].Replace((String)CardTypes[jj], "");
                if(AICardsStringHolder[j] == "J")
                {
                    AICardsStringHolder[j] = "11";
                }
                else if (AICardsStringHolder[j] == "Q")
                {
                    AICardsStringHolder[j] = "12";
                }
                else if (AICardsStringHolder[j] == "K")
                {
                    AICardsStringHolder[j] = "13";
                }
                else if (AICardsStringHolder[j] == "1")
                {
                    AICardsStringHolder[j] = "14";
                }
            }


        }
        for (int j = 0; j < 5; j++)
        {
            for (int jj = 0; jj < 4; jj++)
            {
                CenterCardsStringHolder[j] = (String)CenterCardsStringHolder[j].Replace((String)CardTypes[jj], "");

                if (CenterCardsStringHolder[j] == "J")
                {
                    CenterCardsStringHolder[j] = "11";
                }
                else if (CenterCardsStringHolder[j] == "Q")
                {
                    CenterCardsStringHolder[j] = "12";
                }
                else if (CenterCardsStringHolder[j] == "K")
                {
                    CenterCardsStringHolder[j] = "13";
                }
                else if (CenterCardsStringHolder[j] == "1")
                {
                    CenterCardsStringHolder[j] = "14";
                }
            }


        }
        for (int j = 0; j < 2; j++)
        {
            for (int jj = 0; jj < 4; jj++)
            {
                PlayerCardsStringHolder[j] = (String)PlayerCardsStringHolder[j].Replace((String)CardTypes[jj], "");
                if (PlayerCardsStringHolder[j] == "J")
                {
                    PlayerCardsStringHolder[j] = "11";
                }
                else if (PlayerCardsStringHolder[j] == "Q")
                {
                    PlayerCardsStringHolder[j] = "12";
                }
                else if (PlayerCardsStringHolder[j] == "K")
                {
                    PlayerCardsStringHolder[j] = "13";
                }
                else if (PlayerCardsStringHolder[j] == "1")
                {
                    PlayerCardsStringHolder[j] = "14";
                }
            }


        }
        for (int f = 0; f < 2; f++)
        {
            for (int ff = 0; ff < 5; ff++)
            {
                if (AICardsStringHolder[f] == CenterCardsStringHolder[ff])
                {
                    AIResult++;


                }
                else
                {

                }
            }

        }
        for (int f = 0; f < 2; f++)
        {
            for (int ff = 0; ff < 5; ff++)
            {
                if (PlayerCardsStringHolder[f] == CenterCardsStringHolder[ff])
                {
                    PlayerResult++;


                }
                else
                {

                }
            }

        }

        Debug.Log("AIResult: " + AIResult);
        Debug.Log("PlayerResult: " + PlayerResult);
        if (PlayerResult > AIResult)
        {
            Debug.Log("Player WON");
            PlayerCoins += InBidCoins;
            saveGame();
        }
        else if (PlayerResult < AIResult)
        {
            Debug.Log("AI WON");
            AICoins += InBidCoins;
            saveGame();
        }
        else if (PlayerResult == AIResult)
        {
            /*
            if (PlayerResult != 0)
            {
                Debug.Log("Draw");
                if (isFirstTime == 0)
                {
                    PlayerCoins = PlayerPrefs.GetInt("pcoins");
                    AICoins = PlayerPrefs.GetInt("aicoins");
                }
            }*/
            saveGame();
            checkGreaterHand();
        }
    }
    public void checkGreaterHand()
    {
        playerHand = Array.ConvertAll<string, int>(PlayerCardsStringHolder, int.Parse);
        
        
        for (int i = 0; i < playerHand.Length; i++)
        {
            playerHandScore += playerHand[i];

        }
        Debug.Log(playerHandScore);


        AIhand = Array.ConvertAll<string, int>(AICardsStringHolder, int.Parse);
        for (int i = 0; i < AIhand.Length; i++)
        {
            AIHandscore += AIhand[i];

        }
        Debug.Log(AIHandscore);

        if (playerHandScore > AIHandscore)
        {
            Debug.Log("Player WON by Hand");
            PlayerCoins += InBidCoins;
            saveGame();

        }
         else if (playerHandScore < AIHandscore)
            {
                Debug.Log("AI WON by Hand");
            AICoins += InBidCoins;
            saveGame();

        }
        else if (playerHandScore == AIHandscore)
        {
            Debug.Log("DRAW by Hand");
            if (playerHandScore != 0)
            {
                Debug.Log("Draw");
                if (isFirstTime == 0)
                {
                    PlayerCoins = PlayerPrefs.GetInt("pcoins");
                    AICoins = PlayerPrefs.GetInt("aicoins");
                }
            }

            saveGame();

        }
    }
}