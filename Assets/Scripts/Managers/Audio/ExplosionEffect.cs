public class ExplosionEffect : EffectSound
{
   
    public static ExplosionEffect Instance { get; private set;}
    private void Awake()
    {
        Instance = this;
    }
    public void PlayExplosion()
    {
        audioSource.Play();
    }
   
}