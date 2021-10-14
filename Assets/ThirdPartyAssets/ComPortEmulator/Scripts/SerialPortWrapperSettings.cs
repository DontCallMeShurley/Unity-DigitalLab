using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SerialPortWrapperSettings", menuName = "SensorEmulator/Create SerialPortWrapperSettings")]

public class SerialPortWrapperSettings : ScriptableObject
{
    public bool IsEmulating;
    public int CurrentEmulator;
}
