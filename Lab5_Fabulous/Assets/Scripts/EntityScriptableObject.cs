using UnityEngine;

[CreateAssetMenu]
public class EntityScriptableObject : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public bool isBoss;
    public int hp;
    public int likesAddedWhenDead;
    public Vector3 leftEyePosition;
    public Vector3 rightEyePosition;
}
