using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "Laboratory/SoundLibrary")]
public class SoundLibrary : ScriptableObject
{
	public List<Sound> Data => _data;

	[SerializeField] private List<Sound> _data;
}
