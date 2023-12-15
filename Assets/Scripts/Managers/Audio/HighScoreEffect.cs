public class HighScoreEffect : EffectSound
{
    public static HighScoreEffect Instance { get; private set;}

    private void Awake()
    {
        Instance = this;
    }
    public void PlayHighscore()
    {
        audioSource.Play();
    }
}
