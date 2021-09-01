using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
     
    public Transform Target;
    public Transform camTransform;
    public Vector3 Offset;
    private float SmoothTime = 0.05f;
    public Material[] mat;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        //Offset = camTransform.position - Target.position;
       
    }

    private void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 4 * Time.time);
        Vector3 targetPosition = Target.position + Offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        transform.LookAt(Target);
    }
}
