using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

	bool isRewinding = false;
    public bool startt;
	private float recordTime = 1f;
    public snakemovements mainscript;
	List<PointInTime> pointsInTime;
    public GameObject lose;
    public actioncollider action;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
       startt = false;
       mainscript = GameObject.FindGameObjectWithTag("mainsnakeo").GetComponent<snakemovements>();
       action = GameObject.FindGameObjectWithTag("mainsnake").GetComponent<actioncollider>();

		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();
	}
    public void rewinder() {
        startt = true;

    
    }
	// Update is called once per frame
	void Update () {
        if (startt == true)
        {
            StartRewind();
            lose.SetActive(false);
            action.restarter();

        }
		if (Input.GetKeyUp(KeyCode.Return))
			StopRewind();
	}

	void FixedUpdate ()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind ()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		} else
		{
			StopRewind();

		}
		
	}

	void Record ()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind ()
	{
		isRewinding = true;
		rb.isKinematic = true;
	}

	public void StopRewind ()
	{
        lose.SetActive(false);
        mainscript.speed = 1f;
        startt = false;
		isRewinding = false;
		rb.isKinematic = false;
	}
}
