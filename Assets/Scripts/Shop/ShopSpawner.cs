using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShopSpawner : MonoBehaviour
{
    [SerializeField] private ShopButtons _buttonPrefab;
    [SerializeField] private Transform _parentForButtons;
    [SerializeField] private List<ProductInfo> _productInfo = new List<ProductInfo>();

    [Space, SerializeField] private Clicker _clicker;
    [SerializeField] private AutoClicker _autoClicker;

    private void Start()
    {
        SpawnButtons();
    }

    private void SpawnButtons()
    {
        for (int i=0; i < _productInfo.Count; i++)
        {
            ShopButtons button = Instantiate(_buttonPrefab, _parentForButtons);
            button.Initialize(_productInfo [i], _clicker, _autoClicker);
        }
    }
}
