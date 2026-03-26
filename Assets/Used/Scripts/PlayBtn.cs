using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    [System.Serializable]
    public class KeyButtonPair
    {
        public KeyCode key;
        public Button button;

        [HideInInspector] public Image targetImage;
        [HideInInspector] public Color normalColor;
        [HideInInspector] public Color pressedColor;
    }

    [SerializeField] private KeyButtonPair[] keyButtons;

    private void Awake()
    {
        foreach (var pair in keyButtons)
        {
            if (pair.button == null)
                continue;

            pair.targetImage = pair.button.targetGraphic as Image;

            if (pair.targetImage == null)
                continue;

            ColorBlock colors = pair.button.colors;
            pair.normalColor = colors.normalColor;
            pair.pressedColor = colors.pressedColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var pair in keyButtons)
        {
            if (pair.targetImage == null)
                continue;

            if (Input.GetKeyDown(pair.key))
            {
                pair.targetImage.color = pair.pressedColor;
            }

            if (Input.GetKeyUp(pair.key))
            {
                pair.targetImage.color = pair.normalColor;
            }
        }

    }
}
