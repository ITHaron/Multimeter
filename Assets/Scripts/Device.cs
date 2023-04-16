using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour
{
    [SerializeField] private double resistance;
    [SerializeField] private double power;

    // [SerializeField] private GameObject positive_contact;
    // [SerializeField] private GameObject negative_contact;

    public double getResistance()
    {
        return resistance;
    }

    public double getPower()
    {
        return power;
    }
}
