using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider Slider;
    public float oldVolume;

    private void Start()
    {
        oldVolume = Slider.value;
        if (!PlayerPrefs.HasKey("volume")) Slider.value = 1;
        else Slider.value = PlayerPrefs.GetFloat("volume");
    }

    private void Update()
    {
        if(oldVolume != Slider.value)
        {
            PlayerPrefs.SetFloat("volume", Slider.value);
            PlayerPrefs.Save();
            oldVolume = Slider.value;
        }
    }
}
