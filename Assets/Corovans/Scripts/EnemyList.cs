using System;
using System.Collections.Generic;
using UnityEngine;

namespace Corovans.Scripts
{
    public class EnemyList : MonoBehaviour
    {
        public static EnemyList instance;

        public List<EnemyBase> Enemies { get; private set; } = new List<EnemyBase>();

        public void AddToEnemiesList(EnemyBase newEnemy)
        {
            Enemies.Add(newEnemy);
        }
        public void RemoveFromEnemiesList(EnemyBase enemyToDelete)
        {
            Enemies.Remove(enemyToDelete);
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
