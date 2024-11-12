using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private KeyCode _attackButton;
    
    private bool _readyToCLear;
    
    public bool AttackInput { get; private set; }
    public bool JumpInput { get; private set; }
    
    
    private void Update()
    {
        if (_readyToCLear) 
            ClearInputs();

        ProcessInputs();
    }
    
    private void FixedUpdate()
    {
        _readyToCLear = true;
    }
    
    private void ProcessInputs()
    {
        JumpInput = JumpInput || Input.GetKeyDown(_jumpButton);
        AttackInput = AttackInput || Input.GetKeyDown(_attackButton);
    }

    private void ClearInputs()
    {
        JumpInput = false;
        AttackInput = false;

        _readyToCLear = false;
    }
}
