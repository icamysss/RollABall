public static class SceneLoader
{
    static SceneLoaderMb sceneLoader = null;

    public static bool SetReference(SceneLoaderMb sceneLoaderReference)
    {
        if (sceneLoader == null)
        {
            sceneLoader = sceneLoaderReference;
            return true;
        }
        return false;
    }

    public static int GetLevelsCount()
    {
        return sceneLoader.GetLevelsCount();
    }

    public static void LoadMainMenu()
    {
        sceneLoader.LoadMainMenu();
    }

    public static void LoadLevel(string sceneName)
    {
        sceneLoader.LoadLevel(sceneName);
    }

    public static void LoadLevel(int index)
    {
        sceneLoader.LoadLevel(index);
    }

    public static void LoadNextLevel()
    {
        sceneLoader.LoadNextLevel();
    }

    public static string GetLoadingLevelName()
    {
        return sceneLoader.GetLoadingLevelName();
    }

    public static int GetHighestLvlIndex()
    {
        return sceneLoader.GetHighestLvlIndex();
    }

    public static void LoadingComplete()
    {
        sceneLoader.LoadingComplete();
    }
}