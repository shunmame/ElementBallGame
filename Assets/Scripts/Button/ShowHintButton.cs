using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHintButton : MonoBehaviour
{
    [SerializeField]
    Text HintText;

    // Start is called before the first frame update
    void Start()
    {
        HintText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHintOpen()
    {
        HintText.enabled = true;
    }
}
