using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickRFButton : MonoBehaviour
{
    ShowReactionFormula ShowRFScript;
    public string Name, Feature = "";

    // Start is called before the first frame update
    void Start()
    {
        ShowRFScript = GameObject.Find("GameScript").GetComponent<ShowReactionFormula>();
        Name = this.transform.Find("Text").GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        ShowRFScript.ShowInfo(Name, Feature, this.gameObject);
    }
}
