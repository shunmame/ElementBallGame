using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonprefab : MonoBehaviour
{
    public MakeUser MakeUser;
    public NewUserText NewUserText;
    public GameObject Scroll;
    void Start()
    {
        atai();
        }
        public void atai()
        {
            GameObject obj = (GameObject)Resources.Load("Button");

            for (int i = 0; i < MakeUser.count; i++)
            {
                var parent = Scroll.transform;
                GameObject aiueo = (GameObject)Instantiate(obj, transform.position, Quaternion.identity, parent);
                aiueo.transform.Find("texts").GetComponent<Text>().text = MakeUser.name[i];
            }

        }
    public void itai()
    {
        MakeUser.utai();
        GameObject obj = (GameObject)Resources.Load("Button");
        var parent = Scroll.transform;
        GameObject aiueo = (GameObject)Instantiate(obj, transform.position, Quaternion.identity ,parent);
        aiueo.transform.Find("texts").GetComponent<Text>().text = NewUserText.kiueo;
    }
    
}