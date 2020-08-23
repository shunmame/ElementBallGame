using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementCatch : MonoBehaviour
{
    GameObject Text1, Text2;
    GameObject[] ElementBalls, ElementLimitTexts; 
    
    // 表示する座標
    List<Vector3> LocalBallPos = new List<Vector3>(){ 
        new Vector3(-0.9f, -0.2f, -1.5f),  // 左上
        new Vector3(-0.9f, -0.2f, -1.3f),  // 真ん中上
        new Vector3(-0.9f, -0.2f, -1.1f),  // 右上
        new Vector3(-0.9f, -0.4f, -1.5f),  // 左下
        new Vector3(-0.9f, -0.4f, -1.3f),  // 真ん中下
        new Vector3(-0.9f, -0.4f, -1.1f)   // 右下
    };
    
    // 比較用の座標
    List<Vector3> CompareBallPos = new List<Vector3>(){ 
        new Vector3(-0.9f, -0.511f, -1.806f),  // 左上
        new Vector3(-0.9f, -0.511f, -1.606f),  // 真ん中上
        new Vector3(-0.9f, -0.511f, -1.406f),  // 右上
        new Vector3(-0.9f, -0.711f, -1.806f),  // 左下
        new Vector3(-0.9f, -0.711f, -1.606f),  // 真ん中下
        new Vector3(-0.9f, -0.711f, -1.406f)   // 右下
    };

    List<string> PosName = new List<string>(){
        "UpperLeft", "UpperCenter", "UpperRight", 
        "LowerLeft", "LowerCenter", "LowerRight"
    };

    // Start is called before the first frame update
    void Start()
    {
        Text1 = GameObject.Find("Text1");
        Text2 = GameObject.Find("Text2");
        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        // 残り個数表示テキストオブジェクトを取得
        ElementLimitTexts = GameObject.FindGameObjectsWithTag("ElementLimitText");
        for(int i = 0; i < ElementBalls.Length; i++)
        {
            for(int j = 0; j < 6; j++){
                if(ElementBalls[i].transform.localPosition == CompareBallPos[j])
                {
                        Debug.Log("name: " + ElementBalls[i].name);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var LimitNumber = 0;
        // 元素オブジェクトが掴まれていて
        if(this.GetComponent<OVRGrabbable>().isGrabbed)
        {
            // 残り個数
            LimitNumber = int.Parse(ElementLimitTexts[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))].GetComponent<Text>().text.Substring(1));
            // 元素リストにすべてあるか確認する。なかったら下の生成をする。
            int existcount = 0;
            for (int i = 0; i < ElementBalls.Length; i++)
            {
                if(this.name == ElementBalls[i].name && ElementBalls[i].GetComponent<OVRGrabbable>().isGrabbed == false)
                {
                    for(int j = 0; j < 6; j++){
                        if(ElementBalls[i].transform.localPosition == CompareBallPos[j])
                        {
                            existcount += 1;
                        }
                    }
                }
            }
            // 後で大量に表示されてしまうので修正する
            // 新しく元素オブジェクトを作成する
            if(existcount == 0 && LimitNumber > 0)
            {
                if(LimitNumber != 1)
                {
                    GameObject ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
                    GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, LocalBallPos[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))], Quaternion.identity);
                    ElementBall.transform.parent = GameObject.Find("Ball").transform;
                    ElementBall.name = this.name;
                    ElementBall.GetComponent<Renderer>().material = this.GetComponent<Renderer>().material;
                    ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
                }
                ElementLimitTexts[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))].GetComponent<Text>().text = "×" + (LimitNumber-1).ToString();
            }
        }
    }
}
