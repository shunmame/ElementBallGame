using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score2 : MonoBehaviour
{
    private Text targetText;
    public int score2 ;
    // Start is called before the first frame update
    void Start()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
