using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour {
    public GameObject ThisBall;
    Rigidbody m_Rigidbody;
    public float m_Speed;
    public bool rightB;
    public bool leftB;
    public bool stopB;
    public bool startB;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        startB = false;
        m_Speed = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {

        if (startB == true)
        {
            gameObject.transform.position += transform.forward * m_Speed;

            if (rightB == true)
            {
                this.gameObject.transform.Rotate(0, 10, 0);

            }

            if (leftB == true)
            {
                this.gameObject.transform.Rotate(0, -10, 0);

            }
            if (stopB == true)
            {

                this.gameObject.transform.Rotate(0, 0, 0);

            }
        }
    }
    public void right() {
        stopB = false;
        leftB = false;
        rightB = true;
    }
    public void left()
    {
        stopB = false;
        rightB = false;
        leftB = true;
    }
    public void stop()
    {
        rightB = false;
        leftB = false;

        stopB = true;
    }
}
