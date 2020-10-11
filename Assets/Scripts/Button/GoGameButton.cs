using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGameButton : MonoBehaviour
{
    public int GameType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        PlayerPrefs.SetInt("GameType", GameType);
        PlayerPrefs.Save ();
        SceneManager.LoadScene("GameScene");
    }
}
