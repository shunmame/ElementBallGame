using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSphere : MonoBehaviour
{
    public string ElementName;
    ShowElementList ShowElementListScript;

    // Start is called before the first frame update
    void Start()
    {
        ShowElementListScript = GameObject.Find("GameScript").GetComponent<ShowElementList>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        ShowElementListScript.ShowInfoCanvas(ElementName, this.gameObject);
    }
}
