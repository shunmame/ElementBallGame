using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    //public int totalscore;
    private Text targetText;
    public string score = "---";
    // Start is called before the first frame update
    void Start()
    {

        //totalsocre=int.Parse(score1) + int.Parse(score2) + int.Parse(score3) + int.Parse(score4) + int.Parse(score5);
    }

    // Update is called once per frame
    void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text =score;
    }
}
