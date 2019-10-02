using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameData : MonoBehaviour
{
    private static GlobalGameData instance;

    private List<GameObject> playerObjects;

    public static GlobalGameData Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("PlayerUnit"));
    }

    public bool GetRandomPlayerPosition(out Vector3 result)
    {
        // Init
        result = Vector3.zero;

        // Check if we have enough player units left
        if (playerObjects.Count == 0) return false;

        // Return success
        result = playerObjects[Random.Range(0, playerObjects.Count - 1)].transform.position;
        result.z = 0;
        return true;
    }

    public Vector3 GetRandomCamPosition()
    {
        Vector3 screenPosition =
            Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Random.Range(0, Screen.width),
                    Random.Range(0, Screen.height
                    ),
                    Camera.main.farClipPlane / 2
                    )
                );

        screenPosition.z = 0f;
        return screenPosition;
    }
}
