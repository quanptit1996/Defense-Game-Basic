using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


namespace LQ.DefenseBasic
{
    public class Enemy : MonoBehaviour , IComponentChecking
    {
        [SerializeField] private float speed;
        [SerializeField] private float atkDistance;
        [SerializeField] private int minCoinsBonus;
        [SerializeField] private int maxCoinsBonus;
        private Animator _anim;
        private Rigidbody2D _rb;
        private PlayerController _player;
        private bool _isDead;
        

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _player = FindObjectOfType<PlayerController>();
            
        }

        
        void Start()
        {

        }

        void Update()
        {
            if(IsComponentsNull()) return;

            float distancePLayer = Vector2.Distance(transform.position, _player.transform.position);
            if (distancePLayer <= atkDistance)
            {
                _anim.SetBool(Const.ATTACK_ANIM, true);
                _rb.velocity = Vector2.zero;

            }
            else
            {
                _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            }
        }
        

        public bool IsComponentsNull()
        {
            return _anim == null || _rb == null || _player == null;
        }

        public void Die()
        {
            if (IsComponentsNull() || _isDead) return;
            if (!_isDead)
            {
                _anim.SetTrigger(Const.DEAD_ANIM);
                _rb.velocity = Vector2.zero;
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
                _isDead = true;

                GameManager.Instance.Score++;
                int bonus = Random.Range(minCoinsBonus, maxCoinsBonus);
                Pref.coins += bonus;

                GUIManager.Instance.UpdateGameplayCoins();
                
                AudioController.Instance.PlaySound(AudioController.Instance.enemyDead);
                    
                Destroy(gameObject, 2f);
            }
        }
    }
}
