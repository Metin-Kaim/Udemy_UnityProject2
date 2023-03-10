using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstract.Controllers;
using UdemyProject2.Abstract.Movements;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class VerticalMover : IMover
    {
        IEntityController _entityController;

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void FixedTick(float vertical = 1)
        {
            _entityController.transform.Translate(Vector3.back * vertical * _entityController.MoveSpeed * Time.deltaTime);
        }
    }

}
