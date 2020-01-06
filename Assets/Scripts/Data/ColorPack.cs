using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPack 
{

    public string name;
    public List<Color32> colors_list;

    public ColorPack(string name) {
        this.name = name;
        colors_list = new List<Color32>();
    }
   
}
