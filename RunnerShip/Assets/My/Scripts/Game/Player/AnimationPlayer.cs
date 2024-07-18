using Project.Animation;
using System;
using UnityEngine;

namespace Project.Game.Player
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private float _delay;

        [Space(10)]
        public AnimationScale AnimationTakingDamage;
        public AnimationScale AnimationStartGame;

        [Header("Died")]
        [SerializeField] private AnimationMove _animationDiedMove;
        [SerializeField] private AnimationRotate _animationDiedRotate;
        [SerializeField] private AnimationScale _animationDiedScale;

        private void Start() => Invoke(nameof(StartGame), _delay);

        private void StartGame() => AnimationStartGame.Play(() => { }, () => { });

        public void Died(Action callback)
        {
            _animationDiedScale.Play(() => { }, () => { });
            _animationDiedRotate.Play();
            _animationDiedMove.Play();

            //callback?.Invoke();
        }
        
    }
}