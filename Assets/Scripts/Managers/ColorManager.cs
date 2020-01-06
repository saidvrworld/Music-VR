using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
///  Manage the combination of colors
///  1.Get combinations from ColorData
/// </summary>
public class ColorManager : MonoBehaviour
{
    public ColorPack[] getColorComb() {
        return ColorData.getColorPacksList();  // get new color Pack from Color Data

    }

    public Color getBackgroundColor() {

        return Color.white;
    }

}
