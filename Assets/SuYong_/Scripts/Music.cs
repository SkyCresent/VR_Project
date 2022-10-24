using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource audioSource;

    private float backVol = 1f;

    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        audioSource.volume = backVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    private void SoundSlider()
    {
        audioSource.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.GetFloat("backvol", 1f);
    }

}
