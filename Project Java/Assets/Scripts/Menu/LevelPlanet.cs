using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlanet : MonoBehaviour
{
    public string levelName;
    [SerializeField]
    private MeshRenderer[] mesh;

    public void SetMeshState(Material mat)
    {
        foreach(MeshRenderer m in mesh)
        {
            m.material = mat;
        }
    }
}
