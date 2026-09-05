using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    
    [Header("UI Elements")]
    [SerializeField] private Image _soundButtonImage;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _clickSound;
    
    private bool _isSoundOn = true;

    private void Start()
    {
        // Настройка музыки
        _musicSource.clip = _backgroundMusic;
        _musicSource.loop = true;
        _musicSource.Play();
        
        UpdateButtonIcon();
    }

    public void OnSoundButtonClick()
    {
        _isSoundOn = !_isSoundOn;
        
        // Включаем/выключаем всю музыку
        _musicSource.mute = !_isSoundOn;
        _sfxSource.mute = !_isSoundOn;
        
        UpdateButtonIcon();
    }

    public void PlayClickSound()
    {
        if (_isSoundOn && _clickSound != null)
        {
            _sfxSource.PlayOneShot(_clickSound);
        }
    }

    private void UpdateButtonIcon()
    {
        if (_soundButtonImage == null) return;
        _soundButtonImage.sprite = _isSoundOn ? _soundOnSprite : _soundOffSprite;
    }
}