using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject MainVehical;
    public GameObject camrea;
   
    public float dis;
    public GameObject CamPoint;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!finish)
        {
            dis = Vector3.Distance(this.gameObject.transform.position, MainVehical.transform.position);
            this.gameObject.transform.LookAt(MainVehical.transform);

            this.gameObject.transform.position = Vector3.Lerp(transform.position, CamPoint.transform.position, 0.02f);
        }
        else
        {
            dis = Vector3.Distance(this.gameObject.transform.position, camrea.transform.position);
            //this.gameObject.transform.LookAt(camrea.transform);
            Quaternion OriginalRot = transform.rotation;
           // transform.LookAt(coffeeMug.transform.position);
            Quaternion NewRot = transform.rotation;
            transform.rotation = OriginalRot;
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, (0.1f + 3) * Time.deltaTime);
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, camrea.transform.position, 1f);
        }
     
        
    }
}
