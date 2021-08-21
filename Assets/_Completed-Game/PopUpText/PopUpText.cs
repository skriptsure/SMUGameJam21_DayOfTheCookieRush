using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    [SerializeField]
    private Text textUI;

    private float alpha = 0;

    private Camera cam;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position, Vector3.up);
        transform.position += Vector3.up * Time.deltaTime;
        textUI.color = Color.Lerp(Color.white, Color.clear, Math.Max(alpha-2, 0));
        alpha += Time.deltaTime;
        if (alpha >= 3)
            Destroy(gameObject);
    }

    public void AssignText(string text)
    {
        textUI.text = text;
    }

}
