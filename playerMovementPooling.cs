using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerMovementPooling : MonoBehaviour
{
    private Touch touch;
    private float speed;
    public Animator animator;
    public Rigidbody rb;
    public float speedF;
    public float AngularSpeed;
    public bool isTouched;
    public int totalPlayers;
    public objectPooler objPool;
    public GameObject wayPoint;
    public SphereCollider sphereCol;
    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public AudioClip clipWin;
    public AudioClip clipLose;
    public AudioSource audiosource;
    public Text amigoes;
    public bool gameStarted;
    public bool gameFinished;
    // Start is called before the first frame update
    void Start()
    {
        var r = sphereCol.radius;
        totalPlayers = 1;
        speed = 0.1f;
        animator = this.gameObject.GetComponent<Animator>();
        WinCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
        gameStarted = false;
        gameFinished = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameFinished)
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += transform.forward * Time.fixedDeltaTime * 20;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = new Vector3(
                       transform.position.x + -(1 * speed),
                       transform.position.y,
                       transform.position.z);
                speedF = rb.velocity.magnitude;
                AngularSpeed = rb.angularVelocity.magnitude;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = new Vector3(
                       transform.position.x + (1 * speed),
                       transform.position.y,
                       transform.position.z);
                speedF = rb.velocity.magnitude;
                AngularSpeed = rb.angularVelocity.magnitude;
            }

            if (totalPlayers < 1)
            {
                totalPlayers = 1;
            }
            if (Input.touchCount > 0)
            {
                isTouched = true;
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {

                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speed,
                        transform.position.y,
                        transform.position.z);
                    speedF = rb.velocity.magnitude;
                    AngularSpeed = rb.angularVelocity.magnitude;

                }

            }
            else
            {
                isTouched = false;
                animator.SetBool("isRunning", false);
                objPool.stopRun();
            }
            if (isTouched == true)
            {
                objPool.starRun();
                animator.SetBool("isRunning", true);
                transform.Translate(Vector3.forward * 15 * Time.fixedDeltaTime);
                gameStarted = true;


            }
        }
    }
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tenPlus"))
        {
            addTenPlayer();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("fiveMultiply"))
        {
            multiplyFivePlayer();
            Destroy(other.gameObject);
        } 
        
        if (other.CompareTag("enemy"))
        {
            if (gameFinished == false)
            {
                if (gameStarted == true)
                {
                    if (objPool.objCount < 1)
                    {
                        LoseCanvas.SetActive(true);
                        audiosource.clip = clipLose;
                        audiosource.Play();
                        gameFinished = true;
                    }
                }
            }
        } 
        
        if (other.CompareTag("enemyPlayer"))
        {
            if (gameFinished == false)
            {
                if (gameStarted == true)
                {
                    if (objPool.objCount < 1)
                    {
                        LoseCanvas.SetActive(true);
                        audiosource.clip = clipLose;
                        audiosource.Play();
                        gameFinished = true;
                    }
                }
            }
        } 
        if (other.CompareTag("Goal"))
        {
            if (objPool.objCount < 1)
            {
                LoseCanvas.SetActive(true);
                audiosource.clip = clipLose;
                audiosource.Play();
                Destroy(other.gameObject);
               
            }
            else if (objPool.objCount >= 1)
            {
                WinCanvas.SetActive(true);
                audiosource.clip = clipWin;
                audiosource.Play();
                amigoes.text = "You Brought " + objPool.objCount.ToString() + " Amigoes!";
                Destroy(other.gameObject);
            }
          
        }
    }
    public void addTenPlayer()
    {
        int j = 0;
        var r = 1;
        totalPlayers = objPool.objCount* 10;
        for (int i = 0; i < 10; i++)
        {
            
            if (i > 5)
            {
                j++;
            }
            GameObject obj = objectPooler.current.getPooledObj();
            if (obj == null) return;
            if (i % 2 == 0)
            {
                var x = Random.Range(-8f, 1f);
                var y = Random.Range(0, 0);
                var z = Random.Range(-8f, 1f);

                var vec = new Vector3(x, y, z) * r;
                Debug.Log(vec);
                //obj.transform.position += vec;
                obj.GetComponent<followerScript>().offset = vec;
                obj.SetActive(true);
            }
            else if (i % 2 == 1)
            {
                var x = Random.Range(8f, 1f);
                var y = Random.Range(0, 0);
                var z = Random.Range(8f, 1f);

                var vec = new Vector3(x, y, z) * r;
                Debug.Log(vec);
                //obj.transform.position += vec;
                obj.GetComponent<followerScript>().offset = vec;
                obj.SetActive(true);
            }
        }
        
    }
    public void multiplyFivePlayer()
    {
        var r = 1;
        Debug.Log(r);
        totalPlayers = objPool.objCount* 5;
        for (int i = 0; i < totalPlayers; i++)
        {
           
            GameObject obj = objectPooler.current.getPooledObj();
            if (obj == null) return;
            if (i % 2 == 0)
            {
                //obj.GetComponent<followerScript>().offset = new Vector3((i + 1), 0, 0);
                var x = Random.Range(-8f, 1f);
                var y = Random.Range(0, 0);
                var z = Random.Range(-8f, 1f);

                var vec = new Vector3(x, y, z) * r;
                Debug.Log(vec);
                //obj.transform.position += vec;
                obj.GetComponent<followerScript>().offset = vec;
                obj.SetActive(true);
            }
            else if (i % 2 == 1)
            {
                //obj.GetComponent<followerScript>().offset = new Vector3((-i - 1), 0, 0);
                var x = Random.Range(8f, 1f);
                var y = Random.Range(0, 0);
                var z = Random.Range(8f, 1f);

                var vec = new Vector3(x, y, z) * r;
                //obj.transform.position += vec;
                obj.GetComponent<followerScript>().offset = vec;
                obj.SetActive(true);
            }
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }public void LoadScene1()
    {
        SceneManager.LoadScene("level1");
    }public void LoadScene2()
    {
        SceneManager.LoadScene("level2");
    }public void LoadScene3()
    {
        SceneManager.LoadScene("level3");
    }

}
