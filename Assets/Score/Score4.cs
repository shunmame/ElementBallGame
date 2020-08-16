using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score4 : MonoBehaviour
{
    private Text targetText;
    public string score4 = "---";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = score4;
    }
}
