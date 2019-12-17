using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(TargetSpawner))]
public class TargetSpawnerEditor : Editor
{
    private TargetSpawner targetSpawner;

    private ReorderableList targetDataList;

    private void OnEnable()
    {
        targetSpawner = (TargetSpawner)target;

        //if (targetDataList == null)
        //    targetDataList = new ReorderableList(serializedObject,, true, true, true, true);
        //targetDataList.drawHeaderCallback += DrawNameHeader;
        //targetDataList.drawElementCallback += DrawNameElement;
        //targetDataList.onAddCallback += AddNameElement;
        //targetDataList.onRemoveCallback += RemoveNameElement;
    }

    private void OnDisable()
    {
        
    }

    #region Headers
    private void DrawHeader(Rect r, string l) => GUI.Label(r, l);
    private void DrawNameHeader(Rect r) => DrawHeader(r, "Name");
    private void DrawMinHeader(Rect r) => DrawHeader(r, "Min Spawn Count");
    private void DrawMaxHeader(Rect r) => DrawHeader(r, "MAx Spawn Count");
    #endregion

    #region Elements
    private void DrawNameElement(Rect r, int index, bool active, bool focused)
    {
        return; 
    }
    #endregion

    #region Add Elements

    #endregion

    #region Remove Element

    #endregion

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        targetDataList.DoLayoutList();
    }
}

public class TargetSpawner : AObjectSpawner
{
    [System.Serializable]
    public class TargetData
    {
        public string name;
        public int minSpawnCount;
        public int maxSpawnCount;
    }

    [SerializeField] protected Vector2 dimensions;
    [SerializeField] protected List<TargetData> targets;

    private int count = 0;

    private void Update()
    {
        if (BeatSequencer.Instance.BeatFull)
        {
            var target = targets[count];
            
            name = target.name;

            for(int i = 0; i < Random.Range(target.minSpawnCount, target.maxSpawnCount); i++)
                Spawn();

            ++count;
            count = count > targets.Count - 1 ? 0 : count < 0 ? targets.Count - 1 : count;
        }
    }

    protected override void Spawn()
    {
        var spawnPos = new Vector3(Random.Range(-dimensions.x, dimensions.x),
            Random.Range(-dimensions.y, dimensions.y), GameManager.Instance.CullAndDepth.y);
        objectPool.SpawnFromPool(name, spawnPos, Quaternion.Euler(Vector3.back));
    }
}
