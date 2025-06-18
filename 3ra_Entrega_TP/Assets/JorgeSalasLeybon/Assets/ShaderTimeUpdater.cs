using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTimeUpdater : MonoBehaviour
{
    public Material material;
    void Update()
    {
        if (material != null)
        {
            material.SetFloat("_CustomTime", Time.time);
        }
    }
}
