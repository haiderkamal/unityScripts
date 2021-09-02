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
    public String[] CenterCardsStringHolder;

    void Start()
    {
        loadedCards = new int[11];
        playerCardsString = new String[2];
        CenterCardsString = new String[5];
        AICardsString = new String[2];
        AICardsStringHolder = new String[2];
        loadedCardsNum = 0;
        PlayerCoins = 1000;
        AICoins = 1000;
        startBid = 50;
        raise = 10;
        player = false;
        firstTurn = true;
        secondTurn = true;
        CardTypes = new String[] {"cardSpades", "cardDiamonds", "cardHearts", "cardClubs"};
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
    }
    public void show5thCenterCard()
    {

        CenterCards[4].sprite = Deck[loadedCards[8]];
        Fivecards = false;
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
            if(CheckBoolcnf == false)
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
                    InBidCoins += AIBidOfferCoins*2;
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
        AICoins -= PlayerBidOfferCoins;
        InBidCoins += PlayerBidOfferCoins;
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
        if(courage == 0)
        {
           
            Invoke("checkshow", 1f);
            
        }
        else if(courage == 1)
        {
            int choise = UnityEngine.Random.Range(0, 10);
            if(choise <= 7)
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
        else if(courage == 2)
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
        if (player)
        {
            int i = 0;
            foreach(Image item in playerCards)
            {
                playerCardsString[i] = item.sprite.name.ToString();
                i++;
            }
        }
        if (!player)
        {
            int i = 0;
            int ii = 0;
            foreach (Image item in AICards)
            {
                AICardsString[i] = item.sprite.name.ToString();
                i++;
            }
            if (Threecards)
            {
                foreach (Image item in CenterCards)
                {
                    CenterCardsString[ii] = item.sprite.name.ToString();
                    ii++;
                }
                Threecards = false;
            }if (Fourcards)
            {
                foreach (Image item in CenterCards)
                {
                    CenterCardsString[ii] = item.sprite.name.ToString();
                    ii++;
                }
                Fourcards = false;
            }if (Fivecards)
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
            AIDecisions();
        }
        
    }
    public void AIDecisions()
    {
        //matching two
        AICardsStringHolder = AICardsString;
        CenterCardsStringHolder = CenterCardsString;

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

        int i = 0;
         


        for(int f = 0; f < 2; f++)
        {
            for(int ff = 0; ff < 5; ff++)
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
