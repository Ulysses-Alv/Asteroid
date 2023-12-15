public class ShootEffect : EffectSound
{
    public static ShootEffect Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    
    public void PlayShootSound()
    {
        audioSource.Play();
    }
}
