using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementCatch : MonoBehaviour
{
    GameObject Text1, Text2;
    GameObject[] ElementBalls, ElementLimitTexts;
    List<Vector3> BallPosInScript = new List<Vector3>(){ 
        new Vector3(-0.9f, 0.18f, -1.2f),  // 左上
        new Vector3(-0.9f, 0.18f, -1.0f),  // 真ん中上
        new Vector3(-0.9f, 0.18f, -0.8f),  // 右上
        new Vector3(-0.9f, 0.06f, -1.2f),  // 左下
        new Vector3(-0.9f, 0.06f, -1.0f),  // 真ん中下
        new Vector3(-0.9f, 0.06f, -0.8f)   // 右下
    };

    List<Vector3> BallPosInScene = new List<Vector3>(){ 
        new Vector3(-0.9f, -0.1f, -1.5f),  // 左上
        new Vector3(-0.9f, -0.1f, -1.3f),  // 真ん中上
        new Vector3(-0.9f, -0.1f, -1.1f),  // 右上
        new Vector3(-0.9f, -0.2f, -1.5f),  // 左下
        new Vector3(-0.9f, -0.2f, -1.3f),  // 真ん中下
        new Vector3(-0.9f, -0.2f, -1.1f)   // 右下
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
    }

    // Update is called once per frame
    void Update()
    {
        // for(int i = 0; i < 6; i++)
        // {
        //     // Debug.Log(ElementLimitTexts[i].GetComponent<Text>().name);
        //     // 元素オブジェクトが掴まれていて かつ 元素オブジェクトと残り個数表示テキストオブジェクトの名前が一緒だったら
        //     if(this.GetComponent<OVRGrabbable>().isGrabbed && this.name.Substring(0, this.name.Length - 7) == ElementLimitTexts[i].GetComponent<Text>().name)
        //     {
        //         Text1.GetComponent<Text>().text = BallPos[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))].ToString();
        //         // Text2.GetComponent<Text>().text = ElementLimitTexts[i].GetComponent<Text>().name;
        //         // 残り個数表示テキストオブジェクトのテキストを変更
        //         ElementLimitTexts[i].GetComponent<Text>().text = "catch!";
        //         // 新しく元素オブジェクトを作成する
        //         GameObject ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
        //         GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, BallPos[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))], Quaternion.identity);
        //         ElementBall.transform.parent = GameObject.Find("Ball").transform;
        //         ElementBall.name = PosName[i] + "Element";

        //     }
        // }

        // 元素オブジェクトが掴まれていて かつ 元素オブジェクトと残り個数表示テキストオブジェクトの名前が一緒だったら
        if(this.GetComponent<OVRGrabbable>().isGrabbed)
        {
            // Text1.GetComponent<Text>().text = BallPos[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))].ToString();
            // 残り個数表示テキストオブジェクトのテキストを変更
            // ElementLimitTexts[i].GetComponent<Text>().text = "catch!";
            // 新しく元素オブジェクトを作成する
            int existcount = 0;
            for (int i = 0; i < ElementBalls.Length; i++){
                
                if(this.name == ElementBalls[i].name && ElementBalls[i].GetComponent<OVRGrabbable>().isGrabbed == false)
                {
                    existcount += 1;
                    Debug.Log("this.name: " + this.name);
                    Debug.Log("Element: " + ElementBalls[i].name);
                    Debug.Log("isgrabbed: " + ElementBalls[i].GetComponent<OVRGrabbable>().isGrabbed);
                }
            }
            if(existcount == 0)
            {
                GameObject ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
                GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, BallPosInScript[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))], Quaternion.identity);
                ElementBall.transform.parent = GameObject.Find("Ball").transform;
                ElementBall.name = this.name;
                ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
                // Invoke("CreateElementObject", 1f);
            }
        }
    }

    public void CreateElementObject()
    {
        GameObject ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
        GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, BallPosInScript[PosName.IndexOf(this.name.Substring(0, this.name.Length - 7))], Quaternion.identity);
        ElementBall.transform.parent = GameObject.Find("Ball").transform;
        ElementBall.name = this.name;
    }
}
