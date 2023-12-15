public class DeathEffect : EffectSound
{
    public static DeathEffect Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void PlayDeath()
    {
        audioSource.Play();
    }
}