using UnityEngine;
using UniRx;

public class MusicAudioManager : MonoBehaviour
{
    private AudioSource audioSource => GetComponent<AudioSource>();

    [SerializeField] private AudioClip musicClip;

    private void Start()
    {
        audioSource.clip = musicClip;
        audioSource.Play();
        audioSource.loop = true;

        VolumeManager.instance.musicVolume.Subscribe(SetVolume);
    }

    private void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
