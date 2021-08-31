using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject ThisCanvas;
    public GameObject MainCanvas;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void link1()
    {
        Application.OpenURL("https://www.zapsplat.com");
    }
    public void link2()
    {
        Application.OpenURL(" https://www.flaticon.com");
    }
    public void closeThisCanvas()
    {
        MainCanvas.SetActive(true);
        ThisCanvas.SetActive(false);
    }
}
