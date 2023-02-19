using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstract.Controllers;
using UdemyProject2.Abstract.Inputs;
using UdemyProject2.Abstract.Movements;
using UdemyProject2.Inputs;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MyCharacterController,IEntityController
    {
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;

        IMover _mover;
        IJump _jump;
        IInputReader _input;

        bool _isDead = false;

        float _horizontal;

        private void Awake()
        {
            _mover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void Update()
        {
            if (_isDead) return;

            _horizontal = _input.Horizontal;
            _isJump = _input.IsJump;
        }

        private void FixedUpdate()
        {
            _mover.FixedTick(_horizontal);

            if (_isJump)
            {
                _jump.FixedTick(_jumpForce);
            }

            _isJump = false;

        }

        private void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.gameObject.GetComponent<IEntityController>();

            if (entityController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }

}
