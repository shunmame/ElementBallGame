using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InitElementBall : MonoBehaviour
{
    int GameType;
    GameObject ElementBallPf;
    GameObject[] ElementBalls, ElementLimitTexts;
    GameSQLController GameSQLCtlerScript;
    DataTable AllElement, GameClearElement;
    List<string> UseElementList = new List<string>();
    List<string> PosName = new List<string>(){
        "UpperLeft", "UpperCenter", "UpperRight", 
        "LowerLeft", "LowerCenter", "LowerRight"
    };
    // localPosition座標
    List<Vector3> BallPos = new List<Vector3>(){ 
        new Vector3(-0.9f, -0.511f, -1.806f),  // 左上
        new Vector3(-0.9f, -0.511f, -1.606f),  // 真ん中上
        new Vector3(-0.9f, -0.511f, -1.406f),  // 右上
        new Vector3(-0.9f, -0.711f, -1.806f),  // 左下
        new Vector3(-0.9f, -0.711f, -1.606f),  // 真ん中下
        new Vector3(-0.9f, -0.711f, -1.406f)   // 右下
    };

    // Start is called before the first frame update
    void Start()
    {
        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        // 残り個数表示テキストオブジェクトを取得
        ElementLimitTexts = GameObject.FindGameObjectsWithTag("ElementLimitText");
        // GameAdminscriptを取得
        GameSQLCtlerScript = GameObject.Find("GameScript").GetComponent<GameSQLController>();
        // すべての元素を取得
        AllElement = GameSQLCtlerScript.GetAllElement();
        // ゲームタイプの取得
        GameType = PlayerPrefs.GetInt("GameType", 1);
        GameType = 3;
        // 正解に必要とする元素を取得
        GameClearElement = GameSQLCtlerScript.GetUseElement(GameType, 1);
        // ゲームで使用できるリストを作成
        GetUseElementList();
        // エレメントボールのプレファブ読み込み
        ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
        for(int i = 0; i < UseElementList.Count(); i++)
        {
            var ElementInfo = GameSQLCtlerScript.GetElementInfo(UseElementList[i]);
            Material ElementTextureMaterial = Resources.Load(ElementInfo[0]["model_path"].ToString()) as Material;
            // Hのテクスチャをはる
            ElementBalls[i].GetComponent<Renderer>().material = ElementTextureMaterial;
            // 残り個数を代入
            ElementLimitTexts[i].GetComponent<Text>().text = "×10";
            // エレメントの名前をつける
            ElementBalls[i].GetComponent<ElementInfo>().ElementName = ElementInfo[0]["name"].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetUseElementList()
    {
        List<int> GetIndex = new List<int>();
        UseElementList = new List<string>();
        int index;
        // List<string> IgnoreElementName = new List<string> {"H2", "Cl2", "O2"};
        List<string> RecognizeElementName = new List<string> {"C", "Cl", "Cu", "Fe", "H", "Mg", "Na", "O", "S"};
        string[] AnsElementId = GameClearElement[0]["use_element"].ToString().Split(',');
        foreach(var EId in AnsElementId)
        {
            var EName = GameSQLCtlerScript.GetElementName(EId)[0]["name"].ToString();
            if(EName == "Cl2")UseElementList.Add("Cl");
            else if(EName == "O2")UseElementList.Add("O");
            else if(EName == "H2")UseElementList.Add("H");
            else UseElementList.Add(EName);
        }
        // for(var i = 0; i < 5-UseElementList.Count(); i++)
        // {
        while(UseElementList.Count() < 6)
        {
            while (true)
            {
                index = Random.Range(0, AllElement.Rows.Count);
                // if(!GetIndex.Contains(index) && !IgnoreElementName.Contains(AllElement[index]["name"].ToString()) && AllElement[index]["name"].ToString() != GameClearElement[0]["name"].ToString())break;
                if(!GetIndex.Contains(index) && RecognizeElementName.Contains(AllElement[index]["name"].ToString()) && !UseElementList.Contains(AllElement[index]["name"].ToString()))break;
            }
            GetIndex.Add(index);
            UseElementList.Add(AllElement[index]["name"].ToString());
        }
        // }
        // foreach(var item in UseElementList){Debug.Log(item);}
        ShuffleList();
    }

    private void ShuffleList()
    {
        for(int i = 0; i < UseElementList.Count(); i++)
        {
            var tmp = UseElementList[i];
            int ChangeIndex = Random.Range(i, UseElementList.Count());
            UseElementList[i] = UseElementList[ChangeIndex];
            UseElementList[ChangeIndex] = tmp;
        }
    }

    public void ResetElement(int OnButtonCount, int GameType, int NowWave)
    {
        GameClearElement = GameSQLCtlerScript.GetUseElement(GameType, NowWave);
        if(OnButtonCount == 0)GetUseElementList();
        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        foreach (var ElementBall in ElementBalls)
        {
            Destroy(ElementBall);
        }
        for(int i = 0; i < 6; i++){
            GameObject newElementBall = (GameObject)Instantiate(ElementBallPf, BallPos[i], Quaternion.identity);
            newElementBall.transform.parent = GameObject.Find("Ball").transform;
            newElementBall.name = PosName[i]+"Element";
            newElementBall.transform.localPosition = BallPos[i];
            var ElementInfo = GameSQLCtlerScript.GetElementInfo(UseElementList[i]);
            Material ElementTextureMaterial = Resources.Load(ElementInfo[0]["model_path"].ToString()) as Material;
            newElementBall.GetComponent<Renderer>().material = ElementTextureMaterial;
            newElementBall.transform.localRotation = Quaternion.Euler(0, 0, 0);
            newElementBall.GetComponent<ElementInfo>().ElementName = UseElementList[i].ToString();
            ElementLimitTexts[i].GetComponent<Text>().text = "×10";
        }
    }
}
