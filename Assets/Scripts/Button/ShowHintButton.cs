using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHintButton : MonoBehaviour
{
    [SerializeField]
    Text HintText;
    
    GameAdmin GameAdminScript;

    // Start is called before the first frame update
    void Start()
    {
        HintText.enabled = false;
        GameAdminScript = GameObject.Find("GameScript").GetComponent<GameAdmin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHintOpen()
    {
        if(!HintText.enabled)GameAdminScript.ShowHint();
        HintText.enabled = true;
    }
}
