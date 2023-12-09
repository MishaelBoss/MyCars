using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource Audio_;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) Audio_.volume = 1;
    }

    private void Update()
    {
        Audio_.volume = PlayerPrefs.GetFloat("volume");
    }
}
