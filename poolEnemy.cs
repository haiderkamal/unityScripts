using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolEnemy : MonoBehaviour
{
    public static poolEnemy current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;
    public List<GameObject> pooledObjects;
    public int enemyCount;
    public GameObject[] enemySpawners;
    
    void Start()
    {
        current = this;
        
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            Invoke("CallEnemies",2f);
             
        }
    }
    public GameObject getPooledObj()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
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
    public void CallEnemies()
    {
        addEnemies(enemyCount);
    }
    public void addEnemies(int enemyCount)
    {
        if (enemySpawners[0].gameObject != null) {
            for (int ii = 0; ii < enemySpawners.Length; ii++)
            {
                int j = 0;
                var r = 2;
                Debug.Log("ii values: " + ii);
                for (int i = 0; i < enemyCount; i++)
                {

                    if (i > 5)
                    {
                        j++;
                    }
                    GameObject obj = poolEnemy.current.getPooledObj();
                    if (obj == null) return;
                    if (i % 2 == 0)
                    {
                        var x = Random.Range(-8f, 1f);
                        var y = Random.Range(0, 0);
                        var z = Random.Range(-8f, 1f);

                        var vec = new Vector3(x, y, z) * r;
                        // Debug.Log(vec);
                        //obj.transform.position += vec;
                        obj.GetComponent<enemy>().offset = vec;
                        obj.GetComponent<enemy>().targetPole = enemySpawners[ii];
                        obj.SetActive(true);
                    }
                    else if (i % 2 == 1)
                    {
                        var x = Random.Range(8f, 1f);
                        var y = Random.Range(0, 0);
                        var z = Random.Range(8f, 1f);

                        var vec = new Vector3(x, y, z) * r;
                        //Debug.Log(vec);
                        //obj.transform.position += vec;
                        obj.GetComponent<enemy>().offset = vec;
                        obj.GetComponent<enemy>().targetPole = enemySpawners[ii];
                        obj.SetActive(true);
                    }
                }
            }
        }


    }
}
