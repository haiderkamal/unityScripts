using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform mainPlayer;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - mainPlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainPlayer.position + offset;
    }
}
