using UnityEngine;

public class InfoPanelContentScript : MonoBehaviour
{
        [SerializeField] private string headerText;
        [SerializeField] private Sprite imageSprite;
        [TextArea]
        [SerializeField] private string infoText;
        
        [SerializeField] private InfoPanelScript infoPanel;

        public void ShowInfoPanel()
        {
                infoPanel.SetParameters(headerText, imageSprite, infoText, transform);
        }
}