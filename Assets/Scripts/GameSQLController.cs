using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSQLController : MonoBehaviour
{
    public SqliteDatabase sqlDB;
    MyTextDB TextDB;

    // Start is called before the first frame update
    void Start()
    {
        sqlDB = new SqliteDatabase("ElementBallGame.db");
        TextDB = GameObject.Find("GameScript").GetComponent<MyTextDB>();
        // test_GetCoalescenceElementName();
        // test_GetUseElement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test_GetCoalescenceElementName()
    {
        Debug.Log(GetCoalescenceElementName("H", "H"));
        Debug.Log(GetCoalescenceElementName("H", "Cl"));
    }

    private void test_GetUseElement()
    {
        GetUseElement(2, 1);
    }

    public DataTable GetGameContent(int GameType)
    {
        if(sqlDB == null)Start();
        string query = "SELECT * FROM GameContent inner join Monster on GameContent.monster_id = Monster.id where game_type = " + GameType;
        return sqlDB.ExecuteQuery(query);
    }

    public DataTable GetGameAnswer()
    {
        string query = "SELECT * FROM GameAnswer inner join GameContent on GameAnswer.game_id = GameContent.id";
        return sqlDB.ExecuteQuery(query);
    }

    public DataTable GetWaveGameAnswer(int GameType, int Wave)
    {
        string query = "SELECT * FROM GameAnswer inner join GameContent on GameAnswer.game_id = GameContent.id where GameContent.wave = " + Wave + " and GameContent.game_type = " + GameType;
        return sqlDB.ExecuteQuery(query);
    }

    public DataTable GetAllElement()
    {
        if(sqlDB == null)Start();
        string query = "SELECT * FROM Element";
        return sqlDB.ExecuteQuery(query);
    }

    public DataTable GetUseElement(int GameType, int Wave)
    {
        string query = "SELECT id FROM GameContent where wave = " + Wave + " and game_type = " + GameType;
        var game_id = sqlDB.ExecuteQuery(query)[0];
        query = "SELECT * FROM GameAnswer where game_id = " + game_id["id"];
        return sqlDB.ExecuteQuery(query);
    }

    public string GetCoalescenceElementName(string Pair1Name, string Pair2Name)
    {
        string query = "SELECT chemical_formula FROM CompoundPair where pair1 = '" + Pair1Name + "' and pair2 = '" + Pair2Name + "'";
        var dt = sqlDB.ExecuteQuery(query);
        if(dt.Rows.Count == 0)return "None";
        else return dt[0]["chemical_formula"].ToString();
    }

    public void InsertWaveClear(int user_id, int game_id, int throw_count)
    {
        TextDB.InsertClearData(user_id, game_id, throw_count);
    }

    public DataTable GetElementInfo(string EName)
    {
        string query = "SELECT * FROM Element where name = '" + EName + "'";
        return sqlDB.ExecuteQuery(query);
    }
}
