Execution flow:
UIManager -> MessageDispatcher - > MessageBuffer -> UIText MessageBuffer: stores and processes IMessage objects

UIManager: MonoBehviour for mangement of scene interactivity, MessageDispatcher and intialization of UIComponents
MessageDispatcher: stores UIComponents and acts on its buffer, adding messages and calling process
MessageBuffer: stores IMessage objects and calls UIComponent:OnOnMessageRecieved
Message: implements the IMessage interface
UIText, UIButton: Monobehviours implementing the UIComponent interface
