using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class loader : MonoBehaviour {
    public GameObject loadingscreenobject;
    AsyncOperation async;
    public Slider sliderr;


	// Use this for initialization
	void Start () {
        LoadScreenExample();
    }

    public void LoadScreenExample(int LVL = 1) {

        StartCoroutine(LoadingScreen(LVL));
    
    }
    IEnumerator LoadingScreen(int lvl = 1)
    {
        loadingscreenobject.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;
        while (async.isDone == false)
        {
            float progresds = Mathf.Clamp01(async.progress / 0.9f);
            sliderr.value = progresds;
            if (async.progress == 0.9f)
            {

                sliderr.value = 1f;
                async.allowSceneActivation = true;

            }
            yield return null;
        }
    }
    // Update is called once per frame
	void Update () {
		
	}
}
