using UnityEngine;

public class MessageSender : MonoBehaviour
{
    public string senderName;
    public string message;
    public float duration;

    public void SendMessage()
    { 
        var str = senderName + ": " + message; ;
        MessageSystem.ShowMessage(str, duration);
    }

    public void SendLog()
    {
        var str = senderName + ": " + message; ;
        MessageSystem.LogMessage(str);
    }
}