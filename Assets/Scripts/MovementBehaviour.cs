using UnityEngine;
using UnityEngine.InputSystem;

namespace Mushrooms
{
    public class MovementBehaviour : MonoBehaviour
    {
        [SerializeField] float _speed = 3f;

        private Rigidbody _rigidbody;
        private @PlayerControls _playerControls;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerControls = new @PlayerControls();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        private void FixedUpdate()
        {
            var move = _playerControls.GameControls.Movement.ReadValue<Vector2>();
            var moveVector3 = new Vector3(move.x, 0, move.y);
            var newPostition = transform.position + moveVector3 * _speed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPostition);
        }
    }
}