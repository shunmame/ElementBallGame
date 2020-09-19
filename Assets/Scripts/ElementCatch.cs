using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementCatch : MonoBehaviour
{
    GameObject ElementBallPf, NowMonster;
    GameObject[] ElementBalls, ElementLimitTexts; 
    Material elementH2_material;
    bool oldisGrabbed = true, isThrow = false;
    // localPosition座標
    List<Vector3> BallPos = new List<Vector3>(){ 
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
        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        // 残り個数表示テキストオブジェクトを取得
        ElementLimitTexts = GameObject.FindGameObjectsWithTag("ElementLimitText");
        // エレメントボールのプレファブ読み込み
        ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
        // Hのマテリアル取得
        elementH2_material = Resources.Load("Material/element/H2") as Material;
        // 今のモンスター取得
        NowMonster = GameObject.Find("NowMonster");
    }

    // Update is called once per frame
    void Update()
    {
        if(isThrow)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, 
                                                   new Vector3(0, -0.4f, 0.2f), 
                                                   1f * Time.deltaTime);
        }
        else
        {
            var LimitNumber = 0;
            // 元素オブジェクトが掴まれていて
            if(this.GetComponent<OVRGrabbable>().isGrabbed)
            {
                var CatchElement = this.name;
                this.name = this.GetComponent<ElementInfo>().ElementName;
                this.GetComponent<ElementInfo>().isCatched = true;
                if(!GameObject.Find(CatchElement) && CatchElement.Length > 7)
                {
                    // 残り個数
                    LimitNumber = int.Parse(ElementLimitTexts[PosName.IndexOf(CatchElement.Substring(0, CatchElement.Length - 7))].GetComponent<Text>().text.Substring(1));
                    // 新しく元素オブジェクトを作成する
                    if(LimitNumber != 1)
                    {
                        GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, BallPos[PosName.IndexOf(CatchElement.Substring(0, CatchElement.Length - 7))], Quaternion.identity);
                        ElementBall.transform.parent = GameObject.Find("Ball").transform;
                        ElementBall.name = CatchElement;
                        ElementBall.transform.localPosition = BallPos[PosName.IndexOf(CatchElement.Substring(0, CatchElement.Length - 7))];
                        ElementBall.GetComponent<Renderer>().material = this.GetComponent<Renderer>().material;
                        ElementBall.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        ElementBall.GetComponent<ElementInfo>().ElementName = this.GetComponent<ElementInfo>().ElementName;
                        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
                    }
                    ElementLimitTexts[PosName.IndexOf(CatchElement.Substring(0, CatchElement.Length - 7))].GetComponent<Text>().text = "×" + (LimitNumber-1).ToString();
                }
            }
            if(oldisGrabbed == true && this.GetComponent<OVRGrabbable>().isGrabbed == false)
            {
                ThrowToMonster();
            }
            oldisGrabbed = this.GetComponent<OVRGrabbable>().isGrabbed;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        // 当たったオブジェクトがエレメントかを確認
        if(collision.gameObject.GetComponent<ElementInfo>())
        {
            // 手に掴んでいるものですでに掴んだもの(一覧のと反応しないように)
            if(collision.gameObject.GetComponent<ElementInfo>().isCatched && this.GetComponent<OVRGrabbable>().isGrabbed)
            {
                // エレメントだったらどの元素か確認して
                if(collision.gameObject.GetComponent<ElementInfo>().ElementName == "H")
                {
                    // 新しいエレメントを生成してテクスチャを張る
                    // 座標を前エレメントの位置にする
                    GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, this.transform.localPosition, Quaternion.identity);
                    ElementBall.transform.localPosition = this.transform.position;
                    ElementBall.name = "H2";
                    // H2のテクスチャをはる
                    ElementBall.GetComponent<Renderer>().material = elementH2_material;
                    ElementBall.GetComponent<ElementInfo>().ElementName = "H2";
                    // 合わせたので消す
                    Destroy(this.gameObject);
                    // ※恐らく2個でるので対策する
                }
            }
        }
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "ElementWall")
        {
            Destroy(this.gameObject);
        }
    }

    void ThrowToMonster()
    {
        // 離れた時
        if(OVRInput.Get(OVRInput.Button.One)){
            Debug.Log("離れた");
            isThrow = true;
        }
    }
}
