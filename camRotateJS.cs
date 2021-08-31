using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotateJS : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] public Transform target;
    private Vector3 previousPosition;
    public cameraFollow camfollow;
    public GameObject camPoint;
    public bool isTouchedCam;
    public float dis;
    public void Allow()
    {
        isTouchedCam = true;
    } public void DisAllow()
    {
        isTouchedCam = false;
    }

    
    private void LateUpdate()
    {
        dis = Vector3.Distance(this.gameObject.transform.position, camPoint.transform.position);
        Debug.Log(dis);
        if (isTouchedCam == true) { 
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        }
            if (Input.GetMouseButton(0))
            {
                Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

                //cam.transform.position = target.position;
                cam.transform.position = Vector3.Lerp(transform.position, camPoint.transform.position, 0.2f);
                cam.transform.Rotate(new Vector3(100, 0, 0), direction.y * -720);

                cam.transform.Rotate(new Vector3(0, 100, 0), direction.x * -720, Space.World);
              // cam.transform.Translate(0f, 0f, -10f);
              
                camPoint.transform.position = target.position;

              

                camPoint.transform.Rotate(new Vector3(100, 0, 0), direction.y * 720);

                camPoint.transform.Rotate(new Vector3(0, 100, 0), direction.x * -720, Space.World);
                
                camPoint.transform.Translate(new Vector3(0, 0, -10));

                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
        }
    }
}
