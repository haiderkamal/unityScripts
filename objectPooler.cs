using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class objectPooler : MonoBehaviour
{
    public static objectPooler current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;
    public int objCount;
    public List<GameObject> pooledObjects;
    public Text totalAmount;


    void Start()
    {
        current = this;
        //pooledObject = new List<GameObject>();
        
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public void FixedUpdate()
    {
        objCount = 0;
        foreach (GameObject go in pooledObjects)
        {
            if (go.activeSelf)
            {
                objCount++;
                totalAmount.text = objCount.ToString();
            }

        }
        totalAmount.text = objCount.ToString();
    }
    public void starRun()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            if(pooledObjects[i].activeInHierarchy)
            pooledObjects[i].GetComponent<followerScript>().isRunning = true;
        }
    }
    public void stopRun()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            if(pooledObjects[i].activeInHierarchy)
            pooledObjects[i].GetComponent<followerScript>().isRunning = false;
        }
    }
    public GameObject getPooledObj()
    {
        for (int i = 0; i< pooledObjects.Count; i++){
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
