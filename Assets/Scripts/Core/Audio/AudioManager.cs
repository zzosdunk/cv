using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Audio
{
    [System.Serializable]
    public enum Sound
    {
        Button = 1,
        Tab = 2,
        SuitPreview = 3,
        KeyboardInteraction = 4,
        PlayerMovement = 5,
        Error = 6,
        
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound SoundType;
        public AudioClip Audio;
    }
    
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private float _soundDelay;
        private Dictionary<Sound, float> _soundDelayDictionary;

        [SerializeField] private SoundAudioClip[] _gameSounds;

        public void Init()
        {
            _soundDelayDictionary = new Dictionary<Sound, float>();
            _soundDelayDictionary[Sound.PlayerMovement] = 0f;
        }

        public void PlaySound(Sound sound)
        {
            if (CanPlaySound(sound))
            {
                _audioSource.PlayOneShot(GetSoundClip(sound));
            }
        }

        public void PlaySound(Sound sound, Vector3 position)
        {
            if (CanPlaySound(sound))
            {
                _audioSource.PlayOneShot(GetSoundClip(sound));
            }
        }

        private bool CanPlaySound(Sound sound)
        {
            switch (sound)
            {
                case Sound.PlayerMovement:
                    if (_soundDelayDictionary.ContainsKey(sound))
                    {
                        float lastTimePlayed = _soundDelayDictionary[sound];
                        if (lastTimePlayed + _soundDelay < Time.time)
                        {
                            _soundDelayDictionary[sound] = Time.time;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    break;
                default:
                    return true;
            }

            return false;
        }

        private AudioClip GetSoundClip(Sound soundType)
        {
            // _gameSounds.ForEach(s =>
            // {
            //     if (s.SoundType == soundType)
            //     {
            //         return s.Audio;
            //     }
            //     else
            //     {
            //         return null;
            //     }
            // });

            foreach (var sound in _gameSounds)
            {
                if (sound.SoundType == soundType)
                {
                    return sound.Audio;
                }
            }

            Debug.LogError("No sound " + soundType + " has been found !");
            return null;
        }
    }
}