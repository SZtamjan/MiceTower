using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.CoreSystems;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StartNewGameState(GameState.Win);
        }
    }
}
