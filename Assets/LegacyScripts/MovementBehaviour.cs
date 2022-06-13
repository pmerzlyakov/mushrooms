using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;
using LegacyMushrooms.Extensions.EntityToGameObject;

namespace LegacyMushrooms
{
    public class MovementBehaviour : MonoBehaviour
    {
        private LayerMask _layerMask;

        private Camera _mainCamera;

        private PlayerControls _playerControls;
        private InputAction _touch;
        private InputAction _touchPosition;

        private Transform _selectedObject;

        private EcsWorld _world;

        public void SetWorld(EcsWorld world)
        {
            _world = world;
        }

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
                _selectedObject = hit.transform;
            }
            else
            {
                _selectedObject = null;
            }
        }

        private void EndTouchHandler(InputAction.CallbackContext ctx)
        {
            var touchPosition = _touchPosition.ReadValue<Vector2>();
            var ray = _mainCamera.ScreenPointToRay(touchPosition);
            Debug.Log($"end touch at {touchPosition}");

            if ((object)_selectedObject == null) return;

            if (Physics.SphereCast(ray, 3f, out RaycastHit hit, 100f, _layerMask))
            {
                var targetObject = hit.transform;
                int targetEntity = targetObject.GetProvider().Entity;

                var movementsReqs = _world.GetPool<StartMovementRequest>();
                int selectedEntity = _selectedObject.GetProvider().Entity;

                ref var req = ref movementsReqs.Add(selectedEntity);
                req.AllyHouseEntity = selectedEntity;
                req.EnemyHouseEntity = targetEntity;
            }
        }
    }
}
