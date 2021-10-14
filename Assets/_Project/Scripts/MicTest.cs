using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicTest : MonoBehaviour
{
	public AudioSource aud;

	bool isHaveMicroPhone;
	string device;
	public Text text;

	//Debug Text
	public Text clipLength;//Length of recording audio files
	public Text devicePosition;//Location of device audio
	public Text audioTime;//Time of recording audio
	public Text audioSampleTime;//


	// Start is called before the first frame update
	void Start()
	{
		aud = GetComponent<AudioSource>();
		string[] devices = Microphone.devices;

		if (devices.Length > 0)
		{
			isHaveMicroPhone = true;
			device = devices[0];
			text.text = devices[0];
		}
		else
		{
			isHaveMicroPhone = false;
			text.text = "No microphone was available";
		}
	}

	//Start Recording Button
	public void OnclickButton()
	{
		if (!isHaveMicroPhone) return;

		aud.clip = Microphone.Start(device, true, 10, 10000);
		//aud.Play();
		//aud.timeSamples = Microphone.GetPosition(device);
		//aud.timeSamples = 0;
		Debug.Log("Start recording");
	}

	//Start Playing Button
	public void OnPlay()
	{
		aud.Play();
		aud.timeSamples = Microphone.GetPosition(device);//When set up here, it will be almost real-time synchronization.

		int min;
		int max;
		Microphone.GetDeviceCaps(device, out min, out max);
		//aud.timeSamples = 0;
		Debug.Log("Start playing" + min + " " + max);
	}




	private void Update()
	{
		//clipLength.text = "     clipLength:" + aud.clip.length;
		//devicePosition.text = " devicePosition:" + Microphone.GetPosition(device);
		//audioTime.text = "      audioTime:" + aud.time;
		//audioSampleTime.text = "audioSampleTime:" + aud.timeSamples;

		//Debug.Log("     clipLength:" + aud.clip.length);
		//Debug.Log(" devicePosition:" + Microphone.GetPosition(device));
		//Debug.Log("      audioTime:" + aud.time);
		//Debug.Log("audioSampleTime:" + aud.timeSamples);

		//aud.timeSamples = Microphone.GetPosition(device);
	}
}