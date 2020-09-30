using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour
{
    Dictionary<string, int> ThrowElement = new Dictionary<string, int>();
    DataTable GameContent, GameAnswer;
    GameSQLController GameSQLCtlerScript;
    InitElementBall InitElementScript;
    Text WaveNumberText, QuestionText, ScoreText, HintText;
    GameObject NowMonster, NextMonster;
    Dictionary<int, Dictionary<string, int>> WaveAnswerDict = new Dictionary<int, Dictionary<string, int>>();
    int UserAnswerResult, OnButtonCount = 0, NowWave = 0, UserId;
    ShowResultImage ShowResultImgScript;
    Dictionary<int, int> WaveThrowScore = new Dictionary<int, int>()
    {
        {1, 100},
        {2, 50},
        {3, 30},
        {4, 10},
        {5, 0}
    };

    // Start is called before the first frame update
    void Start()
    {
        // UserId取得
        UserId = int.Parse(PlayerPrefs.GetString("UserId", "0"));
        // GameSQLscriptを取得
        GameSQLCtlerScript = GameObject.Find("GameScript").GetComponent<GameSQLController>();
        // InitElementScriptを取得
        InitElementScript = GameObject.Find("GameScript").GetComponent<InitElementBall>();
        // scoreを取得
        // ScoreScript = GameObject.Find("GameScript").GetComponent<Score>();
        // ShowResultScriptを取得
        ShowResultImgScript = GameObject.Find("CenterCanvas").transform.Find("ResultImage").gameObject.GetComponent<ShowResultImage>();
        // ゲーム内容を取得
        GameContent = GameSQLCtlerScript.GetGameContent();
        // 答えを取得
        GameAnswer = GameSQLCtlerScript.GetGameAnswer();
        // オブジェクトの取得
        WaveNumberText = GameObject.Find("WaveText").GetComponent<Text>();
        QuestionText = GameObject.Find("QuestionText").GetComponent<Text>();
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        HintText = GameObject.Find("HintText").GetComponent<Text>();
        NowMonster = GameObject.Find("NowMonster");
        NextMonster = GameObject.Find("NextMonster");
        // wave1のデータを入れる
        SetfirstWaveInfo();
        NowWave = 1;
        // 答え用の辞書作成
        CreateWaveAnswerDict(1, NowWave);
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
        WaveNumberText.text = GameContent[0]["wave"].ToString() + " / 5";
        QuestionText.text = GameContent[0]["question"].ToString();
        ScoreText.text = 0.ToString() + " P";
        HintText.text = GameContent[0]["hint"].ToString();
        // wave1のモンスター表示
        Object NowMonsterPf = Resources.Load(GameContent[0]["model_path"].ToString());
        GameObject nowMonster = (GameObject)Instantiate(NowMonsterPf, new Vector3(0, -0.4f, -0.3f), Quaternion.identity);
        nowMonster.transform.localScale = new Vector3(30, 30, 30);
        nowMonster.transform.parent = NowMonster.transform;
        // wave1の次のモンスター表示
        Object NextMonsterPf = Resources.Load(GameContent[1]["model_path"].ToString());
        GameObject nextMonster = (GameObject)Instantiate(NextMonsterPf, new Vector3(0.8f, -0.18f, -0.6f), Quaternion.Euler(0, 90, 0));
        nextMonster.transform.localScale = new Vector3(10, 10, 10);
        nextMonster.transform.localRotation = Quaternion.Euler(0, 45, 0);
        nextMonster.transform.parent = NextMonster.transform;
    }

    public void OnActionButton(string ButtonType)
    {
        bool IsPattern1 = false, IsPattern2 = false, IsPattern3 = false;
        Regex reg = new Regex("[0-9]");
        // if(ButtonType == "Flame"){}
        // else if(ButtonType == "Thunder"){}

        Dictionary<string, int> Pattern1AnsDict = new Dictionary<string, int>();
        Pattern1AnsDict =  WaveAnswerDict[1];
        foreach (var pattern1row in Pattern1AnsDict)
        {
            if(ThrowElement.ContainsKey(pattern1row.Key))
            {
                if(pattern1row.Value == ThrowElement[pattern1row.Key])IsPattern1 = true;
                else IsPattern2 = true;
            }
            else 
            {
                foreach (var keyname in ThrowElement.Keys)
                {
                    if(keyname.Contains(reg.Replace(pattern1row.Key, "")))IsPattern2 = true;
                }
                if(!IsPattern2)IsPattern3 = true;
            }
            if(!IsPattern1 && !IsPattern2)IsPattern3 = true;
            if(!IsPattern1)break;
        }
        if(IsPattern1 && IsPattern3)UserAnswerResult = 2;
        else if(IsPattern3)UserAnswerResult = 3;
        else if(IsPattern2)UserAnswerResult = 2;
        else UserAnswerResult = 1;
        ShowResultImgScript.ChangeImage(UserAnswerResult);
        ThrowElement = new Dictionary<string, int>();
        OnButtonCount += 1;

        if(UserAnswerResult == 1 || OnButtonCount == 5)
        {
            foreach(Transform child in NowMonster.transform){
                Destroy(child.gameObject);
            }
            foreach(Transform child in NextMonster.transform){
                Destroy(child.gameObject);
            }
            GameSQLCtlerScript.InsertWaveClear(UserId, int.Parse(GameContent[NowWave-1]["id"].ToString()), OnButtonCount);
            SetNextWaveInfo(WaveThrowScore[OnButtonCount]);
            PlayerPrefs.SetInt("score"+NowWave.ToString(), WaveThrowScore[OnButtonCount]);
            PlayerPrefs.Save ();
            if(NowWave == 5)Invoke("GoNextScene", 1.5f);
            OnButtonCount = 0;
        }
        InitElementScript.ResetElement();
    }

    private void GoNextScene()
    {
        GameSQLCtlerScript.InsertWaveClear(1, int.Parse(GameContent[NowWave-1]["id"].ToString()), OnButtonCount);
        SceneManager.LoadScene("ResultScene");
    }

    private void SetNextWaveInfo(int score)
    {
        NowWave += 1;
        // 次のwaveの情報入力
        WaveNumberText.text = GameContent[NowWave-1]["wave"].ToString() + " / 5";
        QuestionText.text = GameContent[NowWave-1]["question"].ToString();
        ScoreText.text = (int.Parse(ScoreText.text.ToString().Substring(0, ScoreText.text.ToString().Length - 2)) + score).ToString() + " P";
        HintText.text = GameContent[NowWave-1]["hint"].ToString();
        // 次のwaveのモンスター表示
        Object NowMonsterPf = Resources.Load(GameContent[NowWave-1]["model_path"].ToString());
        GameObject nowMonster = (GameObject)Instantiate(NowMonsterPf, new Vector3(0, -0.4f, -0.3f), Quaternion.identity);
        nowMonster.transform.localScale = new Vector3(30, 30, 30);
        nowMonster.transform.parent = NowMonster.transform;
        if(NowWave != 5)
        {
            // 次のwaveの次のモンスター表示
            Object NextMonsterPf = Resources.Load(GameContent[NowWave]["model_path"].ToString());
            GameObject nextMonster = (GameObject)Instantiate(NextMonsterPf, new Vector3(0.8f, -0.18f, -0.6f), Quaternion.Euler(0, 90, 0));
            nextMonster.transform.localScale = new Vector3(10, 10, 10);
            nextMonster.transform.localRotation = Quaternion.Euler(0, 45, 0);
            nextMonster.transform.parent = NextMonster.transform;
        }
        // 答え用の辞書作成
        CreateWaveAnswerDict(1, NowWave);
    }

    private void CreateWaveAnswerDict(int GameType, int Wave)
    {
        DataTable WaveAnswer = GameSQLCtlerScript.GetWaveGameAnswer(1, Wave);
        WaveAnswerDict = new Dictionary<int, Dictionary<string, int>>();
        string[] KeyNameList = {"pattern1", "pattern2", "pattern3"};
        for(int PatternNum = 1; PatternNum <= 3; PatternNum++)
        {
            string[] AnsElement = WaveAnswer[0]["pattern" + PatternNum.ToString() + "_element"].ToString().Split(',');
            string[] AnsElementNum = WaveAnswer[0]["pattern" + PatternNum.ToString() + "_element_required_number"].ToString().Split(',');
            Dictionary<string, int> PatternAnsDict = new Dictionary<string, int>();
            for (int i = 0; i < AnsElement.Length; i++)
            {
                PatternAnsDict.Add(AnsElement[i], int.Parse(AnsElementNum[i]));
            }
            WaveAnswerDict.Add(PatternNum, PatternAnsDict);
        }
    }
}
