using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class EnemyAttackPresenter : IPresenter
    {
        private Enemy _enemy;
        private EnemyView _enemyView;
        private GameView _gameView;

        public EnemyAttackPresenter(Enemy enemy, EnemyView enemyView, GameView gameView)
        {
            _enemy = enemy;
            _enemyView = enemyView;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _enemy.Attacked += OnAttack;
        }

        public void Unsubscribe()
        {
            _enemy.Attacked -= OnAttack;
        }

        private void OnAttack(Transform obj)
        {
            _gameView.StarterCoroutines.StartCoroutineBehavior(Attack(obj));
        }

        private IEnumerator Attack(Transform target)
        {
            _enemy.IsAttacking = true;
            _enemyView.Animator.SetBool("IsAttack", true);
            yield return new WaitForSeconds(1);
            _enemyView.Animator.SetBool("IsAttack", false);
            yield return new WaitForSeconds(1);
            _enemy.IsAttacking = false;
        }
    }
}