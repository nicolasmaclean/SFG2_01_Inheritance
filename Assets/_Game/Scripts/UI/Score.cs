using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    public static Score Instance;
    public static int Current;
    
    Text _text;

    public static void Update(int delta)
    {
        Current += delta;
        if (Instance) Instance.UpdateText();
    }

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _text = GetComponent<Text>();
    }

    void UpdateText()
    {
        _text.text = Current.ToString();
    }
}
