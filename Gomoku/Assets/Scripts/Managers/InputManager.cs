using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : BaseSingleton<InputManager>
    {
        public InputAction _clickAction;
        
        private InputControls _inputControls;

        public InputManager()
        {
            _inputControls = new InputControls();
            _clickAction = _inputControls.UI.Click;
            
            _inputControls.Enable();
        }

        ~InputManager()
        {
            _inputControls.Disable();
        }
    }
}