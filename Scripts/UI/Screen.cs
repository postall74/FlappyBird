using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button PlayButton;
    [SerializeField] protected Button ExitButton;

    private void OnEnable()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClick);
        ExitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        PlayButton.onClick.RemoveListener(OnPlayButtonClick);
        ExitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    protected abstract void OnPlayButtonClick();

    protected abstract void OnExitButtonClick();

    public abstract void Open();

    public abstract void Close();
}
