using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwa : MonoBehaviour
{
    float yy = 0.0001f;
    float yyy = 0f;
    float a, b, c;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        a = 0.01f;
        b = 0.01f;
        c = 0.01f;
        myTransform.Rotate(a, b, c);
        yyy += yy;
        pos.y +=yy;

        if (yyy >= 0.1f || yyy <= -0.1f)
        {
            yy = yy * -1;
        }
        myTransform.position = pos; 
    }
}
