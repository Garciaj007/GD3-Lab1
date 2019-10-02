using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Slider healthBar;
    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start() {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update() {
        GameObject selected = gameManager.getCurrentSelected();
        if (selected) healthBar.value = selected.GetComponent<HealthComponent>().GetHealthPercent();
    }
}
