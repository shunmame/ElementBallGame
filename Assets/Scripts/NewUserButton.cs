using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class NewUserButton : MonoBehaviour
{
    public SqliteDatabase sqlDB;
    public MakeUser MakeUser;
    public NewUserText NewUserText;
    public Buttonprefab Buttonprefab;
    void Start()
    {
        sqlDB = new SqliteDatabase("ElementBallGame.db");
    }
    void Update()
    {

    }
    public void OnClick()
    {
        string query = "INSERT INTO User(name) VALUES ('" + NewUserText.newtext + "')";
        sqlDB.ExecuteNonQuery(query);
        Buttonprefab.makingbutton();

    }
}
