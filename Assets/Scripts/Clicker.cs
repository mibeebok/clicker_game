using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _clickPower;
    [SerializeField] private Transform _clickerImage;
    [SerializeField] private TMP_Text _floatingText;
    [SerializeField] private AudioManager _audioManager;

    private float _money;
    public float Money {
        get => _money;
        set{
            _money = value;
            OnChangeMoneyValue?.Invoke();
        }
    }

    public event Action OnChangeMoneyValue;

    public void OnClickDown(){
        Money += _clickPower;
        _clickerImage.localScale = Vector2.one * 0.9f;

        if (_audioManager != null)
        {
            _audioManager.PlayClickSound();
        }

        ShowFloatingText($"+{_clickPower:F0}");
    }

    public void OnClickUp(){
        _clickerImage.localScale = Vector2.one;
    }

    public void UpgrateClickPower(float bonus)
    {
        _clickPower += bonus;
    }

    private void ShowFloatingText(string text)
    {
        if (_floatingText == null) return;

        // Создаем копию текста
        TMP_Text newText = Instantiate(_floatingText, _floatingText.transform.parent);
        newText.text = text;
        newText.gameObject.SetActive(true);
        
        // Устанавливаем позицию рядом с оригиналом
        newText.transform.position = _floatingText.transform.position + UnityEngine.Random.insideUnitSphere * 30f;

        StartCoroutine(AnimateFloatingText(newText));
    }

    private IEnumerator AnimateFloatingText(TMP_Text floatingText)
    {
        float duration = 1f;
        float timer = 0;
        Vector3 startPosition = floatingText.transform.position;
        Vector3 endPosition = startPosition + Vector3.up * 100f; // Поднимаем на 100 пикселей
        
        Color startColor = floatingText.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;

            // Двигаем текст вверх
            floatingText.transform.position = Vector3.Lerp(startPosition, endPosition, progress);
            
            // Делаем текст прозрачным
            floatingText.color = Color.Lerp(startColor, endColor, progress);

            yield return null;
        }

        // Уничтожаем копию после анимации
        Destroy(floatingText.gameObject);
    }
}