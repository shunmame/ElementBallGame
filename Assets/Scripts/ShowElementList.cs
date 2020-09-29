using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowElementList : MonoBehaviour
{
    GameObject ElementDiv, InfoCanvas, ButtonCanvas, newButtonCanvas;
    GameSQLController GameSQLCtlerScript;
    DataTable AllElement;

    // Start is called before the first frame update
    void Start()
    {
        InfoCanvas = GameObject.Find("InfoCanvas");
        ElementDiv = GameObject.Find("ElementDiv");
        // GameSQLscriptを取得
        GameSQLCtlerScript = GameObject.Find("GameScript").GetComponent<GameSQLController>();
        // すべての元素取得
        AllElement = GameSQLCtlerScript.GetAllElement();
        // ボタンCanvas取得
        ButtonCanvas = GameObject.Find("ElementList_H").transform.Find("Canvas").gameObject;
        // list生成
        foreach(Transform childElement in ElementDiv.transform){
            var Namearr = childElement.gameObject.name.Split('_');
            childElement.transform.Find("Sphere").transform.Find("ElementBallName").GetComponent<TextMesh>().text = Namearr[1];
            if(childElement.name != "ElementList_H")
            {
                newButtonCanvas = (GameObject)Instantiate(ButtonCanvas);
                newButtonCanvas.transform.parent = childElement.transform;
                newButtonCanvas.transform.localPosition = new Vector3(0, 0, 0);
                newButtonCanvas.transform.localScale = new Vector3(1, 1, 1);
                newButtonCanvas.transform.Find("Button").GetComponent<OnClickSphere>().ElementName = Namearr[1];
            }
        }
        // InfoCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowInfoCanvas(string ElementName)
    {
        foreach (DataRow ElementRow in AllElement.Rows)
        {
            if(ElementRow["name"].ToString() == ElementName)
            {
                InfoCanvas.transform.Find("Symbol").GetComponent<Text>().text = ElementRow["name"].ToString();
                InfoCanvas.transform.Find("AtomicWeight").GetComponent<Text>().text = ElementRow["atomic_weight"].ToString();
                InfoCanvas.transform.Find("Feature").GetComponent<Text>().text = ElementRow["feature"].ToString();
                InfoCanvas.transform.Find("ChemicalReactionFormula").GetComponent<Text>().text = ElementRow["example"].ToString();
                InfoCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void CloseWindow()
    {
        InfoCanvas.gameObject.SetActive(false);
    }
}
