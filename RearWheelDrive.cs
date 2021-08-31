using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RearWheelDrive : MonoBehaviour {

	public WheelCollider[] wheels;

	public float maxAngle = 30;
	public float maxTorque = 300;
	public GameObject wheelShapeL;
	public GameObject wheelShapeR;
    public float RPM;
    public Rigidbody rb;
    public GameObject backLight1;
    public GameObject backLight2;

   
    public menucontroller menu;
   
    // here we find all the WheelColliders down in the hierarchy
    public void Start()
	{
        menu = GameObject.FindGameObjectWithTag("menu").GetComponent<menucontroller>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, -1.9f, 0f);
		wheels = GetComponentsInChildren<WheelCollider>();

		for (int i = 0; i < wheels.Length; ++i) 
		{
			var wheel = wheels [i];

			// create wheel shapes only when needed
			if (wheelShapeL != null)
			{
				
				var wsL = GameObject.Instantiate (wheelShapeL);
				var wsR = GameObject.Instantiate (wheelShapeR);
				if(i==1){
					wsL.transform.parent = wheel.transform;
				}
				 if (i==2){
					wsL.transform.parent = wheel.transform;
				}
				if(i==0){
					wsR.transform.parent = wheel.transform;
				}
				 if (i==3){
					wsR.transform.parent = wheel.transform;
				}
				
			}
		}
	}

	// this is a really simple approach to updating wheels
	// here we simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero
	// this helps us to figure our which wheels are front ones and which are rear
	public void Update()
	{
		float angle = maxAngle * SimpleInput.GetAxis("Horizontal");
	    RPM = maxTorque * SimpleInput.GetAxis("Vertical");
        if (RPM > 0)
        {
            backLight1.SetActive(false);
            backLight2.SetActive(false);
        }
        else if (RPM < 0)
        {
            backLight1.SetActive(true);
            backLight2.SetActive(true);
        }
		foreach (WheelCollider wheel in wheels)
		{
			// a simple car where front wheels steer while rear ones drive
			if (wheel.transform.localPosition.z > 0)
				wheel.steerAngle = angle;

			//if (wheel.transform.localPosition.z < 0)
				wheel.motorTorque = RPM;
          //  Debug.Log(wheels[3].rpm);
			// update visual wheels if any
			if (wheelShapeR) 
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose (out p, out q);

				// assume that the only child of the wheelcollider is the wheel shape
				Transform shapeTransform = wheel.transform.GetChild (0);
				shapeTransform.position = p;
				shapeTransform.rotation = q;
			}

		}
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            menu.ending();
        }
    }
}
