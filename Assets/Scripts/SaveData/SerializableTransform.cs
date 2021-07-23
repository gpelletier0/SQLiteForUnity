using System;
using UnityEngine;

/// <summary>
/// A Serializable Transform class
/// </summary>
[Serializable]
internal class SerializableTransform
{
    public Vector3 pos = Vector3.zero;
    public Vector3 rot = Vector3.zero;
    public Vector3 scale = Vector3.zero;

    public SerializableTransform()
    {
        pos = Vector3.zero;
        rot = Vector3.zero;
        scale = Vector3.zero;
    }

    public SerializableTransform(Vector3 paramPos, Vector3 paramRot, Vector3 paramScale)
    {
        pos = paramPos;
        rot = paramRot;
        scale = paramScale;
    }
}