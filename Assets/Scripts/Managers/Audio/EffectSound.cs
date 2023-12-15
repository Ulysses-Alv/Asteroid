using UnityEngine;
using UniRx;

public abstract class EffectSound : MonoBehaviour
{
    protected AudioSource audioSource => GetComponent<AudioSource>();

    [SerializeField] protected AudioClip audioClip;

    private void Start()
    {
        VolumeManager.instance.effectsVolume.Subscribe(SetVolume);
        audioSource.clip = audioClip;
    }

    private void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
