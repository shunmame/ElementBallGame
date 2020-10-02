using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitNextMonster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object MonsterPf_H = Resources.Load("Model/Monster/h2");
        GameObject Monster = (GameObject)Instantiate(MonsterPf_H, new Vector3(0.8f, -0.18f, -0.6f), Quaternion.Euler(0, 90, 0));
        Monster.transform.localScale = new Vector3(10, 10, 10);
        // Monster.transform.localPosition = new Vector3(-0.05f, 0.1f, 0.38f);
        Monster.transform.localRotation = Quaternion.Euler(0, 45, 0);
        Monster.transform.parent = GameObject.Find("NextMonster").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
