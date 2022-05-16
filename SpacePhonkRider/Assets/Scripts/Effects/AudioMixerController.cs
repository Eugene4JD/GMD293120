namespace Effects
{
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.UI;


    public class AudioMixerController : MonoBehaviour
    {
        [SerializeField] private float startVolume = -30;
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private string groupName;

        [SerializeField] private Slider slider;

        private void Start()
        {
            slider.value = PlayerPrefs.GetFloat(groupName, startVolume);
            audioMixer.SetFloat(groupName, slider.value);
        }

        public void SetVolume(float volume)
        {
            slider.value = volume;
            PlayerPrefs.SetFloat(groupName, slider.value);
            audioMixer.SetFloat(groupName, PlayerPrefs.GetFloat(groupName, startVolume));
        }
    }
}