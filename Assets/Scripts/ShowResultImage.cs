using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResultImage : MonoBehaviour
{
    public Sprite CircleImage;
    public Sprite TriangleImage;
    public Sprite XImage;

    private Image ImageComp;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        ImageComp = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage(int UserAnswerResult)
    {
        ImageComp = this.GetComponent<Image>();
        if(UserAnswerResult == 1)ImageComp.sprite = CircleImage;
        else if(UserAnswerResult == 2)ImageComp.sprite = TriangleImage;
        else if(UserAnswerResult == 3)ImageComp.sprite = XImage;
        this.gameObject.SetActive(true);
        Invoke("DisabledResultImage", 1f);
    }

    private void DisabledResultImage()
    {
        this.gameObject.SetActive(false);
    }
}
