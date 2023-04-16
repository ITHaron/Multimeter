using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Screen : MonoBehaviour
{
    [SerializeField] private TextMeshPro screen_text;

    private void Awake() {
        screen_text = transform.GetComponent<TextMeshPro>();
    }

    public void ScreenUpdate(double value)
    {
        screen_text.text = Math.Round(value, 2).ToString();
    }
}

