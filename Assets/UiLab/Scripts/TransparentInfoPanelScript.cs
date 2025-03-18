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
        }

        public void HidePanel()
        {
                animator.SetBool(IsVisible, false);
        }
}