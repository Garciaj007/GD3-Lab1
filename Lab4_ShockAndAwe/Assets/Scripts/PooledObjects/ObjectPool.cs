using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ObjectPool.PoolData))]
public class PoolDataDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //return base.GetPropertyHeight(property, label);
        return EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        //var propertyRect = new Rect(position.x, position.y, position.width, position.height * 2);

        EditorGUI.BeginProperty(position, label, property);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect nameRect = new Rect(position.x, position.y, position.width / 3, position.height);
        Rect sizeRect = new Rect(position.x + position.width / 3, position.y, position.width / 4, position.height);
        Rect prefabRect = new Rect(position.x + position.width / 3 + position.width / 4, position.y, position.width / 3, position.height);

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
        EditorGUI.PropertyField(sizeRect, property.FindPropertyRelative("size"), GUIContent.none);
        EditorGUI.PropertyField(prefabRect, property.FindPropertyRelative("prefab"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class PoolData
    {
        public string name;
        public GameObject prefab;
        public int size;
    }

    public List<PoolData> poolData;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    public static ObjectPool Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (PoolData pool in poolData)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                var obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.name, objectPool);
        }

    }

    public GameObject SpawnFromPool(string name, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(name)) return null;

        var spawnObj = poolDictionary[name].Dequeue();

        spawnObj.GetComponent<IPooledObject>()?.OnObjectHide();
        spawnObj.SetActive(true);
        spawnObj.transform.position = position;
        spawnObj.transform.rotation = rotation;
        spawnObj.GetComponent<IPooledObject>()?.OnObjectSpawned();

        poolDictionary[name].Enqueue(spawnObj);

        return spawnObj;
    }
}
