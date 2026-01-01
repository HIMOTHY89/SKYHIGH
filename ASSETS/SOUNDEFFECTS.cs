using System;
using UnityEngine;

[System.Serializable]
public struct CONTENTS
{
    public string GroupID;
    public AudioClip[] clips;
}

public class SOUNDEFFECTS : MonoBehaviour
{
    public CONTENTS[] SOUNDS;

    public AudioClip Manager (string name)
    {
        foreach (var CONTENTS in SOUNDS)
        {
            if (CONTENTS.GroupID == name)
            {
                
                return CONTENTS.clips[UnityEngine.Random.Range(0, CONTENTS.clips.Length)];
            }
        }
    
        return null;

        
    }
}
