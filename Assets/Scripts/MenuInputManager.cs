using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MenuInputManager : MonoBehaviour
{
    [SerializeField] GameState okState = GameState.Null;
    [SerializeField] GameState cancelState = GameState.Null;
    [SerializeField] TextMeshProUGUI content;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnCancel();
        if (Input.GetKeyDown(KeyCode.Return))
            OnOkay();
    }

    public void OnCancel()
    {
        if (cancelState != GameState.Null)
        {
            GameManager.instance.UIPlayClick();
            GameManager.instance.SetState(cancelState);
        }
    }

    public void OnOkay()
    {
        if (cancelState != GameState.Null)
        {
            GameManager.instance.UIPlayClick();
            GameManager.instance.SetState(okState);
        }
    }

    public void SetContent(string text)
    {
        content?.SetText(text);
    }
}
