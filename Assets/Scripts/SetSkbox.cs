using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkbox : MonoBehaviour
{
    public Material skboxMaterial { get; set; }

    void Select()
    {
        RenderSettings.skybox = skboxMaterial;
    }
}
