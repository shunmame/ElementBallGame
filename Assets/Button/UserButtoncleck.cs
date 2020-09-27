using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserButtoncleck : MonoBehaviour
{
    public UserName UserName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { }
    public void OnClick()
        {
        
        string testText = this.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        //Debug.Log(testText);
        this.GetComponent<UserName>().Namae=testText;
        //UserName.namae =testText;
        Debug.Log(this.GetComponent<UserName>().Namae);
    }
    
}
