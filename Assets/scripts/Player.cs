using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	void Start () {
		
	}

    public Slider slider;//
    float downRate = 0.3f;
    float lastTime = 1f;
    void Update () {

        if (Env.bGameOver == false) {

            if (slider.value == 0) {

                Env.bGameOver = true;
            } else {
                float time = Time.time;
                if (time - lastTime > downRate) {

                    float mVio = 0.0f;
                    float mySmoothTime = 0.0000001f;
                    float smooth = Mathf.SmoothDamp(slider.value, slider.value - 0.04f, ref mVio, mySmoothTime);
                    slider.value = smooth;

                    lastTime = time;
                }
            }
        }
    }

    public Text ScoreText;
    public GameObject deadEffect;
    int count = 0;//判断开始不加分

    private void OnTriggerEnter2D(Collider2D coll) {
        SpriteRenderer sr = coll.gameObject.GetComponent<SpriteRenderer>();
        if (sr.enabled)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);

            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            Env.bGameOver = true;
        }

        if (Env.bGameOver == false && count > 0) {

            ScoreText.text = (++Env.score).ToString();

            if (slider.value < 1) {
                float mVio = 0.0f;
                float mySmoothTime = 0.0000001f;
                float smooth = Mathf.SmoothDamp(slider.value, slider.value + 0.02f, ref mVio, mySmoothTime);
                slider.value = smooth;
            }
        }
        count++;
    }
}
