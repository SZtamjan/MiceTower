using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    
    public GameObject gameWinCanvas;
    public GameObject gameOverCanvas;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SerKoniecPoziomu"))
        {
            gameWinCanvas.SetActive(true);
        }

        if (other.CompareTag("GameOver"))
        {
            gameOverCanvas.SetActive(true);
        }
    }
}
