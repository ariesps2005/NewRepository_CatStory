using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IG_QuitButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _buttonText;

    [SerializeField]
    private Image _pawSprite;

    public void OnButton()
    {
        _buttonText.color = Color.white;
        _pawSprite.enabled = true;
    }

    public void OnButtonExit()
    {
        _buttonText.color = new Color32(0x38, 0x38, 0x38, 0xFF);
        _pawSprite.enabled = false;
    }
}
