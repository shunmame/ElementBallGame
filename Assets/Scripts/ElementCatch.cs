using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementCatch : MonoBehaviour
{
    GameObject ElementBallPf;
    GameObject[] ElementBalls, ElementLimitTexts;
    bool oldisGrabbed = true, isThrow = false;
    string WhichHand;
    GameAdmin GameAdminScript;
    GameSQLController GameSQLCtlerScript;
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

    Dictionary<string, Material> MaterialDict = new Dictionary<string, Material>();

    // Start is called before the first frame update
    void Start()
    {
        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        // 残り個数表示テキストオブジェクトを取得
        ElementLimitTexts = GameObject.FindGameObjectsWithTag("ElementLimitText");
        // エレメントボールのプレファブ読み込み
        ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
        // GameAdminscriptを取得
        GameAdminScript = GameObject.Find("GameScript").GetComponent<GameAdmin>();
        // GameAdminscriptを取得
        GameSQLCtlerScript = GameObject.Find("GameScript").GetComponent<GameSQLController>();

        MaterialDict.Add("H2", Resources.Load("Material/element/H2") as Material);
        MaterialDict.Add("Cl2", Resources.Load("Material/element/Cl2") as Material);
        MaterialDict.Add("O2", Resources.Load("Material/element/O2") as Material);
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
            if(oldisGrabbed == true && this.GetComponent<OVRGrabbable>().isGrabbed == false && this.GetComponent<ElementInfo>().isCatched)
            {
                ThrowToMonster();
            }
            oldisGrabbed = this.GetComponent<OVRGrabbable>().isGrabbed;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "GrabVolumeCone")
        {
            WhichHand = collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.name;
        }
        // 当たったオブジェクトがエレメントかを確認
        if(collision.gameObject.GetComponent<ElementInfo>())
        {
            // 手に掴んでいるものですでに掴んだもの(一覧のと反応しないように)
            if(collision.gameObject.GetComponent<ElementInfo>().isCatched && this.GetComponent<OVRGrabbable>().isGrabbed)
            {
                CoalescenceElement(collision.gameObject.GetComponent<ElementInfo>().ElementName.ToString());
            }
        }
        if(collision.gameObject.name == "ElementWall")
        {
            Destroy(this.gameObject);
        }
    }

    void ThrowToMonster()
    {
        if(OVRInput.Get(OVRInput.Button.One)){
            isThrow = true;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GameAdminScript.AddThrowElementDict(this.name);
        }
    }

    private void CoalescenceElement(string PairName)
    {
        string NewElementName = GameSQLCtlerScript.GetCoalescenceElementName(this.name.ToString(), PairName);
        if(NewElementName != "None" && WhichHand == "DistanceGrabHandRight")
        {
            // 座標を前エレメントの位置にする
            GameObject ElementBall = (GameObject)Instantiate(ElementBallPf, this.transform.localPosition, Quaternion.identity);
            ElementBall.transform.localPosition = this.transform.position;
            ElementBall.name = NewElementName;
            // H2のテクスチャをはる
            ElementBall.GetComponent<Renderer>().material = MaterialDict[NewElementName];
            ElementBall.GetComponent<ElementInfo>().ElementName = NewElementName;
            // 合わせたので消す
            Destroy(this.gameObject);
            // ※恐らく2個でるので対策する
        }
        else if(WhichHand == "DistanceGrabHandLeft")
        {
            Destroy(this.gameObject);
        }
    }
}
