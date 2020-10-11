using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject PauseImage;
    // Start is called before the first frame update
    void Start()
    {
        // if(this.name == "PauseButton")Debug.Log("aaaaaaaaaaaaaaaaaaa");
        // PauseImage = GameObject.Find("PauseImage");
        PauseImage.gameObject.SetActive(false);
        // Debug.Log(this.name);
        // else if(this.name == )
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseImage()
    {
        PauseImage.gameObject.SetActive(true);
    }

    public void StopGame()
    {
        SceneManager.LoadScene("SelectStageScene");
    }

    public void ReStartGame()
    {
        PauseImage.gameObject.SetActive(false);
    }
}
