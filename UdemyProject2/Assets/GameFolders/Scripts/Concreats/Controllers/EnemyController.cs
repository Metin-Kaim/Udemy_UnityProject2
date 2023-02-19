using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstract.Controllers;
using UdemyProject2.Enums;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        VerticalMover _mover;


        [SerializeField] float _maxLifeT�me = 5f;
        [SerializeField] EnemyEnum _enemyEnum;

        public EnemyEnum EnemyType => _enemyEnum;


        float _currentLifeTime = 0f;

        private void Awake()
        {
            _mover = new VerticalMover(this);
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > _maxLifeT�me)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }
        }
        private void FixedUpdate()
        {
            _mover.FixedTick();
        }

        private void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }
        public void SetMoveSpeed(float moveSpeed)
        {
            if (moveSpeed < _moveSpeed) return;

            _moveSpeed = moveSpeed;
        }
    }

}
