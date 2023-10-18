using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class EnemyFlipPresenter : IPresenter
    {
        private Enemy _enemy;
        private EnemyView _enemyView;

        public EnemyFlipPresenter(Enemy enemy, EnemyView enemyView)
        {
            _enemy = enemy;
            _enemyView = enemyView;
        }

        public void Subscribe()
        {
            _enemy.DirectionAssigned += OnFlip;
        }

        public void Unsubscribe()
        {
            _enemy.DirectionAssigned -= OnFlip;
        }

        private void OnFlip(Vector3 obj)
        {
            bool isFlip = obj.x < 0;
            if(isFlip)
            {
                _enemyView.transform.rotation = Quaternion.Euler(new Vector3(_enemyView.transform.rotation.x, 
                    180, _enemyView.transform.rotation.z));
            }
            else
            {
                _enemyView.transform.rotation = Quaternion.Euler(new Vector3(_enemyView.transform.rotation.x,
                    0, _enemyView.transform.rotation.z));
            }
        }
    }
}