using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

    public Button RePlayButton;
 
    void Start () {
        RePlayButton.GetComponent<Button>().onClick.AddListener(Reload);
    }

    void Update () {
        gameOver();
    }

    private void gameOver()
    {
        if (Env.bGameOver)
        {
            float mVio = 0.0f;
            float mySmoothTime = 0.1f;
            float smooth = Mathf.SmoothDamp(transform.position.y, 6.2f, ref mVio, mySmoothTime);
            GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.position.x, smooth);
        }
    }

    private void Reload() {
        SceneManager.LoadScene(0);

        Env.score = 0;
        Env.position = 0;
        Env.bGameOver = false;
    }
}
