using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MessageSystemMb : MonoBehaviour
{
    [Range(.1f, 10f)] [SerializeField] float fadeRate;
    [SerializeField] GameObject messagePanel;
    [SerializeField] TMP_Text messageText;

    
    [Header("Messages log")]
    [SerializeField] TMP_Text messageLogText;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] RectTransform content;
    [SerializeField] bool logScrolling = false;
    
    
    
    private CanvasGroup cg;

    private Queue<Message> messageQueue = new();
    private Message currentMessage = null;

    private IEnumerator Scroll()
    {
        logScrolling = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);

        yield return new WaitForEndOfFrame();
        scrollbar.value = 0;
        logScrolling = false;
    }

    public void LogMessage(string message)
    {
        messageLogText.text += message + "\n";
        if (logScrolling == false)
            StartCoroutine(Scroll());
    }
    
    private void Start()
    {
        MessageSystem.init(this);
        cg = GetComponent<CanvasGroup>();
    }

    public void ShowMessage()
    {
        currentMessage = null;
        if (messageQueue.Count == 0) return;
        currentMessage = messageQueue.Dequeue();
        messageText.text = currentMessage.message;
        StartCoroutine(Show());
    }

    public void AddMessage(string message, float duration)
    {
        Message newMessage = new Message(message, duration);
        messageQueue.Enqueue(newMessage);
        if (currentMessage == null) ShowMessage();
    }

    private IEnumerator Delay()
    {
         yield return new WaitForSeconds(currentMessage.displayTime);
         StartCoroutine(Hide());
    }

    private IEnumerator Show()
    {
        for (float ft = 0; ft <= 1; ft += Time.deltaTime * 1 / fadeRate)
        {
            cg.alpha = ft;
            yield return null;
        }
        cg.alpha = 1;
        StartCoroutine(Delay());
    }

    private IEnumerator Hide()
    {
        for (float ft = 0; ft >= 0; ft -= Time.deltaTime * 1 / fadeRate)
        {
            cg.alpha = ft;
            yield return null;
        }
        
        ShowMessage();
    }

    public void HelloWorld()
    {
        MessageSystem.ShowMessage("Hello World!", 2.5f);
        MessageSystem.LogMessage("Hello World!");
    }
}