using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstract.Controllers;
using UdemyProject2.Abstract.Movements;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class HorizontalMover : IMover
    {
        IEntityController _entityController;
        public HorizontalMover(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void FixedTick(float horizontal)
        {
            if (horizontal == 0) return;

            _entityController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _entityController.MoveSpeed);

            float exBoundary = Mathf.Clamp(_entityController.transform.position.x, -_entityController.MoveBoundary, _entityController.MoveBoundary);
            _entityController.transform.position = new Vector3(exBoundary,_entityController.transform.position.y, _entityController.transform.position.z);

            //_playerController.transform.position = new Vector3(Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary), _playerController.transform.position.y, _playerController.transform.position.z);
        }
    }

}
