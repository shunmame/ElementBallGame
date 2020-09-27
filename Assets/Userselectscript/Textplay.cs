using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Textplay : MonoBehaviour
{
    public MakeUser MakeUser;
    private Text targetText;
    public SqliteDatabase sqlDB;
    public string[] name = new string[100];
    public int count = 0;
    public string textplay;
    void Start()
    {
        sqlDB = new SqliteDatabase("ElementBallGame.db");
        string query = "SELECT name FROM User";
        var dt = sqlDB.ExecuteQuery(query);
        foreach (DataRow dr in dt.Rows)
        {
            name[count] = (string)dr["name"];
            Debug.Log(count.ToString() + ":" + name[count]);
            count = count + 1;
        }
        textplay = name[1];
        this.targetText = this.GetComponent<Text>();
        this.targetText.text =textplay;
    }
    void Update()
    {
    }
}