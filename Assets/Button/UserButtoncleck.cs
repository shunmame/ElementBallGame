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
    void Update()
    { }
    public void OnClick()
        {
        
        string testText = this.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        this.GetComponent<UserName>().Name=testText;
        Debug.Log(this.GetComponent<UserName>().Name);
    }
    
}
