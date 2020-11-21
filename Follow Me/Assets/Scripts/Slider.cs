using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    float volume = 0.5f;
    // Start is called before the first frame update
    void SaveSliderValue()
    {
        PlayerPrefs.SetFloat("SliderVolumeLevel", volume);
    }
}
