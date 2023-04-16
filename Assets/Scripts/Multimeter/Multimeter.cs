using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using Newtonsoft.Json.Linq;

public abstract class Multimeter : MonoBehaviour
{
    //[SerializeField] protected double value;
    [SerializeField] private Device device;
    [SerializeField] protected Mode mode;

    [SerializeField] protected UnityEvent<double> _UpdateScreen;
    [SerializeField] protected UnityEvent<double, double, double, double> _UpdateUI;


    protected Mode DefaultMode = new Mode("Default", (resistance, power) => { return 0; }); // 0
    protected Mode ResistanceMode = new Mode("Ω", (resistance, power) => { return resistance; }); // R
    protected Mode ForceMode = new Mode("A", (resistance, power) => { return Math.Sqrt(resistance / power); }); // I = sqrt(P/R)
    protected Mode VoltageMode = new Mode("V", (resistance, power) => { return Math.Sqrt(resistance * power); }); // U = sqrt(P*R)
    protected Mode AlternatingCurrentMode = new Mode("V-", (resistance, power) => { return 0.01; }); // 0.01

    private void Start() 
    {
        SelectMode(DefaultMode);
        DeviceConnection(device);
    }

    public void UpdateScreen()
    {
        _UpdateScreen.Invoke(this.mode.GetValue(GetDeviseResistance(), GetDevisePower()));
    }

    protected void UpdateUI()
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

    protected void SelectMode(Mode newMode)
    {
        if (this.mode != newMode)
        {
            this.mode = newMode;
            UpdateScreen();
        }
    }


    protected void DeviceConnection(Device device)
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

    //protected double GetResistance()
    //{
    //    return device.getResistance(); // R
    //}

    //protected double GetForce()
    //{
    //    return Math.Sqrt(device.getResistance() / device.getPower()); // I = sqrt(P/R)
    //}

    //protected double GetVoltage()
    //{
    //    return Math.Sqrt(device.getResistance() * device.getPower()); // U = sqrt(P*R)
    //}

    //protected double GetAlternatingСurrent()
    //{
    //    return 0.01;
    //}
}