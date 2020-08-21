using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInitElementBall : MonoBehaviour
{
    GameObject[] ElementBalls;

    // Start is called before the first frame update
    void Start()
    {
        var BallPos = new List<Vector3>(){ 
            new Vector3(-0.9f, 0.18f, -1.2f),  // 左上
            new Vector3(-0.9f, 0.18f, -1.0f),  // 真ん中上
            new Vector3(-0.9f, 0.18f, -0.8f),  // 右上
            new Vector3(-0.9f, 0.06f, -1.2f),  // 左下
            new Vector3(-0.9f, 0.06f, -1.0f),  // 真ん中下
            new Vector3(-0.9f, 0.06f, -0.8f)   // 右下
        };

        var PosName = new List<string>(){"UpperLeft", "UpperCenter", "UpperRight", 
                                         "LowerLeft", "LowerCenter", "LowerRight"
                                        };
        
        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        // Hのマテリアル取得
        Material elementH_material = Resources.Load("Material/element_H") as Material;

        for(int i = 0; i < 6; i++)
        {
            // Hのテクスチャをはる
            ElementBalls[i].GetComponent<Renderer>().material = elementH_material;

            // ここ使ってた
            // GameObject ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
            // GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, BallPos[i], Quaternion.identity);
            // ElementBall.transform.parent = GameObject.Find("Ball").transform;
            // ElementBall.name = PosName[i] + "Element";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
