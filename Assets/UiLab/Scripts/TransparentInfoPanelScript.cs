using System;
using UnityEngine;

public class TransparentInfoPanelScript : MonoBehaviour
{
        private static readonly int IsVisible = Animator.StringToHash("isVisible");
        Animator animator;

        private void Start()
        {
                animator = GetComponent<Animator>();
                animator.SetBool(IsVisible, false);
        }

        public void ShowPanel()
        {
                animator.SetBool(IsVisible, true);
                AudioManager.instance.Click();
        }

        public void HidePanel()
        {
                animator.SetBool(IsVisible, false);
        }
}