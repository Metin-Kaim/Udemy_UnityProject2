using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Abstract.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }

        public float MoveSpeed { get; }
        public float MoveBoundary { get; }
    }

}
