using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Audio
{
    public class AudioManagerScript : MonoBehaviour
    {
        public static AudioManagerScript Instance;

        [Header("Audio Sources")] [SerializeField]
        private AudioSource musicSource;

        [SerializeField] private AudioSource sfxSource;

        [Header("Clips")] public Sound[] sounds;

        private bool _musicPaused = false;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void PlaySFXOneShot(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            sfxSource.PlayOneShot(s.clip);
        }

        public void PlayMusicOneShot(string name)
        {
            if(musicSource.isPlaying) musicSource.Stop();
            Sound s = Array.Find(sounds, sound => sound.name == name);
            musicSource.PlayOneShot(s.clip);
        }
        
        public void PlayMusicInLoop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            musicSource.PlayOneShot(s.clip);
            musicSource.loop = true;
        }

        public IEnumerator PlayMusicsRandomlyInLoop(List<string> names)
        {
            while (true)
            {
                int i = Random.Range(0, names.Count - 1);
                Sound s = Array.Find(sounds, sound => sound.name == names[i]);
                musicSource.PlayOneShot(s.clip);
                yield return new WaitUntil(() => !musicSource.isPlaying && !_musicPaused);
            }
        }

        public void PauseMusic()
        {
            if (musicSource.isPlaying)
            {
                _musicPaused = true;
                musicSource.Pause();
                return;
            }

            _musicPaused = false;
            musicSource.UnPause();
        }
    }
}