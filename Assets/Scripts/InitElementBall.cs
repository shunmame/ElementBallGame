using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitElementBall : MonoBehaviour
{
    GameObject[] ElementBalls, ElementLimitTexts;

    // Start is called before the first frame update
    void Start()
    {
        // 元素オブジェクトを取得
        ElementBalls = GameObject.FindGameObjectsWithTag("ElementBall");
        // 残り個数表示テキストオブジェクトを取得
        ElementLimitTexts = GameObject.FindGameObjectsWithTag("ElementLimitText");
        // Hのマテリアル取得
        Material elementH_material = Resources.Load("Material/element/H") as Material;

        for(int i = 0; i < 6; i++)
        {
            // Hのテクスチャをはる
            ElementBalls[i].GetComponent<Renderer>().material = elementH_material;
            // 残り個数を代入
            ElementLimitTexts[i].GetComponent<Text>().text = "×2";
            // エレメントの名前をつける
            ElementBalls[i].GetComponent<ElementInfo>().ElementName = "H";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
