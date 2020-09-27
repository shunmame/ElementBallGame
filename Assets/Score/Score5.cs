using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score5 : MonoBehaviour
{
    private Text targetText;
    public int score5;
    // Start is called before the first frame update
    void Start()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = score5.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
