using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Health : MonoBehaviour
{
    Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = Player.Instance.Health.ToString();
    }
}
