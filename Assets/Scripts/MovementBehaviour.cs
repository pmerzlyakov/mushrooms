using UnityEngine;
using UnityEngine.InputSystem;

namespace Mushrooms
{
    public class MovementBehaviour : MonoBehaviour
    {
        private LayerMask _layerMask;

        private Camera _mainCamera;

        private PlayerControls _playerControls;
        private InputAction _touch;
        private InputAction _touchPosition;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _layerMask = LayerMask.GetMask("Selectable");

            _playerControls = new PlayerControls();
            _touch = _playerControls.GameControls.Touch;
            _touchPosition = _playerControls.GameControls.TouchPosition;

            _touch.performed += StartTouchHandler;
            _touch.canceled += EndTouchHandler;
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        private void StartTouchHandler(InputAction.CallbackContext ctx)
        {
            var touchPosition = _touchPosition.ReadValue<Vector2>();
            var ray = _mainCamera.ScreenPointToRay(touchPosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, _layerMask))
            {
                Debug.Log($"start touch {hit.transform.name}");
            }
        }

        private void EndTouchHandler(InputAction.CallbackContext ctx)
        {
            var touchPosition = _touchPosition.ReadValue<Vector2>();
            var ray = _mainCamera.ScreenPointToRay(touchPosition);
            Debug.Log($"end touch at {touchPosition}");
            
            if (Physics.SphereCast(ray, 3f, out RaycastHit hit, 100f, _layerMask))
            {
                var mushrooms = GameObject.FindGameObjectsWithTag("Player");
                foreach (var mushroom in mushrooms)
                {
                    
                }
                Debug.Log($"oh, you touch my talala {hit.transform.name}");
            } 
        }
    }
}