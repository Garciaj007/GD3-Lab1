using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Slider healthBar;

    public UIManager Instance { get; set; }

    private void Awake() {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Update() {
        GameObject selected = GameManager.Instance.CurrentSelected;
        if (selected) healthBar.value = selected.GetComponent<HealthComponent>().GetHealthPercent();
    }
}
