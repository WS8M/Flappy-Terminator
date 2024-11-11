using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;
    
    public override void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }
    
    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}