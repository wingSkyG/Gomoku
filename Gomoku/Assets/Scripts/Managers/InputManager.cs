using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : BaseSingleton<InputManager>
    {
        private InputControls _inputControls;
        private InputAction _clickMouseLeft;

        public InputManager()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            
            _clickMouseLeft = _inputControls.UI.Click;
        }

        public void Init()
        {
            _clickMouseLeft.performed += OnMouseLeftClick;
        }
        
        private void OnMouseLeftClick(InputAction.CallbackContext callbackContext)
        {
            EventManager.Instance.Dispatch(EventName.ClickMouse);
        }

        ~InputManager()
        {
            _inputControls.Disable();
        }
    }
}