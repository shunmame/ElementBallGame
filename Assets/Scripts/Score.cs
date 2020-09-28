using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text TotalScore, Score1, Score2, Score3, Score4, Score5;
    int Score1Num, Score2Num, Score3Num, Score4Num, Score5Num;
    // Start is called before the first frame update
    void Start()
    {
        TotalScore = GameObject.Find("score").GetComponent<Text>();
        Score1 = GameObject.Find("score1").GetComponent<Text>();
        Score2 = GameObject.Find("score2").GetComponent<Text>();
        Score3 = GameObject.Find("score3").GetComponent<Text>();
        Score4 = GameObject.Find("score4").GetComponent<Text>();
        Score5 = GameObject.Find("score5").GetComponent<Text>();

        Score1Num = PlayerPrefs.GetInt("score1", 0);
        Score2Num = PlayerPrefs.GetInt("score2", 0);
        Score3Num = PlayerPrefs.GetInt("score3", 0);
        Score4Num = PlayerPrefs.GetInt("score4", 0);
        Score5Num = PlayerPrefs.GetInt("score5", 0);

        Score1.text = Score1Num.ToString();
        Score2.text = Score2Num.ToString();
        Score3.text = Score3Num.ToString();
        Score4.text = Score4Num.ToString();
        Score5.text = Score5Num.ToString();

        TotalScore.text = (Score1Num + Score2Num + Score3Num + Score4Num + Score5Num).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
