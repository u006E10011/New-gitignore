using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Animation
{
    public class AnimationColorUI : MonoBehaviour
    {
        [SerializeField] private float _duration = .2f;
        [SerializeField] private Color32 _targerValue;

        [SerializeField, Space(10)] private List<Image> _images;
        [SerializeField] private List<TMP_Text> _texts;

        public void SetAlphaImage()
        {
            if (_images.Count <= 0)
                return;

            DOTween.ToAlpha(() => _targerValue, x => _targerValue = x, _targerValue.a, _duration);

            for (int i = 0; i < _images.Count; i++)
                _images[i].DOColor(new Color32((byte)_images[i].color.r, (byte)_images[i].color.g, (byte)_images[i].color.b, _targerValue.a), _duration).SetLink(gameObject);
        }

        public void SetAlphaText()
        {
            if (_texts.Count <= 0)
                return;

            for (int i = 0; i < _texts.Count; i++)
                _texts[i].DOColor(_targerValue, _duration).SetLink(gameObject);
        }
    }
}