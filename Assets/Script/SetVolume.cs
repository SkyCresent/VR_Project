using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetVolume : MonoBehaviour
{
    [SerializeField] AudioSource s;
    [SerializeField] AudioClip clip;
    private void Awake()
    {
        s = GetComponent<AudioSource>();
        s.clip = clip;
        s.Play();
    }
    public AudioMixer audiomixer;

    public Slider VolumeSlider;



    public void SetMasterVolume()
    {
        audiomixer.SetFloat("Master", Mathf.Log10(VolumeSlider.value) * 20);

    }
}
