using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public Camera mainCamera;
    public joystick joystick;
    public GameObject MainPlayer;
    public Vector3 cameraTransform;
    public Vector3 PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void RotationSave()
    {
        if (joystick.isTouched == false)
        {
            cameraTransform = mainCamera.transform.localEulerAngles;
            PlayerTransform = MainPlayer.transform.localEulerAngles;

        }
    }
    void Update()
    {
        RotationSave();
        if (joystick.isTouched == true)
        {
            mainCamera.transform.localEulerAngles = new Vector3((-1 * (joystick.inputVector.y)) + cameraTransform.x, 0, 0);
            MainPlayer.transform.localEulerAngles = new Vector3(0, (joystick.inputVector.x * 2) + PlayerTransform.y, 0);
        }
    }
}
