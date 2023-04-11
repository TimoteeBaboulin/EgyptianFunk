﻿using UnityEngine;

[CreateAssetMenu(menuName = "Create CharacterAudioProfile", fileName = "CharacterAudioProfile", order = 0)]
public class CharacterAudioProfile : ScriptableObject
{
    public AudioClip[] VoiceClips;
}