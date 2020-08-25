using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdmin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object MonsterPf_H = Resources.Load("Model/Monster/h2");
        GameObject Monster = (GameObject)Instantiate(MonsterPf_H, new Vector3(0, -0.4f, -0.3f), Quaternion.identity);
        Monster.transform.localScale = new Vector3(30, 30, 30);
        Monster.transform.parent = GameObject.Find("NowMonster").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
