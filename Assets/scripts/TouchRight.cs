using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRight : MonoBehaviour
{
    GameObject Player;
    Animator PlayerPushPipe;
    SpriteRenderer PlayerRenderer;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        PlayerRenderer = Player.GetComponent<SpriteRenderer>();
        PlayerPushPipe = Player.GetComponent<Animator>();
    }

    void Update() {

    }

    private void OnMouseDown() {
        if (Env.bGameOver == false) {
            float time = Time.time;
            if (time - Env.lastClickTime > Env.clickRate) {
                Env.lastClickTime = time;

                PlayerPushPipe.SetBool("bPush", true);

                StartCoroutine(Release());
            }
        }
    }

    IEnumerator Release()
    {
        if (Ground.pipeCollision != null)
        {
            if (Env.position == 1f)
            {

            }
            else
            {
                PlayerRenderer.flipX = true;

                Env.position = 1f;
                Player.transform.Translate(6f, 0, 0);
            }

            Destroy(Ground.pipeCollision.gameObject);
            Ground.pipeCollision = null;
        }

        FlyPipe.bFlyPipe = true;

        yield return new WaitForSeconds(0.2f);

        PlayerPushPipe.SetBool("bPush", false);
    }
}
