using UnityEngine;

[CreateAssetMenu(menuName = "Audio/SoundBank")]
public class SoundBank : ScriptableObject
{
    public AudioClip place;
    public AudioClip explode;
    public AudioClip pickup;
    public AudioClip locked;
    public AudioClip win;
    public AudioClip death;
}