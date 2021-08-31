using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class map : MonoBehaviour
{
    public Image[] playerBob;
    public GameObject[] player;
    public GameObject Player;
    public Image[] bob;
    public Image BgMap;
    public GameObject[] otherPlayers1;
    public GameObject[] otherPlayers2;

    // Start is called before the first frame update
    void Start()
    {
        addplayer();
    }
    public void addplayer()
    {
        this.otherPlayers1 = GameObject.FindGameObjectsWithTag("MainPlayer");
        this.otherPlayers2 = GameObject.FindGameObjectsWithTag("MainPlayerOnline");

        this.player = otherPlayers1.Concat(otherPlayers2).ToArray();
        playerBob = new Image[player.Length];
        for (int i = 0; i < player.Length; i++)
        {
            bob[i].enabled = true;
            playerBob[i] = bob[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        BgMap.transform.localEulerAngles = new Vector3(0, 0, Player.transform.rotation.y*180f);
        for(int i=0; i<player.Length;i++){

        playerBob[i].rectTransform.localPosition = new Vector3(player[i].transform.localPosition.x * 100f - Player.transform.localPosition.x * 100f, player[i].transform.localPosition.z * 100f - Player.transform.localPosition.z * 100f, 0);
        
        }
    }
}
