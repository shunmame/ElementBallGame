using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowElementList : MonoBehaviour
{
    GameObject ElementDiv, InfoCanvas, ButtonCanvas, newButtonCanvas, InfoElement, InfoCanvasObject;
    GameSQLController GameSQLCtlerScript;
    DataTable AllElement;

    // Start is called before the first frame update
    void Start()
    {
        InfoCanvas = GameObject.Find("InfoCanvas");
        InfoElement = GameObject.Find("InfoElement");
        InfoCanvasObject = GameObject.Find("InfoCanvasObject");
        if(this.name != "Button")
        {
            InfoCanvas.gameObject.SetActive(false);
            InfoElement.gameObject.SetActive(false);
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
                    newButtonCanvas.transform.localPosition = new Vector3(0, 0, -45);
                    newButtonCanvas.transform.localScale = new Vector3(1, 1, 1);
                    newButtonCanvas.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    newButtonCanvas.transform.Find("Button").transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    newButtonCanvas.transform.Find("Button").GetComponent<OnClickSphere>().ElementName = Namearr[1];
                }
                else
                {
                    ButtonCanvas.transform.localPosition = new Vector3(0, 0, -45);
                    ButtonCanvas.transform.localScale = new Vector3(1, 1, 1);
                    ButtonCanvas.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    ButtonCanvas.transform.Find("Button").transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowInfoCanvas(string ElementName, GameObject OnSphere)
    {
        GameObject SphereObject, newSphereObject;
        foreach (DataRow ElementRow in AllElement.Rows)
        {
            if(ElementRow["name"].ToString() == ElementName)
            {
                InfoCanvas.transform.Find("Symbol").GetComponent<Text>().text = ElementRow["name"].ToString();
                InfoCanvas.transform.Find("AtomicWeight").GetComponent<Text>().text = ElementRow["atomic_weight"].ToString();
                InfoCanvas.transform.Find("Feature").GetComponent<Text>().text = ElementRow["feature"] != null ? ElementRow["feature"].ToString() : "";
                InfoCanvas.transform.Find("ChemicalReactionFormula").GetComponent<Text>().text = ElementRow["example"] != null ? ElementRow["example"].ToString() : "";
                InfoCanvas.transform.Find("ElementName").GetComponent<Text>().text = ElementRow["jp_name"].ToString();
                InfoCanvasObject.transform.rotation = OnSphere.transform.parent.gameObject.transform.parent.gameObject.transform.rotation;
                InfoElement.transform.Find("Sphere").transform.Find("ElementBallName").GetComponent<TextMesh>().text = ElementRow["name"].ToString();
                InfoCanvasObject.transform.position = OnSphere.transform.parent.gameObject.transform.parent.gameObject.transform.position + new Vector3(0, 0, -0.15f);
                InfoCanvas.gameObject.SetActive(true);
                InfoElement.gameObject.SetActive(true);
            }
        }
    }

    public void CloseWindow()
    {
        InfoCanvas.gameObject.SetActive(false);
        InfoElement.gameObject.SetActive(false);
    }
}
