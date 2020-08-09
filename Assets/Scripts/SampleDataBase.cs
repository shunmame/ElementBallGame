using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDataBase : MonoBehaviour {

    public SqliteDatabase sqlDB;

    void Start(){
　　　　　sqlDB = new SqliteDatabase("ElementBallGame.db");
　　　　　string query = "SELECT * FROM example";
　　　　　var dt = sqlDB.ExecuteQuery(query);

        string name;
        int dummy;
        foreach(DataRow dr in dt.Rows){
            name = (string)dr["name"];
            dummy = (int)dr["dummy"];
            Debug.Log("name:" + name.ToString());
            Debug.Log("dummy:" + dummy);
        }
    }
}