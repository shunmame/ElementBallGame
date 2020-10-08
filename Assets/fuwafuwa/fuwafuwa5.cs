using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwa5 : MonoBehaviour
{
    float zz = 0.00004f;
    float zzz = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        myTransform.Rotate(0f, 0f, 0.04f);
        zzz += zz;
        pos.z += zz;

        if (zzz >= 2f || zzz <= -0.2f)
        {
            zz = zz * -1;
        }
        myTransform.position = pos;
    }
}
