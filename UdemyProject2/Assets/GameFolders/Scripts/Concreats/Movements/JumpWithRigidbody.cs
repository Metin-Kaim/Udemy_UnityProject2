using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstract.Movements;
using UdemyProject2.Controllers;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class JumpWithRigidbody : IJump
    {
        Rigidbody _rigidbody;

        public JumpWithRigidbody(PlayerController playerController)
        {
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick(float _jumpForce)
        {
            if (_rigidbody.velocity.y != 0) return;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(_jumpForce * Time.deltaTime * Vector3.up);

        }
    }
}
