using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : SH.Singleton<Music>
{
    public Slider backVolume;
    public AudioSource audioSource;

    public Queue<GameObject> sources = new Queue<GameObject>();

    public AudioClip[] inputAudios;

    public Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();

    private float backVol = 1f;

    public void SetSoundSlider(Slider v) => backVolume = v;

    public void PlaySound(string clipName)
    {
        if (sources.Count == 0)
        {
            GameObject newSource = new GameObject("AudioSource");
            newSource.AddComponent<AudioSource>();
            newSource.GetComponent<AudioSource>().outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
            sources.Enqueue(newSource);
        }

        GameObject obj = sources.Dequeue();

        AudioSource source = obj.GetComponent<AudioSource>();
        source.clip = audios[clipName];
        source.Play();
        StartCoroutine(PlaySoundCo(obj));
    }

    IEnumerator PlaySoundCo(GameObject obj)
    {
        AudioSource source = obj.GetComponent<AudioSource>();

        while (source.isPlaying)
            yield return null;

        obj.transform.parent = gameObject.transform;
        sources.Enqueue(obj);
    }

    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        foreach (var clip in inputAudios)
            audios.Add(clip.name, clip);
    }
    void Start()
    {
                

        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        if (backVolume)
        {
            backVolume.value = backVol;
            audioSource.volume = backVolume.value;
        }
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    private void SoundSlider()
    {
        if (!backVolume)
            return;

        audioSource.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.GetFloat("backvol", 1f);
    }

}
