using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour {

    public GameObject pipes;
    public float delaySpawn = 0.3f;
    float nextSpawn = 0.0f;
    public bool bStartingSpawn = true;//允许新生成管子
    public float randomPipeRL = -0.3f;//左右管子显示概率 -0.3 0 0.3
    float whichTo = 0.0f;

    void Start () {
		
	}

    void Update () {
        //if (Env.bGameOver == false) {
            nextSpawn += Time.deltaTime;
            if (bStartingSpawn && nextSpawn > delaySpawn) {

                bStartingSpawn = false;
                nextSpawn = 0.0f;
                whichTo = Random.Range(randomPipeRL, System.Math.Abs(randomPipeRL));
                //SpawnPipes(whichTo);
                CreatePipe();
            }
    }

    public void CreatePipe() {

        GameObject newPipe = Instantiate(pipes, transform.position, transform.rotation);
        if (whichTo == 0)
        {
            Transform newPipeLeft = newPipe.transform.Find("pipeLeft");
            newPipeLeft.GetComponent<SpriteRenderer>().enabled = false;
            Transform newPipeRight = newPipe.transform.Find("pipeRight");
            newPipeRight.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            Transform newPipeLeftOrRight;//左或右边管子
            if (whichTo > 0)
            {
                newPipeLeftOrRight = newPipe.transform.Find("pipeLeft");
            }
            else
            {
                newPipeLeftOrRight = newPipe.transform.Find("pipeRight");
            }

            newPipeLeftOrRight.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "pipeUp")
        {
            bStartingSpawn = true;
        }
    }
}
