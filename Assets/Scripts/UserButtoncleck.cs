using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        string testText = this.transform.Find("texts").gameObject.GetComponent<Text>().text;
        string id = this.transform.Find("UserId").gameObject.GetComponent<Text>().text;
        this.GetComponent<UserName>().Name=testText;
        PlayerPrefs.SetString("UserName", testText);
        PlayerPrefs.SetString("Userid", id);
        PlayerPrefs.Save ();
        Debug.Log(this.GetComponent<UserName>().Name);
        SceneManager.LoadScene("TitleScene");
    }
    
}
