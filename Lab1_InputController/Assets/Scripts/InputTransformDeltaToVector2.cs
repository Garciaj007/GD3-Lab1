using UnityEngine;

public class InputTransformDeltaToVector2 : InputComponent
{
    [Header("Targetting")]
    [SerializeField] private Transform target = null;
    [Header("Data Node")]
    [SerializeField] private string dataName = "inputVector2";

    [SerializeField] private DataNode cachedVector;

    public override void Gather(Data data)
    {
        data[dataName] = cachedVector = new DataNode();
    }

    public override void Input()
    {
        cachedVector.Assign((target.position - transform.position).normalized);
    }
}
