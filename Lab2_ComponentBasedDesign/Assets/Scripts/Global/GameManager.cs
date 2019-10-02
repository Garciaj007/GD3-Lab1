using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject currentSelected = null;
    private UIManager UI = null;

    // Start is called before the first frame update
    private void Start() {
        EntityClickController.onCharacterClick += ChangeCurrentSelected;
        UI = GetComponent<UIManager>();
    }

    private void Update() {

    }

    private void ChangeCurrentSelected(GameObject gameObject_) {
        currentSelected = gameObject_;
        Debug.Log("Selected: " + currentSelected.name);
    }

    // Get the current selected target
    public GameObject getCurrentSelected() {
        return currentSelected;
    }
}
