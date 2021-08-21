using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static PlayerController player {
        get
        {
            return _player;
        }
    }
    private static PlayerController _player;

    public static UnityAction<Vector3, string> DoPopUpText;
    public static UnityAction<Sprite, string> DoPopUpDialogue;

    [SerializeField]
    private GameObject popUpTextPrefab;
    [SerializeField]
    private GameObject popUpDialoguePrefab;


    string[] cookiePickupTextOptions =
    {
        "Stop! You’ll overdoughse!",
        "But I’m only half-baked!",
        "I will rise again!",
    };

    string[] heroTextOptions =
        {
        "Crumble before me!",
        "I shall not be licked!",
        "Power my flour!",
    };


    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DoPopUpText += CreatePopUpTextAtPosition;
        DoPopUpDialogue += CreateDialogueText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePopUpTextAtPosition(Vector3 position, string text = null)
    {
        GameObject go = GameObject.Instantiate(popUpTextPrefab, position, Quaternion.identity);
        if (text == null)
            text = cookiePickupTextOptions[Random.Range(0, cookiePickupTextOptions.Length)];
        go.GetComponent<PopUpText>().AssignText(text);
    }
    void CreateDialogueText(Sprite sprite, string text = null)
    {
        PopUpDialogue.HideAllDialogues?.Invoke();
        GameObject go = GameObject.Instantiate(popUpDialoguePrefab);
        if (text == null)
            text = heroTextOptions[Random.Range(0, heroTextOptions.Length)];
        go.GetComponent<PopUpDialogue>().AssignText(text);
        go.GetComponent<PopUpDialogue>().AssignImage(sprite);
    }

}
