using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;
    [SerializeField] private AudioListener _audioListener; // или AudioSource
    
    private bool _isSoundOn = true;

    private void Start()
    {
        UpdateButtonIcon();
    }

    public void OnButtonClick()
    {
        _isSoundOn = !_isSoundOn;
        
        // Включаем/выключаем звук
        AudioListener.volume = _isSoundOn ? 1f : 0f;
        // Или если используете AudioSource:
        // _audioListener.mute = !_isSoundOn;
        
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (_buttonImage == null) return;
        _buttonImage.sprite = _isSoundOn ? _soundOnSprite : _soundOffSprite;
    }
}