using System.Collections;
using System.Collections.Generic;
using _Scripts.Audio;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    
    void Start()
    {
        AudioManagerScript.Instance.PlayMusicInLoop("BackgroundMusic");
    }

}
