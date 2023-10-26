using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleColorScript : MonoBehaviour
{
    private Renderer finalHoleRenderer;

    void Start()
    {
        finalHoleRenderer = GetComponent<Renderer>();
        try
        {
            finalHoleRenderer.material.SetColor("_Base", ChangeColorScript.changeColorInstance.newBaseHoleColor);
            finalHoleRenderer.material.SetColor("_Border", ChangeColorScript.changeColorInstance.newBorderHoleColor);
        }
        catch
        {

        }
        
    }
    
}
