using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPipe : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        if (bFlyPipe) {
            bFlyPipe = false;
            CreatePipe();
        }
	}
    public static bool bFlyPipe = false;//允许新生成管子
    public GameObject pipes;
    GameObject newPipe;
    Rigidbody2D newRigidbody;
    public void CreatePipe() {
        int whichTo = 0;
        newPipe = Instantiate(pipes, transform.position, transform.rotation);
        newRigidbody = newPipe.GetComponent<Rigidbody2D>();


        float direction = Env.position == 0 ? 3f : -3f;
        newRigidbody.velocity = new Vector2(direction, 2);
        newRigidbody.AddForce(Vector2.up * 20);

        if (whichTo == 0) {
            //Transform newPipeLeft = newPipe.transform.Find("pipeLeft");
            //newPipeLeft.GetComponent<Renderer>().enabled = false;
            //Transform newPipeRight = newPipe.transform.Find("pipeRight");
            //newPipeRight.GetComponent<Renderer>().enabled = false;
            // newPipe.transform.Translate(-8 * Time.deltaTime, 1 * Time.deltaTime, 0);
        } else {
            //Transform newPipeLeftOrRight;//左或右边管子
            if (whichTo > 0) {
                //newPipeLeftOrRight = newPipe.transform.Find("pipeLeft");
            } else {
                //newPipeLeftOrRight = newPipe.transform.Find("pipeRight");
            }
        }
    }
}