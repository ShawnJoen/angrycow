using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public static Collision2D pipeCollision = null;

    void Start () {
		
	}

	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll) {

        pipeCollision = coll;
    }
}
