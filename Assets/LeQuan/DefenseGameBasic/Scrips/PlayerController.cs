using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LQ.DefenseBasic
{
    public class PlayerController : MonoBehaviour, IComponentChecking
    {
        [SerializeField] private float atkRate;

        private Animator _anim;
        private float _currentAtkRate;
        private bool _isAttacked;
        private bool _isDedad;
        private IComponentChecking _componentCheckingImplementation;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _currentAtkRate = atkRate;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(IsComponentsNull()) return;

            if (Input.GetMouseButtonDown(0) && !_isAttacked)
            {
                _anim.SetBool(Const.ATTACK_ANIM, true);
                _isAttacked = true;
            }

            if (_isAttacked)
            {
                _currentAtkRate -= Time.deltaTime;
                if (_currentAtkRate <= 0)
                {
                    _currentAtkRate = atkRate;
                    _isAttacked = false;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(IsComponentsNull()) return;
            
            if (col.CompareTag(Const.ENEMY_WEAPON_TAG) && !_isDedad)
            {
                _anim.SetTrigger(Const.DEAD_ANIM);
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
                _isDedad = true;
            }
        }

      

        private void ResetAtkAnim()
        {
            if (IsComponentsNull()) return;

            _anim.SetBool(Const.ATTACK_ANIM, false);

        }

        public bool IsComponentsNull()
        {
            return _anim == null;
        }
    }
}
