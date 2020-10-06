using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowReactionFormula : MonoBehaviour
{
    GameObject InfoCanvas;
    Text NameText, FeatureText;
    Image StructureImg1, StructureImg2, StructureImg3; 
    Dictionary<int, Vector3> InfoCanvasRotation = new Dictionary<int, Vector3>()
    {
        {1, new Vector3(0, -45, 0)},
        {2, new Vector3(0, -45, 0)},
        {3, new Vector3(0, 0, 0)},
        {4, new Vector3(0, 0, 0)},
        {5, new Vector3(0, 45, 0)},
        {6, new Vector3(0, 45, 0)}
    };

    // Start is called before the first frame update
    void Start()
    {
        InfoCanvas = GameObject.Find("InfoCanvas");
        if(this.name != "Button")
        {
            InfoCanvas.gameObject.SetActive(false);
            NameText = InfoCanvas.transform.Find("ReactionFormula").GetComponent<Text>();
            FeatureText = InfoCanvas.transform.Find("Feature").GetComponent<Text>();
            StructureImg1 = InfoCanvas.transform.Find("StructureImage1").GetComponent<Image>();
            StructureImg2 = InfoCanvas.transform.Find("StructureImage2").GetComponent<Image>();
            StructureImg3 = InfoCanvas.transform.Find("StructureImage3").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInfo(string Name, string Feature, GameObject OnButton, List<Sprite> StructureImg)
    {
        NameText.text = Name;
        FeatureText.text = Feature;
        InfoCanvas.transform.parent = OnButton.transform.parent.transform.parent.transform;
        InfoCanvas.transform.localPosition = new Vector3(0, 0, -50);
        string RootName = OnButton.transform.root.gameObject.name.ToString();
        int CanvasNum = int.Parse(RootName.Substring(RootName.Length - 1));
        InfoCanvas.transform.rotation = Quaternion.Euler(InfoCanvasRotation[CanvasNum]);
        if(StructureImg.Count >= 1)StructureImg1.sprite = StructureImg[0]; else StructureImg1.sprite = null;
        if(StructureImg.Count >= 2)StructureImg2.sprite = StructureImg[1]; else StructureImg2.sprite = null;
        if(StructureImg.Count >= 3)StructureImg3.sprite = StructureImg[2]; else StructureImg3.sprite = null;
        InfoCanvas.gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        InfoCanvas.gameObject.SetActive(false);
    }
}
