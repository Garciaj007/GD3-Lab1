using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Slider healthBar = null;
    [SerializeField] private Button moveButton = null;
    [SerializeField] private Button defendButton = null;

    public static UIManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Update() {
        GameObject selected = GameManager.Instance.CurrentSelected;
        if (selected) healthBar.value = selected.GetComponent<HealthComponent>().GetHealthPercent();
    }

    public void DisableButtons()
    {
        if(moveButton == null || defendButton == null) return;
        moveButton.interactable = false;
        defendButton.interactable = false;
    }

    public void EnableButtons()
    {
        if(moveButton == null || defendButton == null) return;
        moveButton.interactable = true;
        defendButton.interactable = true;
    }
}
