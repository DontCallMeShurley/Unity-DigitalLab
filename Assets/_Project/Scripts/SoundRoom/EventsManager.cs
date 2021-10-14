using Bluehorse.Game.Messages;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    //public static event Action<bool> OnPitchDeviceSetActive;
    //public static event Action<bool> OnVolumeDeviceSetActive;

    bool b1 = true, b2 = true;

    private void Start()
    {
        //PitchDeviceSetActive();
        //VolumeDeviceSetActive();
    }

    public void PitchDeviceSetActive()
    {
        MessageBus.OnPitchDeviceSetActive.Send(b1);
        //OnPitchDeviceSetActive?.Invoke(b1);
        b1 = !b1;
    }

    public void VolumeDeviceSetActive()
    {
        MessageBus.OnVolumeDeviceSetActive.Send(b2);
        //OnVolumeDeviceSetActive?.Invoke(b2);
        b2 = !b2;
    }

    public void TemperatureDeviceSetActive()
    {
        MessageBus.OnTemperatureDeviceSetActive.Send(b1);
        //OnPitchDeviceSetActive?.Invoke(b1);
        b1 = !b1;
    }
}
