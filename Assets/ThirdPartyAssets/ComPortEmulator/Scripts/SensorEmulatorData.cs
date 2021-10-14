using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSensorEmulatorData", menuName = "SensorEmulator/Create SensorEmulatorData")]
public class SensorEmulatorData : ScriptableObject
{
    [SerializeField]
    private string emulatorName;

    [SerializeField]
    private string template;

    [SerializeField]
    private float minValue;

    [SerializeField]
    private float maxValue;

    [SerializeField]
    private float multiplier;

    [SerializeField]
    private float period;

    private float t;

    private float value;

    public string EmulatorName { get { return emulatorName; } }

    public void UpdateValue(float deltaTime)
    {
        t += deltaTime / period;

        float y = Mathf.Sin(t * Mathf.PI * 2);
        value = multiplier * (minValue + (maxValue - minValue) * (y + 1) * 0.5f);
    }

    public string ReadLine()
    {
        return string.Format(template, (int)value);
    }
}