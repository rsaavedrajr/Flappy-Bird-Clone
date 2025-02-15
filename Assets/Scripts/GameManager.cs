using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pipeObject;
    public GameObject birdObject;
    public GameObject floorTile;
    public GameObject gameOver;
    public Text scoreText;

    private float pipeTimerMax = 20f;
    private float pipeTimer = 0f;

    bool isGameOver = false;

    System.Random rng;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pipeTimer -= 15 * Time.deltaTime;

        //create pipes
        if (pipeTimer <= 0)
        {
            //rng+0.45
            float pipeY = Random.Range(-2.5f, 2.5f);
            pipeY += 0.45f;

            GameObject pipeSet = Instantiate<GameObject>(pipeObject);
            //pipeSet.transform.position = new Vector2(5.8f, pipeY);
            pipeSet.transform.position = new Vector2(9f, pipeY);

            pipeTimer = pipeTimerMax;
        }

        //set score in hud
        scoreText.text = birdObject.GetComponent<Bird>().score().ToString();
    }
}
