using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sound瑜?BGM, Effect濡??섎늻??愿由?
/// Effect ?ㅻ뵒?ㅽ겢由쎈쭔 _audioClips Dictionary????? 鍮좊Ⅴ寃?爰쇰궡?곌린
/// </summary>
public class SoundManager 
{
    private AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.Max];
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    private GameObject _soundRoot = null;

    private bool isOn = true;

    // Sound On/Off
    public bool IsOn
    {
        get { return isOn; }
        set 
        { 
            isOn = value;

            // ?ъ슫??On ?섎㈃ BGM ?ㅺ린
            if (isOn)
            {
                _audioSources[(int)Define.Sound.Bgm].Play();
            }

            // ?ъ슫??Off ?섎㈃ BGM ?꾧린
            if (isOn == false)
            {
                _audioSources[(int)Define.Sound.Bgm].Stop();
            }
        }   
    }

    // SoundRoot媛 ?놁쑝硫??앹꽦, -BGM, -Effect ?ㅻ뵒?ㅼ냼???앹꽦
    public void Init()
    {
        if (_soundRoot == null)
        {
            _soundRoot = GameObject.Find("@SoundRoot");
            if (_soundRoot == null)
            {
                _soundRoot = new GameObject { name = "@SoundRoot" };
                _soundRoot.transform.SetParent(GameObject.Find("@Managers").transform);

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

        // Sound/ 寃쎈줈 異붽?
        if (path.Contains("Sound/") == false)
        {
            path = string.Format("Sound/{0}", path);
        }

        // BGM ?ъ깮
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

            // ?ъ슫??On???뚮쭔 ?ъ깮
            if (isOn == true)
            {
                audioSource.Play();
            }
        }

        // Effect ?ъ깮
        else if (type == Define.Sound.Effect)
        {
            AudioClip audioClip = GetAudioClip(path);
            if (audioClip == null)
            {
                return;
            }

            // ?ъ슫??On???뚮쭔 ?ъ깮
            if (isOn == true)
            {
                audioSource.PlayOneShot(audioClip);
            }

            return;
        }
    }

    // Effect AudioClip??Dictionary?????
    private AudioClip GetAudioClip(string path)
    {
        AudioClip audioClip = null;

        // Dictionary????λ맂 AudioClip???덈떎硫?諛섑솚
        if (_audioClips.TryGetValue(path, out audioClip))
        {
            return audioClip;
        }

        // Resources.Load濡?AudioClip??李얠븘??Dictionary?????
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