using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonController : MonoBehaviour
{
    public CharDialog dialog;
    public Button endButton;
    public Text inputField;

    public void Continue()
    {
        inputField.text = dialog.sentences[3];
        this.gameObject.SetActive(false);
        endButton.gameObject.SetActive(true);
    }
}
