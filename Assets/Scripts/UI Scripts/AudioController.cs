using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Sprite _audioOn;
    [SerializeField] private Sprite _audioOff;
    [SerializeField] private GameObject _buttonAudio;

    [SerializeField] private Slider _slider;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audio;

    // Update is called once per frame
    void Update()
    {
        _audio.volume = _slider.value;
    }

    public void OnOffAudio()
    {
        if(AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            _buttonAudio.GetComponent<Image>().sprite = _audioOff;
        }
        else 
        {
            AudioListener.volume = 1;
            _buttonAudio.GetComponent<Image>().sprite = _audioOn;
        }
    }


}
