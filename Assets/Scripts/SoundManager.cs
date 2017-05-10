using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume
{
    public float BGM = 1.0f;
    public float SE = 1.0f;
    public float Voice = 1.0f;
    public bool Mute = false;

    public void Init()
    {
        BGM = 1.0f;
        SE = 1.0f;
        Voice = 1.0f;
        Mute = false;
}
}
public class SoundManager : MonoBehaviour{
    private static SoundManager instance;

    //オーディオソース

    //BGM
    private static AudioSource BGMSource;
    //効果音
    private static AudioSource[] SESources = new AudioSource[16];
    //声
    private static AudioSource[] VoiceSources = new AudioSource[16];

    //オーディオクリップ

    //BGM
    public static AudioClip[] BGM;
    //効果音
    public static AudioClip[] SE;
    //声
    public static AudioClip[] Voice;

    //音量
    public static SoundVolume volume = new SoundVolume();

    private SoundManager()
    {
        Debug.Log("Create SoundManager instance");
    }

    public static SoundManager Instance
    {
        get{
            if(instance == null)
            {
                GameObject obj = new GameObject("SoundManager");
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<SoundManager>();
            }

            return instance;
        }
    }

    void Start()
    {
        //BGMのオーディオソースの生成
        BGMSource = gameObject.AddComponent<AudioSource>();
        //全てのBGMのループ設定を有効にする
        BGMSource.loop = true;

        //効果音の生成
        for (int i = 0; i < SESources.Length; i++)
        {
            SESources[i] = gameObject.AddComponent<AudioSource>();
        }

        //声の生成
        for (int i = 0; i < VoiceSources.Length; i++)
        {
            VoiceSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        //ミュート設定
        BGMSource.volume = volume.BGM;
        foreach(AudioSource source in SESources)
        {
            source.mute = volume.Mute;
        }

        foreach(AudioSource source in VoiceSources)
        {
            source.mute = volume.Mute;
        }

        //ボリューム設定
        BGMSource.volume = volume.BGM;
        foreach (AudioSource source in SESources)
        {
            source.volume = volume.SE;
        }
        foreach (AudioSource source in VoiceSources)
        {
            source.volume = volume.Voice;
        }

    }
    //BGM再生
    public static void PlayBGM(int index)
    {
        //指定したインデックスが範囲外の場合は何もしない
        if(index > 0 || index >= BGM.Length)
        {
            return;
        }

        //同じBGMの場合は何もしない
        if(BGMSource.clip == BGM[index])
        {
            return;
        }

        BGMSource.Stop();
        BGMSource.clip = BGM[index];
        BGMSource.Play();
    }

    //BGM停止
    public static void StopBGM()
    {
        BGMSource.Stop();
        BGMSource.clip = null;
    }

    //効果音再生
    public static void PlaySE(int index)
    {
        //指定したインデックスが範囲外の場合は何もしない
        if (index > 0 || index >= SE.Length)
        {
            return;
        }

        //再生中でないオーディオソースを検索し使用する
        foreach(AudioSource source in SESources)
        {
            if(!source.isPlaying)
            {
                source.clip = SE[index];
                source.Play();
                return;
            }
        }
    }

    //全ての効果音を停止する
    public static void StopSE()
    {
        foreach(AudioSource source in SESources)
        {
            source.Stop();
            source.clip = null;
        }
    }

    //声の再生
    public static void PlayVoice(int index)
    {
        //指定したインデックスが範囲外の場合は何もしない
        if (index > 0 || index >= Voice.Length)
        {
            return;
        }

        //再生中でないオーディオソースを検索し使用する
        foreach (AudioSource source in VoiceSources)
        {
            if (!source.isPlaying)
            {
                source.clip = Voice[index];
                source.Play();
                return;
            }
        }
    }

    //全ての声を停止する
    public static void StopVoice()
    {
        foreach (AudioSource source in VoiceSources)
        {
            source.Stop();
            source.clip = null;
        }
    }
}
