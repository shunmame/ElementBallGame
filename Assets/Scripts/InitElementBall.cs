using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InitElementBall : MonoBehaviour
{
    GameObject ElementBallPf;
    GameObject[] ElementBalls, ElementLimitTexts;
    GameSQLController GameSQLCtlerScript;
    DataTable AllElement, GameClearElement;
    List<DataRow> UseElementList = new List<DataRow>();
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
        // 正解に必要とする元素を取得
        GameClearElement = GameSQLCtlerScript.GetUseElement();
        // ゲームで使用できるリストを作成
        GetUseElementList();
        // エレメントボールのプレファブ読み込み
        ElementBallPf = (GameObject)Resources.Load("ElementBallPf");
        for(int i = 0; i < UseElementList.Count(); i++)
        {
            Material ElementTextureMaterial = Resources.Load(UseElementList[i]["model_path"].ToString()) as Material;
            // Hのテクスチャをはる
            ElementBalls[i].GetComponent<Renderer>().material = ElementTextureMaterial;
            // 残り個数を代入
            ElementLimitTexts[i].GetComponent<Text>().text = "×5";
            // エレメントの名前をつける
            ElementBalls[i].GetComponent<ElementInfo>().ElementName = UseElementList[i]["name"].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetUseElementList()
    {
        List<int> GetIndex = new List<int>();
        int index;
        List<string> IgnoreElementName = new List<string> {"H2", "Cl2", "O2"};
        
        UseElementList.Add(GameClearElement[0]);
        for(var i = 0; i < 5; i++)
        {
            while (true)
            {
                index = Random.Range(0, AllElement.Rows.Count);
                if(!GetIndex.Contains(index) && !IgnoreElementName.Contains(AllElement[index]["name"].ToString()) && AllElement[index]["name"].ToString() != GameClearElement[0]["name"].ToString())break;             
            }
            GetIndex.Add(index);
            UseElementList.Add(AllElement[index]);
        }
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

    public void ResetElement()
    {
        int counter = 0;
        bool isExist = false;
        Dictionary<string, int> CheckExist = new Dictionary<string, int>
        {
            {"UpperLeft", 0},
            {"UpperCenter", 0},
            {"UpperRight", 0}, 
            {"LowerLeft", 0},
            {"LowerCenter", 0},
            {"LowerRight", 0}
        };

        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        foreach (var ElementBall in ElementBalls)
        {
            if(ElementBall.name.Length <= 7)continue;
            Debug.Log(ElementBall.name);
            if(PosName.Contains(ElementBall.name.Substring(0, ElementBall.name.Length - 7)))
            {
                Debug.Log(ElementBall.name.Substring(0, ElementBall.name.Length - 7));
                CheckExist[ElementBall.name.Substring(0, ElementBall.name.Length - 7)] = 1;
                break;
            }
        }
        foreach (var item in CheckExist){
            if(item.Value == 0)
            {
                // Debug.Log(item.Key);
                // Debug.Log(PosName.IndexOf(item.Key));
                GameObject newElementBall = (GameObject)Instantiate(ElementBallPf, BallPos[PosName.IndexOf(item.Key)], Quaternion.identity);
                newElementBall.transform.parent = GameObject.Find("Ball").transform;
                newElementBall.name = item.Key+"Element";
                newElementBall.transform.localPosition = BallPos[PosName.IndexOf(item.Key)];
                Material ElementTextureMaterial = Resources.Load(UseElementList[PosName.IndexOf(item.Key)]["model_path"].ToString()) as Material;
                newElementBall.GetComponent<Renderer>().material = ElementTextureMaterial;
                newElementBall.transform.localRotation = Quaternion.Euler(0, 0, 0);
                newElementBall.GetComponent<ElementInfo>().ElementName = UseElementList[PosName.IndexOf(item.Key)]["name"].ToString();  
            }
        }
        CheckExist = new Dictionary<string, int>
        {
            {"UpperLeft", 0},
            {"UpperCenter", 0},
            {"UpperRight", 0}, 
            {"LowerLeft", 0},
            {"LowerCenter", 0},
            {"LowerRight", 0}
        };
        for(int i = 0; i < ElementLimitTexts.Count(); i++)
        {
            // 残り個数を代入
            ElementLimitTexts[i].GetComponent<Text>().text = "×5";
        }
    }
}
