using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private AudioSource actionSound;
    public AudioClip sfxFlap;
    public AudioClip sfxScore;
    public AudioClip sfxDie;
    public GameObject sprite;
    public GameObject gameOver;


    //gravity
    float vectorY = -0.5f;
    const float birdJump = -8;
    const float birdGravity = 25f;

    int birdScore = 0;

    Quaternion faceUp;
    Quaternion faceDown;

    // Start is called before the first frame update
    void Start()
    {
        actionSound = GetComponent<AudioSource>();
        faceUp = new Quaternion(0, 0, -45, 0);
        faceDown = new Quaternion(0, 0, 45, 0);
    }

    public int score()
    {
        return birdScore;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");

        if (collision.gameObject.tag == "score")
        {
            actionSound.PlayOneShot(sfxScore);
            birdScore++;
            //Debug.Log(birdScore);
        }
        else
        {
            //die
            Time.timeScale = 0;
            actionSound.PlayOneShot(sfxDie,0.2f);
            Instantiate<GameObject>(gameOver);
            //actionSound.PlayOneShot(sfxScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                vectorY = birdJump;
                actionSound.PlayOneShot(sfxFlap, 0.2f);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        sprite.transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(45, -45, vectorY / 10));

        if (vectorY < 50)
        {
            vectorY += (birdGravity * Time.deltaTime);
        }
        transform.Translate((vectorY * Vector2.down) * Time.deltaTime);
    }
}
