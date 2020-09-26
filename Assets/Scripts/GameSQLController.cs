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
        // test_GetCoalescenceElementName();
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

    public DataTable GetGameContent()
    {
        if(sqlDB == null)Start();
        string query = "SELECT * FROM GameContent inner join Monster on GameContent.monster_id = Monster.id";
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

    public DataTable GetUseElement()
    {
        string query = "SELECT wave, use_element, name, model_path FROM GameContent inner join Element on GameContent.use_element = Element.id";
        return sqlDB.ExecuteQuery(query);
    }

    public string GetCoalescenceElementName(string Pair1Name, string Pair2Name)
    {
        string query = "SELECT chemical_formula FROM CompoundPair where pair1 = '" + Pair1Name + "' and pair2 = '" + Pair2Name + "'";
        var dt = sqlDB.ExecuteQuery(query);
        if(dt.Rows.Count == 0)return "None";
        else return dt[0]["chemical_formula"].ToString();
    }
}
