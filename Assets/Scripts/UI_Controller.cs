using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class UI_Controller : MonoBehaviour
{
    private UIDocument canvas;

    [SerializeField] private Label resistance;
    [SerializeField] private Label force;
    [SerializeField] private Label voltage;
    [SerializeField] private Label alternatingCurrent;
    
    private void Awake() {
        canvas = GetComponent<UIDocument>();

        force = canvas.rootVisualElement.Q<Label>("A_Value");
        alternatingCurrent = canvas.rootVisualElement.Q<Label>("Vn_Value");
        resistance = canvas.rootVisualElement.Q<Label>("R_Value");
        voltage = canvas.rootVisualElement.Q<Label>("V_Value");
    }

    public void UpdateUI(double force, double alternatingCurrent, double resistance, double voltage)
    {
        this.force.text = Math.Round(force, 2).ToString();
        this.alternatingCurrent.text = Math.Round(alternatingCurrent, 2).ToString();
        this.resistance.text = Math.Round(resistance, 2).ToString();
        this.voltage.text = Math.Round(voltage, 2).ToString();
    }
}
