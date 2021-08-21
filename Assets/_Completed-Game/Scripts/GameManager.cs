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
    
    [SerializeField]
    private GameObject popUpTextPrefab;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DoPopUpText += CreatePopUpTextAtPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePopUpTextAtPosition(Vector3 position, string text) 
    {
        GameObject go = GameObject.Instantiate(popUpTextPrefab, position, Quaternion.identity);
        go.GetComponent<PopUpText>().AssignText(text);
    }

}
