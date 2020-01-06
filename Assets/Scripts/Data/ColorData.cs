using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Text;

public static class ColorData
{

    public static ColorPack[] getColorPacksList() {

        string dataFromFile = getDataFromLocalFile("color_collection1.txt");
        JSONNode data = JSONNode.Parse(dataFromFile);
        ColorPack[] colorPacks =new ColorPack[data["color_packs"].Count];
        
        for (int i = 0; i < data["color_packs"].Count; i++) {
             ColorPack newColorPack = getColorPackFromJson(data["color_packs"][i]);
            colorPacks[i] = newColorPack;
        }

        return colorPacks;
    }

    public static ColorPack getColorPackFromJson(JSONNode colorPack) {
        ColorPack newColorPack = new ColorPack(colorPack["name"].Value);

        for(int i = 0; i < colorPack["colors"].Count;i++) {
        
            Color32 color = parseColorFromJson(colorPack["colors"][i]);
            newColorPack.colors_list.Add(color);
        }

        return newColorPack;
    }

    ///<summary>
    ///Parse color from Json and convert it to Color32 type 
    ///</summary>
    ///<param name="color_js">Json object with r,g,b,a</param>
    ///<returns>Color32 type object converted from Json</return>

    private static Color32 parseColorFromJson(JSONNode color_js) {

        byte r = (byte)(color_js["r"].AsInt);
        byte g = (byte)color_js["g"].AsInt;
        byte b = (byte)color_js["b"].AsInt;
        byte a = (byte)color_js["a"].AsInt;
        Color32 color = new Color32(r, g, b, a);
        return color;
    }

    ///<summary>
    ///Open local file and read Json from it
    ///</summary>
    ///<param name="path">path to file</param>
    ///<returns>return string object with data from file 
    
    private static string getDataFromLocalFile(string path) {
        string json_colors = "";

        using (System.IO.FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b, 0, b.Length) > 0)
            {
                json_colors += temp.GetString(b);
            }
        }
        return json_colors;
    }

    /*
     public static Color32 petal = new Color32(249, 136, 102, 255);
    public static Color32 poppy = new Color32(255, 66, 14, 255);
    public static Color32 stem = new Color32(128, 189, 158, 255);
    public static Color32 spring_green = new Color32(137, 218, 89, 255);
    public static Color32[] colorPack1 = { petal, poppy, stem, spring_green };

     public static void CreateColorList() {
        JSONNode data = new JSONNode();
        JSONNode color_pack = new JSONNode();
        JSONNode color_packs = new JSONNode();


        color_pack.Add("petal", CreateColor("249", "136", "102", "255"));
        color_pack.Add("poppy", CreateColor("255", "66", "14", "255"));
        color_pack.Add("stem", CreateColor("128", "189", "158", "255"));
        color_pack.Add("spring_green", CreateColor("137", "218", "89", "255"));
        Debug.Log(color_pack.ToString());

        color_packs.Add("fall", color_pack);
        data.Add("color_packs", color_packs);

        data.SaveToFile("color_collection1.txt");

        Debug.Log(data.ToString());
    }


    private static JSONNode CreateColor(string r, string g, string b, string a = "255") {
        JSONNode color = new JSONNode();
        JSONNode red = new JSONNode();
        JSONNode green = new JSONNode();
        JSONNode blue = new JSONNode();
        JSONNode alpha = new JSONNode();
        red.Value = r;
        green.Value = g;
        blue.Value = b;
        alpha.Value = a;

        color.Add("r", red);
        color.Add("g", green);
        color.Add("b", blue);
        color.Add("a", alpha);
        return color;
    }

      */
}
