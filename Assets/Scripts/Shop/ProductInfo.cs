using UnityEngine;
using System;
using Unity.VisualScripting;
using TMPro;

public enum ProductType
{
    click, autoClick
}

[CreateAssetMenu(fileName = "productInfo", menuName = "Scriptable Object/Product Info")] 
public class ProductInfo : ScriptableObject
{
    [SerializeField] private ProductType _type;

    [SerializeField] private float _price;
    [SerializeField] private float _bonusValue;

    [SerializeField] private Sprite _icon;
    [SerializeField] private string _ruName;
    [SerializeField] private string _enName;

    public ProductType Type => _type;

    public float Price => _price;
    public float BonusValue => _bonusValue;

    public Sprite Icon => _icon;
    public string RuName => _ruName;
    public string EnName => _enName;
}
