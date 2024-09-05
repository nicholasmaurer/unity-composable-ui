using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public MessageDispatcher dispatcher = new MessageDispatcher();

    [SerializeField] UIText m_UIText;
    [SerializeField] UIButton m_UIButton;

    void Start()
    {
        m_UIText.Init();
        m_UIButton.Init();
        dispatcher.RegisterComponent(m_UIText);
        dispatcher.RegisterComponent(m_UIButton);

        m_UIButton.GetComponent<Button>().onClick.AddListener(() => 
            dispatcher.SendMessage(new Message("UIButton", "Disabled")
        ));
        
    }

    void Update()
    {
        dispatcher.SendMessage(new Message("UIText", "?"));
        dispatcher.Process();
    }
}
