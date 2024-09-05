using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, UIComponent
{
    private Button m_Button;

    public void Init()
    {
        m_Button = GetComponent<Button>();
    }

    public void OnMessageRecieved(IMessage message)
    {
        if (message.messageType == "UIButton") {
            m_Button.interactable = false;
        }
    }
}
