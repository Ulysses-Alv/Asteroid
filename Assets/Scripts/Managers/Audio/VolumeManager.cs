using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager instance;
    public ReactiveProperty<float> musicVolume = new ReactiveProperty<float>(initialValue: 0);
    public ReactiveProperty<float> effectsVolume = new ReactiveProperty<float>(initialValue: 0);

    [SerializeField] private Slider musicSlider, effectSlider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectSlider.onValueChanged.AddListener(SetEffectVolume);

        musicSlider.value = PlayerPrefs.GetFloat(StringTags.GetMusicString());
        effectSlider.value = PlayerPrefs.GetFloat(StringTags.GetEffectString());
    }

    private void SetMusicVolume(float value)
    {
        musicVolume.Value = value;
        PlayerPrefs.SetFloat(StringTags.GetMusicString(), value);
    }

    private void SetEffectVolume(float value)
    {
        effectsVolume.Value = value;
        PlayerPrefs.SetFloat(StringTags.GetEffectString(), value);
    }
}
