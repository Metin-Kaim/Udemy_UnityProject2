using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstract.Utilities;
using UdemyProject2.Controllers;
using UdemyProject2.Enums;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class EnemyManager : SingletonMonoBehaviourObj<EnemyManager>
    {
        [SerializeField] float _addDelayTime = 50f;
        [SerializeField] EnemyController[] _enemyPrefabs;

        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        public float AddDelayTime => _addDelayTime;

        public int Count => _enemyPrefabs.Length;

        float _moveSpeed;

        private void Awake()
        {
            SingletonThisObj(this);
        }

        private void Start()
        {
            InitializePool();
        }

        void InitializePool()
        {
            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i], transform);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);
                }
                _enemies.Add((EnemyEnum)i, enemyControllers);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);
                }
            }
            EnemyController enemyController = enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_moveSpeed);

            return enemyController;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        public void SetAddDelayTime(float addDelayTime)
        {
            _addDelayTime = addDelayTime;
        }
    }
}
