using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using Newtonsoft.Json.Linq;

public class Multimeter : MonoBehaviour
{
    //[SerializeField] protected double value;
    [SerializeField] private Device device;
    [SerializeField] protected Mode mode;

    [SerializeField] private UnityEvent<double> _UpdateScreen;
    [SerializeField] private UnityEvent<double, double, double, double> _UpdateUI;


    private Mode DefaultMode = new Mode("Default", (resistance, power) => { return 0; }); // 0
    private Mode ResistanceMode = new Mode("Ω", (resistance, power) => { return resistance; }); // R
    private Mode ForceMode = new Mode("A", (resistance, power) => { return Math.Sqrt(resistance / power); }); // I = sqrt(P/R)
    private Mode VoltageMode = new Mode("V", (resistance, power) => { return Math.Sqrt(resistance * power); }); // U = sqrt(P*R)
    private Mode AlternatingCurrentMode = new Mode("V-", (resistance, power) => { return 0.01; }); // 0.01

    private void Start() 
    {
        SelectMode(DefaultMode);
        DeviceConnection(device);
    }

    private void UpdateScreen()
    {
        _UpdateScreen.Invoke(this.mode.GetValue(GetDeviseResistance(), GetDevisePower()));
    }

    private void UpdateUI()
    {
        double resistance = GetDeviseResistance();
        double power = GetDevisePower();

        _UpdateUI.Invoke(
            ForceMode.GetValue(resistance, power),
            AlternatingCurrentMode.GetValue(resistance, power),
            ResistanceMode.GetValue(resistance, power),
            VoltageMode.GetValue(resistance, power)
        );
    }

    private void SelectMode(Mode newMode)
    {
        if (this.mode != newMode)
        {
            this.mode = newMode;
            UpdateScreen();
        }
    }


    private void DeviceConnection(Device device)
    {
        changeDevice(device);
    }

    protected void DeviceDisconnection()
    {
        changeDevice(null);
    }

    private void changeDevice(Device device)
    {
        this.device = device;
        UpdateScreen();
        UpdateUI();
    }

    private double GetDeviseResistance()
    {
        return this.device == null? 0 : device.getResistance();
    }

    private double GetDevisePower()
    {
        return this.device == null ? 0 : device.getPower();
    }

    public void switchMode(float angle)
    {
        switch (angle)
        {
            case 0:
                SelectMode(DefaultMode);
                break;

            case 1:
                SelectMode(VoltageMode);
                break;

            case 2:
                SelectMode(AlternatingCurrentMode);
                break;

            case 3:
                SelectMode(ForceMode);
                break;

            case 4:
                SelectMode(ResistanceMode);
                break;
        }
    }
}