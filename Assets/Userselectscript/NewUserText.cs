﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUserText : MonoBehaviour
{
    public InputField inputField;
    public Text text;
    public string kiueo;

    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
    }

    public void InputText()
    {
        text.text = inputField.text;
        kiueo = text.text;
    }

}