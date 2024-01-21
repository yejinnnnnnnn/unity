using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 회전 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float angle = 90;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0, 0, angle / 50);
    }
}
