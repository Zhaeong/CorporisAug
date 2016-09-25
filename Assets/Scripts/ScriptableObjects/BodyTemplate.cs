using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BodyTemplate", menuName = "BodyTemplate", order = 1)]
public class BodyTemplate : ScriptableObject
{
    public Vector2[] BodyParts;
}