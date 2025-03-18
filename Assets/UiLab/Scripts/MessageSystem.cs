public static class MessageSystem
{
    private static MessageSystemMb msLink;

    public static void init(MessageSystemMb ms)
    {
        msLink = ms;
    }

    public static void ShowMessage(string message, float duration)
    {
        if (msLink != null) msLink.AddMessage(message, duration);
    }

    public static void LogMessage(string message)
    {
        msLink.LogMessage(message);
    }
    
}