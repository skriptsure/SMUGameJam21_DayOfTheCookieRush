using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopUpDialogue: MonoBehaviour
{
    [SerializeField]
    private Text textUI;
    [SerializeField]
    private Image imageUI;
    [SerializeField]
    private Transform root;

    private float alpha = 0;
    private float showAlpha = 5;

    Vector3 startPos;
    Vector3 targetPos;

    public static UnityAction HideAllDialogues;

    private void Awake()
    {
        startPos = root.position;
        targetPos = startPos;
        targetPos.y = 0;

        HideAllDialogues += Hide;
    }

    private void OnDestroy()
    {
        HideAllDialogues -= Hide;
    }

    // Update is called once per frame
    void Update()
    {
        root.position = Vector3.Lerp(startPos, targetPos, Mathf.Pow(alpha, 2));
        
        if (showAlpha == 5)
            alpha += Time.deltaTime;

        if (alpha >= 1)
        {
            alpha = 1;
            showAlpha -= Time.deltaTime;
        }

        if (showAlpha <= 0 && alpha >= 0)
        {
            alpha -= Time.deltaTime;
        }

        if (alpha <= 0 && showAlpha <= 0)
            Destroy(gameObject);
    }

    public void Hide()
    {
        showAlpha = 0;
    }

    public void AssignText(string text)
    {
        textUI.text = text;
    }

    internal void AssignImage(Sprite sprite)
    {
        imageUI.sprite = sprite;
    }
}
