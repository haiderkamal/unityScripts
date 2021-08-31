using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vsEnabler : MonoBehaviour
{
    public GPMultiplayer MultiplayerScript;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("versusEnabler", 1f);
    }

    // Update is called once per frame
    public void versusEnabler()
    {
        MultiplayerScript.versusEnabled = true;

    }
}
