using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(0, speed / 50, 0);
    }
}
