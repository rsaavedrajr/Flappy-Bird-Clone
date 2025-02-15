using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgElement : MonoBehaviour
{
    public GameObject floor;
    public GameObject bg1;
    public GameObject bg2;

    float moveSpeed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        floor.transform.Translate((moveSpeed * Vector2.left) * Time.deltaTime);
        if (floor.transform.position.x < -0.64)
        {
            floor.transform.position = new Vector3(0, floor.transform.position.y, floor.transform.position.z);
        }

        bg1.transform.Translate(0.5f * (moveSpeed * Vector2.left) * Time.deltaTime);
        if (bg1.transform.position.x < -5.12)
        {
            bg1.transform.position = new Vector3(0, bg1.transform.position.y, bg1.transform.position.z);
        }


        bg2.transform.Translate(0.25f * (moveSpeed * Vector2.left) * Time.deltaTime);
        if (bg2.transform.position.x < -5.12)
        {
            bg2.transform.position = new Vector3(0, bg2.transform.position.y, bg2.transform.position.z);
        }

    }
}
