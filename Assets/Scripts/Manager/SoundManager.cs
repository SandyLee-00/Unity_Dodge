using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sound를 BGM, Effect로 나누어 관리
/// Effect 오디오클립만 _audioClips Dictionary에 저장, 빠르게 꺼내쓰기
/// </summary>
public class SoundManager
{
    private AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.Max];
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    private GameObject _soundRoot = null;
    public void Init()
    {
        if (_soundRoot == null)
        {
            _soundRoot = GameObject.Find("@SoundRoot");
            if (_soundRoot == null)
            {
                _soundRoot = new GameObject { name = "@SoundRoot" };
                UnityEngine.Object.DontDestroyOnLoad(_soundRoot);

                string[] soundTypeNames = System.Enum.GetNames(typeof(Define.Sound));
                for (int count = 0; count < soundTypeNames.Length - 1; count++)
                {
                    GameObject go = new GameObject { name = soundTypeNames[count] };
                    _audioSources[count] = go.AddComponent<AudioSource>();
                    go.transform.parent = _soundRoot.transform;
                }

                _audioSources[(int)Define.Sound.Bgm].loop = true;
            }
        }
    }

    public void Play(Define.Sound type, string path)
    {
        AudioSource audioSource = _audioSources[(int)type];

        // Sound/ 경로 추가
        if (path.Contains("Sound/") == false)
        {
            path = string.Format("Sound/{0}", path);
        }

        // BGM 재생
        if (type == Define.Sound.Bgm)
        {
            AudioClip audioClip = Resources.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.LogError($"AudioClip Missing : {path}");
                return;
            }

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.clip = audioClip;
            audioSource.Play();
        }

        // Effect 재생
        else if (type == Define.Sound.Effect)
        {
            AudioClip audioClip = GetAudioClip(path);
            if (audioClip == null)
            {
                return;
            }

            audioSource.PlayOneShot(audioClip);
            return;
        }
    }

    private AudioClip GetAudioClip(string path)
    {
        AudioClip audioClip = null;

        // Dictionary에 저장된 AudioClip이 있다면 반환
        if (_audioClips.TryGetValue(path, out audioClip))
        {
            return audioClip;
        }

        // Resources.Load로 AudioClip을 찾아서 Dictionary에 저장
        audioClip = Resources.Load<AudioClip>(path);
        if (audioClip == null)
        {
            Debug.LogError($"AudioClip Missing : {path}");
            return null;
        }

        _audioClips.Add(path, audioClip);
        return audioClip;
    }

    public void Stop(Define.Sound type)
    {
        AudioSource audioSource = _audioSources[(int)type];
        audioSource.Stop();
    }
}