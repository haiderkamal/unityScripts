using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{
    public int state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1){
            this.gameObject.transform.position += transform.forward *0.02f;
        }
         if(state == 2){
            this.gameObject.transform.position += transform.forward *0.02f;

            this.gameObject.transform.Rotate(0,2,0);
        } if(state == 3){
            this.gameObject.transform.position += transform.forward *0.02f;

             this.gameObject.transform.Rotate(0,-2,0);
        } if(state == 4){
            this.gameObject.transform.position += transform.forward *0;
        }
         if(state == 5){
             this.gameObject.transform.Rotate(0,0,0);
        }
    }
    public void go(){
        state = 1;
    }
    public void left(){
        state = 2;
    }public void right(){
        state = 3;
    }public void stop(){
        state = 4;
    }
    public void stopR(){
        state = 5;
    }
}
