using System;
using System.Collections.Generic;
using HuaweiService.appmessage;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    public Text title;
    public Text description;
    public GameObject panel;

    public Button click;
    public Button dismiss;

    private UnityAction clickAction;
    private UnityAction dismissAction;

    public static PopupMessage instance;
    
    public static Queue<Action> jobs = new Queue<Action>();

    public void Start()
    {
        instance = this;
    }

    public void Update()
    {
        while (jobs.Count > 0)
        {
            jobs.Dequeue().Invoke();
        }
    }
    
    // hide message and remove callback
    public void HideMessage()
    {
        panel.SetActive(false);
        click.onClick.RemoveListener(clickAction);
        dismiss.onClick.RemoveListener(dismissAction);
    }

    // put show message into job queue, since setActive could only be called in main thread
    public static void Show(AppMessage message, AGConnectAppMessagingCallback callback)
    {
        jobs.Enqueue(()=>instance.ShowMessage(message, callback));
    }
    
    // show message and add callback
    public void ShowMessage(AppMessage message, AGConnectAppMessagingCallback callback)
    {
        panel.SetActive(true);
        if (message != null)
        {
            description.text = $"{message.getId()}";
        }

        if (callback != null)
        {
            clickAction = () =>
            {
                callback.onMessageClick(message);
            };
            click.onClick.AddListener(clickAction);
            
            dismissAction = () =>
            {
                callback.onMessageDismiss(message, AGConnectAppMessagingCallback.DismissType.CLICK);
            };
            dismiss.onClick.AddListener(dismissAction);
        }
    }
}
