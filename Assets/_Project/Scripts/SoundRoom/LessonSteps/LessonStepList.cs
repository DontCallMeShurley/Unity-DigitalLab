using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LessonStepList", menuName = "Laboratory/LessonStepList")]
public class LessonStepList : ScriptableObject
{
    public List<LessonStep> Data => _data;

    [SerializeField] private List<LessonStep> _data;
}
