using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private TMP_Text _priceText;

    [SerializeField] private GameObject _hidePanel;

    private ProductInfo _info;
    private Clicker _clicker;
    private AutoClicker _autoClicker;

    public void Initialize(ProductInfo info, Clicker clicker, AutoClicker autoClicker)
    {
        _info = info;
        _clicker = clicker;
        _autoClicker = autoClicker;
        UpdateInfo();

        _clicker.OnChangeMoneyValue += UpdateHidePanel;

        UpdateHidePanel();
    }

    private void UpdateHidePanel()
    {
        if (_clicker.Money >= _info.Price)
        {
            _hidePanel.SetActive(false);
            _clicker.OnChangeMoneyValue -= UpdateHidePanel;
        }
    }

    private void UpdateInfo()
    {
        _icon.sprite = _info.Icon;
        _nameText.text = _info.RuName;
        if(_info.Type == ProductType.click)
            _infoText.text = $"+{_info.BonusValue} силы клика";
        else
            _infoText.text = $"+{_info.BonusValue} силы авто клика";
        _priceText.text = $"Цена: {_info.Price}";

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_clicker.Money >= _info.Price)
        {
            if (_info.Type == ProductType.click)
            {
                _clicker.UpgrateClickPower(_info.BonusValue);
            }
            else
            {
                _autoClicker.UpgradeAutoIncomePower(_info.BonusValue);
            }
            _clicker.Money -= _info.Price;
        }
    }
}
