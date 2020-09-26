using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InitElementBall : MonoBehaviour
{
    GameObject[] ElementBalls, ElementLimitTexts;
    GameSQLController GameSQLCtlerScript;
    DataTable AllElement, GameClearElement;
    List<DataRow> UseElementList = new List<DataRow>();

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
        for(int i = 0; i < UseElementList.Count(); i++)
        {
            Material ElementTextureMaterial = Resources.Load(UseElementList[i]["model_path"].ToString()) as Material;
            // Hのテクスチャをはる
            ElementBalls[i].GetComponent<Renderer>().material = ElementTextureMaterial;
            // 残り個数を代入
            ElementLimitTexts[i].GetComponent<Text>().text = "×2";
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
}
