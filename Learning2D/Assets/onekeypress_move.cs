using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onekeypress_move : MonoBehaviour
{
    public float speed = 2;
    float vx = 0;
    float vy = 0;
    bool leftFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
        vy = 0;
        if (Input.GetKey("right"))
        {
            vx = speed;
            leftFlag = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = true;
        }
        if (Input.GetKey("up"))
        {
            vx = speed;
            
        }
        if (Input.GetKey("down"))
        {
            vx = -speed;
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(vx / 50, 0, 0);
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
