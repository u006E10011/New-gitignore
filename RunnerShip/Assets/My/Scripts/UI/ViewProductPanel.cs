using Project.Shop;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class ViewProductPanel : MonoBehaviour
    {
        public Action<Product> OnViewPanel;

        private int _currentValue;

        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _parce;
        [SerializeField] private TMP_Text _value;

        private void OnValidate() => _icon = _icon != null ? _icon : transform.GetChild(0).GetComponent<Image>();

        private void OnEnable() => OnViewPanel += View;
        private void OnDisable() => OnViewPanel += View;

        public void View(Product product)
        {
            Data(product);

            _icon.sprite = product.Icon;
            _value.text = product.Upgrades[_currentValue].Value.ToString();

            if (_currentValue + 1 >= product.Upgrades.Count)
                _parce.gameObject.SetActive(false);
            else
                _parce.text = product.Upgrades[_currentValue + 1].Parce.ToString();
        }

        private void Data(Product product) => _currentValue = Shop.Shop.Level(product.name);
    }
}