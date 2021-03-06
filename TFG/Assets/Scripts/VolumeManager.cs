﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{

    // Reference to Audio Source component
    private AudioSource audioSrc;

    public Slider VolumenSlider;

    // Use this for initialization
    void Start()
    {
        VolumenSlider.value = GlobalData.GameVolume;
        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        GlobalData.GameVolume = VolumenSlider.value;
        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = VolumenSlider.value;
    }
}