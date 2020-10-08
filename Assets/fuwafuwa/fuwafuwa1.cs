using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwa1 : MonoBehaviour
{
    float yy = -0.00017f;
    float yyy = 0f;
    float xx = -0.00017f;
    float xxx = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        myTransform.Rotate(0.001f, 0.01f, 0.006f);
        yyy += yy;
        pos.y += yy;

        if (yyy >= 0.2f || yyy <= -0.2f)
        {
            yy = yy * -1;
        }
        xxx += xx;
        pos.x += xx;

        if (xxx >= 0.12f || xxx <= -0.12f)
        {
            xx = xx * -1;
        }
        myTransform.position = pos;
    }
}
