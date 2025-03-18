using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelScript : MonoBehaviour
{
        [SerializeField] private TMP_Text header;
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text info;

        public void SetParameters(string header, Sprite imageSprite, string infoText, Transform parent)
        {
                this.header.text = header;
                this.image.sprite = imageSprite;
                this.info.text = infoText;
                this.transform.SetParent(parent, false);
        }
}