using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SerialPortWrapper : MonoBehaviour
{
    [SerializeField]
    private List<SensorEmulatorData> sensorEmulators;
    [SerializeField]
    private SerialPortWrapperSettings settings;
    [SerializeField]
    private Dropdown selectSensorDropdown;
    [SerializeField]
    private Toggle isEmulatingToggle;
    [SerializeField]
    private Text listEmptiyText;
    [SerializeField]
    private Text restartSceneText;
    [SerializeField]
    private GameObject canvas;


    private SerialPort serialPort;
    //private SensorEmulatorData sensorEmulator;
    private string portName;
    private bool isOpen;
    private int baudRate;
    private int readTimeout;
    private List<Dropdown.OptionData> optionDatas;

    private bool isWindowOpen;

    #region MonoBehaviour

    private void Start()
    {
        Hide();
        listEmptiyText.gameObject.SetActive(false);
        restartSceneText.gameObject.SetActive(false);

        if(sensorEmulators.Count == 0)
        {
            Debug.LogError("Emulators List is empty");
            listEmptiyText.gameObject.SetActive(true);
            settings.IsEmulating = false;
            isEmulatingToggle.interactable = false;
            selectSensorDropdown.interactable = false;
            return;
        }

        isEmulatingToggle.isOn = settings.IsEmulating;
        isEmulatingToggle.onValueChanged.AddListener(delegate { IsEmulatingToggleChanged(isEmulatingToggle); });
        
        List<string> names = new List<string>();
        foreach (var sensorEmulator in sensorEmulators)
        {
            names.Add(sensorEmulator.EmulatorName);
        }

        selectSensorDropdown.ClearOptions();
        selectSensorDropdown.AddOptions(names);

        if(settings.CurrentEmulator < 0 || settings.CurrentEmulator > selectSensorDropdown.options.Count)
        {
            settings.CurrentEmulator = 0;
        }

        selectSensorDropdown.value = settings.CurrentEmulator;
        selectSensorDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(selectSensorDropdown); });



        if (!settings.IsEmulating)
        {
            serialPort = new SerialPort();
        }
    }

    private void Update()
    {
        if (!isWindowOpen && Input.GetKeyDown(KeyCode.F9))
        {
            Show();
        }

        if (settings.IsEmulating)
        {
            sensorEmulators[settings.CurrentEmulator].UpdateValue(Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        if (settings.IsEmulating)
        {

        }
        else
        {
            serialPort.Dispose();
        }
    }

    #endregion

    #region Public Methods

    public void CloseButton_onClick()
    {
        Hide();
    }

    #endregion

    #region Private Methods

    private void Show()
    {
        isWindowOpen = true;
        canvas.SetActive(true);
    }

    private void Hide()
    {
        isWindowOpen = false;
        canvas.SetActive(false);
    }

    private void IsEmulatingToggleChanged(Toggle change)
    {
        settings.IsEmulating = change.isOn;
        restartSceneText.gameObject.SetActive(true);
    }

    private void DropdownValueChanged(Dropdown change)
    {
        Debug.Log($"New Value :{change.value} - {change.options[change.value].text}");
        settings.CurrentEmulator = change.value;
    }

    #endregion

    #region SerialPort Members

    #region Properties

    public bool IsOpen
    {
        get
        {
            if (settings.IsEmulating)
            {
                return isOpen;
            }
            else
            {
                return serialPort.IsOpen;
            }
        }
    }

    public string PortName
    {
        get
        {
            if (settings.IsEmulating)
            {
                return portName;
            }
            else
            {
                return serialPort.PortName;
            }
        }
        set
        {
            if (settings.IsEmulating)
            {
            }
            else
            {
                serialPort.PortName = value;
            }
        }
    }

    /// <summary>
    /// DefaultValue(-1)
    /// </summary>
    public int ReadTimeout
    {
        get
        {
            if (settings.IsEmulating)
            {
                return readTimeout;
            }
            else
            {
                return serialPort.ReadTimeout;
            }
        }
        set
        {
            if (settings.IsEmulating)
            {
                readTimeout = value;
            }
            else
            {
                serialPort.ReadTimeout = value;
            }
        }
    }

    /// <summary>
    /// DefaultValue(9600)
    /// </summary>
    public int BaudRate
    {
        get
        {
            if (settings.IsEmulating)
            {
                return baudRate;
            }
            else
            {
                return serialPort.BaudRate;
            }
        }
        set
        {
            if (settings.IsEmulating)
            {
                baudRate = value;
            }
            else
            {
                serialPort.BaudRate = value;
            }
        }
    }

    #endregion

    #region Methods

    public void Open()
    {
        if (settings.IsEmulating)
        {
            isOpen = true;
        }
        else
        {
            serialPort.Open();
        }
    }

    public void Close()
    {
        if (settings.IsEmulating)
        {
            isOpen = false;
        }
        else
        {
            serialPort.Close();
        }
    }

    public string ReadLine()
    {
        if (settings.IsEmulating)
        {
            return sensorEmulators[settings.CurrentEmulator].ReadLine();
        }
        else
        {
            return serialPort.ReadLine();
        }
    }

    public void DiscardInBuffer()
    {
        if (settings.IsEmulating)
        {
        }
        else
        {
            serialPort.DiscardInBuffer();
        }
    }

    #endregion

    #endregion

}