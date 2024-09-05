using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour, UIComponent
{
    private TMP_Text m_Text;
    public void Init()
    {
        m_Text = GetComponent<TMP_Text>();
    }

    public void OnMessageRecieved(IMessage message)
    {
        if (message.messageType == "UIButton") {
            m_Text.text = (string)message.payload;
        }
    }
}
