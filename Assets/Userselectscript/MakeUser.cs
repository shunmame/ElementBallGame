using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MakeUser : MonoBehaviour
{


    public SqliteDatabase sqlDB;
    public string[] name = new string[100];
    public int[] id = new int[100];
    public int count = 0;
    public int count2 = 0;
    public string username;
    public int userid;
    void Start()
    {
        utai();
        /*
        sqlDB = new SqliteDatabase("ElementBallGame.db");
        string query = "SELECT name FROM User";
        string ids = "SELECT id FROM User";
        var dt = sqlDB.ExecuteQuery(query);
        var dl = sqlDB.ExecuteQuery(ids);
        foreach (DataRow dr in dt.Rows)
        {
            name[count] = (string)dr["name"];
            Debug.Log(count.ToString() + ":" + name[count]);
            count = count + 1;
        }

        foreach (DataRow dr in dl.Rows)
        {
            id[count2] = (int)dr["id"];
            Debug.Log(count2.ToString() + ":" + id[count2].ToString());
            count2 = count2 + 1;
        }
        */

    }

    public void utai()
    {
        sqlDB = new SqliteDatabase("ElementBallGame.db");
        string query = "SELECT name FROM User";
        string ids = "SELECT id FROM User";
        var dt = sqlDB.ExecuteQuery(query);
        var dl = sqlDB.ExecuteQuery(ids);
        foreach (DataRow dr in dt.Rows)
        {
            name[count] = (string)dr["name"];
            Debug.Log(count.ToString() + ":" + name[count]);
            count = count + 1;
        }

        foreach (DataRow dr in dl.Rows)
        {
            id[count2] = (int)dr["id"];
            Debug.Log(count2.ToString() + ":" + id[count2].ToString());
            count2 = count2 + 1;
        }

    }

}

