public static class StringTags
{
    private enum playerPrefsTags
    {
        Efectos, Musica, HighScore
    }
    public static string GetMusicString()
    {
        return (playerPrefsTags.Musica.ToString());
    }
    public static string GetEffectString()
    {
        return (playerPrefsTags.Musica.ToString());
    }
    public static string GetHighScoreString()
    {
        return (playerPrefsTags.HighScore.ToString());
    }
}
