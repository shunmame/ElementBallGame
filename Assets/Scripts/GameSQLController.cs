using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSQLController : MonoBehaviour
{
    public SqliteDatabase sqlDB;

    // Start is called before the first frame update
    void Start()
    {
        sqlDB = new SqliteDatabase("ElementBallGame.db");
        // string query = "SELECT * FROM GameContent";
        // var dt = sqlDB.ExecuteQuery(query);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DataTable GetGameContent()
    {
        if(sqlDB == null)Start();
        string query = "SELECT * FROM GameContent inner join Monster on GameContent.monster_id = Monster.id";
        return sqlDB.ExecuteQuery(query);
    }

    public DataTable GetGameAnswer()
    {
        string query = "SELECT * FROM GameAnswer";
        return sqlDB.ExecuteQuery(query);
    }
}
