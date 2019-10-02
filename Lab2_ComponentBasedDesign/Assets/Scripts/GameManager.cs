using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject currentSelected = null;

    // Start is called before the first frame update
    void Start()
    {
        CharacterClickController.onCharacterClick += ChangeCurrentSelected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeCurrentSelected(GameObject gameObject_)
    {
        currentSelected = gameObject_;
        Debug.Log("Selected: " + currentSelected.name);
    }
}
