using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Score : MonoBehaviour
{

    private Text targetText;
    public int totalscore;
    public Score1 Score1;
    public Score2 Score2;
    public Score3 Score3;
    public Score4 Score4;
    public Score5 Score5;

    void Start() {
        totalscore = Score1.score1 + Score2.score2 + Score3.score3 + Score4.score4 + Score5.score5;

        this.targetText = this.GetComponent<Text>();
        this.targetText.text = totalscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
