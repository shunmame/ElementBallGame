using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwa4 : MonoBehaviour
{
    float xx = 0.00006f;
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
        myTransform.Rotate(0.01f, 0f, 0f);
        xxx += xx;
        pos.x += xx;

       /* if (xxx >= 0.2f || xxx <= -0.14f)
        {
            xx = xx * -1;
        }*/
        myTransform.position = pos;
    }
}
