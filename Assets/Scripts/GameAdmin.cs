using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAdmin : MonoBehaviour
{
    Dictionary<string, int> ThrowElement = new Dictionary<string, int>();
    DataTable GameContent, GameAnswer;
    GameSQLController GameSQLCtlerScript;
    GameObject WaveNumberText, QuestionText, ScoreText, HintText;

    // Start is called before the first frame update
    void Start()
    {
        // GameAdminscriptを取得
        GameSQLCtlerScript = GameObject.Find("GameScript").GetComponent<GameSQLController>();
        // ゲーム内容を取得
        GameContent = GameSQLCtlerScript.GetGameContent();
        // 答えを取得
        GameAnswer = GameSQLCtlerScript.GetGameAnswer();
        // オブジェクトの取得
        WaveNumberText = GameObject.Find("WaveText");
        QuestionText = GameObject.Find("QuestionText");
        ScoreText = GameObject.Find("ScoreText");
        HintText = GameObject.Find("HintText");
        // wave1のデータを入れる
        SetfirstWaveInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddThrowElementDict(string keyname)
    {
        if(ThrowElement.ContainsKey(keyname))
        {
            ThrowElement[keyname] = ThrowElement[keyname] + 1;
        }
        else
        {
            ThrowElement.Add(keyname, 1);
        }
    }

    private void SetfirstWaveInfo()
    {
        // wave1の情報入力
        WaveNumberText.GetComponent<Text>().text = GameContent[0]["wave"].ToString() + " / 5";
        QuestionText.GetComponent<Text>().text = GameContent[0]["question"].ToString();
        ScoreText.GetComponent<Text>().text = 0.ToString() + " P";
        HintText.GetComponent<Text>().text = GameContent[0]["hint"].ToString();
        // wave1のモンスター表示
        Object MonsterPf_H = Resources.Load(GameContent[0]["model_path"].ToString());
        GameObject Monster = (GameObject)Instantiate(MonsterPf_H, new Vector3(0, -0.4f, -0.3f), Quaternion.identity);
        Monster.transform.localScale = new Vector3(30, 30, 30);
        Monster.transform.parent = GameObject.Find("NowMonster").transform;
    }

    public void OnActionButton(string ButtonType)
    {
        // if(ButtonType == "Flame"){}
        // else if(ButtonType == "Thunder"){}
        
        // 正解か確認して、辞書を初期化
        // 投げたカウントをプラス1
    }
}
