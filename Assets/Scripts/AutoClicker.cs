using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class AutoClicker : MonoBehaviour
{
        [SerializeField] private Clicker _clicker;
        public float _autoIncomePower;

    private void Awake()
    {
        StartCoroutine(AutoIncome());
    }

    private IEnumerator AutoIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _clicker.Money += _autoIncomePower;
        }
    }

    public void UpgradeAutoIncomePower(float bonus)
    {
        _autoIncomePower += bonus;
    }
}
