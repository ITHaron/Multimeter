using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultimeterSwitch : Multimeter
{
    public void switchMode(float angle)
    {
        switch (angle)
        {
            case >= 330 or <= 30:
                SelectMode(DefaultMode);
                break;

            case >= 30 and <= 60:
                SelectMode(VoltageMode);
                break;

            case >= 120 and <= 150:
                SelectMode(AlternatingCurrentMode);
                break;

            case >= 210 and <= 240:
                SelectMode(ForceMode);
                break;

            case >= 300 and <= 330:
                SelectMode(ResistanceMode);
                break;
        }
    }
}
