using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour
{
    GameObject FlameEffect, ThunderEffect, EffectParent;
    GameAdmin GameAdminScript;

    // Start is called before the first frame update
    void Start()
    {
        // gameobject取得
        EffectParent = GameObject.Find("Effect");
        FlameEffect = EffectParent.transform.Find("TinyExplosion").gameObject;
        ThunderEffect = EffectParent.transform.Find("PlasmaExplosionEffect").gameObject;
        // エフェクト非表示
        FlameEffect.SetActive(false);
        ThunderEffect.SetActive(false);
        // GameAdminscriptを取得
        GameAdminScript = GameObject.Find("GameScript").GetComponent<GameAdmin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFlameButton()
    {
        Debug.Log("Flame");
        FlameEffect.gameObject.SetActive(true);
        GameAdminScript.OnActionButton("Flame");
        Invoke("DisabledFlameEffect", 2f);
    }

    public void OnThunderButton()
    {
        Debug.Log("Thunder");
        ThunderEffect.gameObject.SetActive(true);
        GameAdminScript.OnActionButton("Thunder");
        Invoke("DisabledThunderEffect", 2f);
    }

    private void DisabledFlameEffect()
    {
        FlameEffect.gameObject.SetActive(false);
    }

    private void DisabledThunderEffect()
    {
        ThunderEffect.gameObject.SetActive(false);
    }
}
