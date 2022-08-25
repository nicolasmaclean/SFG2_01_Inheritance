using UnityEngine;

[CreateAssetMenu(menuName = "Data/Audio")]
public class SOAudioClip : ScriptableObject
{
    public AudioClip Clip;
    
    [Range(0, 1)]
    public float Volume = 1;

    public static AudioSource PlayClip(SOAudioClip clip, bool Oneshot = false)
    {
        GameObject go = new GameObject("Audio Clip 2D");
        AudioSource source = go.AddComponent<AudioSource>();
        
        clip.Load(source);
        source.Play();
        Object.Destroy(go, clip.Clip.length);
        
        return source;
    }

    public void Load(AudioSource source)
    {
        source.clip = Clip;
        source.volume = Volume;
    }
}