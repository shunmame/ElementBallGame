using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text TotalScore, Score1, Score2, Score3, Score4, Score5;
    // Start is called before the first frame update
    void Start()
    {
        TotalScore = GameObject.Find("Score").GetComponent<Text>();
        Score1 = GameObject.Find("Score1").GetComponent<Text>();
        Score2 = GameObject.Find("Score2").GetComponent<Text>();
        Score3 = GameObject.Find("Score3").GetComponent<Text>();
        Score4 = GameObject.Find("Score4").GetComponent<Text>();
        Score5 = GameObject.Find("Score5").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
