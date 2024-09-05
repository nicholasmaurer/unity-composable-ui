using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MessageBuffer: a queue, messages are added to the queue by the dispatcher, the message dispatcher calls process on the buffer with a list of ui components
// MessageClass: implements IMessage
// UIManager: has a dispatcher, knows about UIComponents, registers UIComponents to dispatcher, dispatches messages from UIComponents, calls the dispatcher to process
// UIComponents: interface for initialization and receiving messages from the buffer
// MessageDispatcher: has message buffer and list of ui components, register them with list, send them to buffer, process buffer

public class Message : IMessage
{
    public string messageType { get; set; }
    public object payload { get; set; }

    public Message(string messageType, object payload)
    {
        this.messageType = messageType;
        this.payload = payload;
    }
}

public class MessageBuffer
{
    public Queue<IMessage> messages = new Queue<IMessage>();

    public void AddMessage(IMessage message)
    {
        messages.Enqueue(message);
    }

    public void ProcessMessages(UIComponent[] uIComponents)
    {
        while (messages.Count > 0) { 
            var message = messages.Dequeue();
            foreach(UIComponent uIComponent in uIComponents) { 
                uIComponent.OnMessageRecieved(message);
            }
        }
    }
}

public interface UIComponent
{
    public void Init();
    public void OnMessageRecieved(IMessage message);
}

public interface IMessage
{
    public string messageType { get; set; }
    public object payload { get; set; }
}

public class MessageDispatcher
{
    public MessageBuffer buffer = new MessageBuffer();
    public List<UIComponent> uIComponents = new List<UIComponent>();

    public void RegisterComponent(UIComponent uIComponent)
    {
        uIComponents.Add(uIComponent);
    }

    public void SendMessage(IMessage message)
    {
        buffer.AddMessage(message);
    }

    public void Process()
    {
        buffer.ProcessMessages(uIComponents.ToArray());
    }
}