using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {

	public float moveSpeed;
	public float addSpeed;
	public float speedTimer;
	public float scoreTimer;
	public GameObject gs;
	public gamestarterscript gstript;
	// Use this for initialization
	void Start () {
		//addSpeed = 2f;
	//	gs = GameObject.Find("GameStarter");
	///	gstript = gs.GetComponent<gamestarterscript>();
	//	addSpeed = gstript.speed;
	//	moveSpeed += addSpeed;
	}
	public void changeSpeed(int speed)
    {
		moveSpeed = speed;
	}
	// Update is called once per frame
	void Update () {
		if (!mainPlayerController.dead) {
			 
			transform.Translate (0, 0, -moveSpeed * Time.deltaTime);
		}
	}
}
