using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LQ.DefenseBasic;

namespace LQ.DefenseBasic
{
    public class Weapon : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Const.ENEMY_TAG))
            {
                Enemy enemy = col.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.Die();
                }
            }
        }
    }
}

