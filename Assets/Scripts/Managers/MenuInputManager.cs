using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#pragma warning disable 0649
public class MenuInputManager : MonoBehaviour
{
    [SerializeField] GameState okState = GameState.Null;
    [SerializeField] GameState cancelState = GameState.Null;
    [SerializeField] TextMeshProUGUI content;

    void Update()
    {
        if (/*Input.GetKeyDown(KeyCode.Return) || */ Input.GetButtonDown("Submit"))
            OnOkay();
        if (/*Input.GetKeyDown(KeyCode.Escape) || */ Input.GetButtonDown("Cancel"))
            OnCancel();
    }

    public void OnCancel()
    {
        if (cancelState != GameState.Null)
        {
            GameManager.Instance.UIPlayClick();
            GameManager.Instance.SetState(cancelState);
        }
    }

    public void OnOkay()
    {
        if (cancelState != GameState.Null)
        {
            GameManager.Instance.UIPlayClick();
            GameManager.Instance.SetState(okState);
        }
    }

    public void OnRestart()
    {
        if (cancelState != GameState.Null)
        {
            GameManager.Instance.UIPlayClick();
            GameManager.Instance.Restart();
        }
    }

    public void SetContent(string text)
    {
        content?.SetText(text);
    }
}
