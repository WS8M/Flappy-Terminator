using System;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;
    
    public override void Open()
    {
        WindowGroup.alpha =1f;
        ActionButton.interactable = true;    
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }
    
    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}