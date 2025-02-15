using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSet : MonoBehaviour
{

    float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pipe movement
        transform.Translate((moveSpeed * Vector2.left) * Time.deltaTime);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
