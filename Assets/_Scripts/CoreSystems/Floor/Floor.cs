﻿using System;
using _Scripts.PlayerMovement.Actions;
using UnityEngine;

namespace _Scripts.CoreSystems.Floor
{
    public class Floor : MonoBehaviour
    {
        private Transform _player;
        private BoxCollider2D _myCollider;
            
        [SerializeField] private int pointsForMe = 10;
        public float mySpeed = 1f;

        private void Start()
        {
            mySpeed = mySpeed / 2;
            
            _player = GroundedChecker.Instance.gameObject.transform;
            _myCollider = GetComponent<BoxCollider2D>();
            
            GivePoints();
        }

        private void GivePoints()
        {
            Points.Instance.AddPoints = 10;
        }

        private void Update()
        {
            MoveDown();
            ColliderController();
        }

        private void MoveDown()
        {
            Vector3 myPosition = transform.position;
            float yPos = myPosition.y;
            yPos -= mySpeed * 10f * Time.deltaTime;

            transform.position = new Vector3(myPosition.x, yPos, myPosition.z);
        }

        private void ColliderController()
        {
            if (_player.position.y > transform.position.y)
            {
                _myCollider.enabled = true;
            }
            else if (_player.position.y < transform.position.y)
            {
                _myCollider.enabled = false;
            }
        }
    }
}