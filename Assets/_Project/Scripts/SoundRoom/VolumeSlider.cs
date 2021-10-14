using UnityEngine;
using UnityEngine.UI;

using Bluehorse.Game.Messages;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;


    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        MessageBus.OnAnalyzeSound.Receive += SoundReader02_OnAnalyzeSound;
        //SoundReader02.OnAnalyzeSound += SoundReader02_OnAnalyzeSound;
    }

    private void SoundReader02_OnAnalyzeSound(float[] obj)
    {
        //text.text = $"{obj[1]} Гц";

        slider.value = Mathf.Lerp(slider.value, obj[0], 2 * Time.deltaTime);
    }

    private void OnDestroy()
    {
        MessageBus.OnAnalyzeSound.Receive -= SoundReader02_OnAnalyzeSound;
    }
}