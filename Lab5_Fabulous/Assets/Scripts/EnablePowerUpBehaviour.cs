using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePowerUpBehaviour : MonoBehaviour
{
    [SerializeField] private float amount;
    [SerializeField] private bool isJush = false;

    private void Start() => MouseEventHandlerManager.mouseDownEvent += PowerUpUpdate;
    private void OnDestroy() => MouseEventHandlerManager.mouseDownEvent -= PowerUpUpdate;

    private void PowerUpUpdate()
    {
        if(isJush)
            GameManager.I.Puff(amount);
        else
            GameManager.I.Drink(amount);
    }

}
