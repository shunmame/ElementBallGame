using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MyTextDB : MonoBehaviour
{
    string[] UserClearTexts;
    List<List<int>> UserClearList = new List<List<int>>();
    // Start is called before the first frame update
    void Start()
    {
        UserClearTexts = File.ReadAllLines("Assets/Scripts/UserClearDB.txt");
        foreach (var text in UserClearTexts) {
			Debug.Log ("各行表示： " + text);
            UserClearList.Add(new List<int>(Array.ConvertAll(text.Split(','), int.Parse)));
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertClearData(int user_id, int game_id, int throw_count)
    {
        string[] InsertData = new string[UserClearList.Count + 1];
        UserClearList.Add(new List<int>(new int[] {UserClearList.Count+1, user_id, game_id, throw_count}));
        for(int i = 0; i < UserClearList.Count; i++)
        {
            InsertData[i] = UserClearList[i][0].ToString() + "," + UserClearList[i][1].ToString() + "," + UserClearList[i][2].ToString() + "," + UserClearList[i][3].ToString();
        }
        File.WriteAllLines("Assets/Scripts/UserClearDB.txt", InsertData);
    }
}
