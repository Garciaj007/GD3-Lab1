using System;
using UnityEngine;

public sealed class DataNode
{
    public enum ValueType { NONE, INTEGER, FLOAT, VECTOR2, VECTOR3, STRING };

    private object value;
    private ValueType type;

    public void Assign(int i)
    {
        if (type == ValueType.INTEGER || type == ValueType.NONE)
        {
            type = ValueType.INTEGER;
            value = i;
        }
    }

    public void Assign(float f)
    {
        if (type == ValueType.FLOAT || type == ValueType.NONE)
        {
            type = ValueType.FLOAT;
            value = f;
        }
    }

    public void Assign(Vector2 v)
    {
        if (type == ValueType.VECTOR2 || type == ValueType.NONE)
        {
            type = ValueType.VECTOR2;
            value = v;
        }
    }

    public static explicit operator int(DataNode node)
    {
        if (node.type == ValueType.INTEGER || node.type == ValueType.FLOAT)
            return (int)node.value;

        return 0;
    }

    public static explicit operator float(DataNode node)
    {
        if (node.type == ValueType.INTEGER || node.type == ValueType.FLOAT)
            return (float)node.value;

        return 0;
    }

    public static explicit operator Vector2(DataNode node)
    {
        if (node.type == ValueType.VECTOR2)
            return (Vector2)node.value;

        return Vector2.zero;
    }
}
