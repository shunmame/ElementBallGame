using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwa3 : MonoBehaviour
{
    float yy = -0.00017f;
    float yyy = 0f;
    float xx = -0.00017f;
    float xxx = 0f;
    float zz = 0.00007f;
    float zzz = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        myTransform.Rotate(0.003f, 0.03f, 0.006f);
        yyy += yy;
        pos.y += yy;

        if (yyy >= 0.13f || yyy <= -0.13f)
        {
            yy = yy * -1;
        }
        xxx += xx;
        pos.x += xx;

        if (xxx >= 0.22f || xxx <= -0.22f)
        {
            xx = xx * -1;
        }
        zzz += zz;
        pos.z += zz;

        if (zzz >= 0.2f || zzz <= -0.2f)
        {
            zz = zz * -1;
        }
        myTransform.position = pos;
    }
}
