using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    [SerializeField]
    Canvas ExitGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        ExitGameCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDialogOpen()
    {
        ExitGameCanvas.enabled = true;
    }

    public void OnExit(){
        Application.Quit();
    }

    public void OnCancel(){
        ExitGameCanvas.enabled = false;
    }
}
