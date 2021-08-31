using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoalScript : MonoBehaviour
{
    public Text info;
    public AudioSource audioSource;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.clip = clips[0];
            audioSource.Play();
            info.text = "GOAL";
            Invoke("restart", 2f);
        }
    }
    public void restart()
    {

        SceneManager.LoadScene("bu1");
    }
}
