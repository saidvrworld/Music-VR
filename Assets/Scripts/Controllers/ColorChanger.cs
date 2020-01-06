using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChanger : MonoBehaviour
{

    public Material[] sceneMaterials;
    ColorManager colorManager = new ColorManager();
    public AudioSource audioSource;
    public Camera mainCamera;
    public void Start()
    {
        SetSceneMaterialsColor();

        float[] samples = new float[audioSource.clip.samples * audioSource.clip.channels];

    float[] spectrum = audioSource.GetSpectrumData(10, 0, FFTWindow.Hamming);
        Debug.Log(spectrum);

        for (int i = 0; i< 10; i++) { 
        Debug.Log(spectrum[i]);


        }
     
    }

    ///<summary>
    ///Change color of given material 
    ///</summary>
    ///<param name="material">material to change</param>
    ///<param name="newColor">new color to set on material</param>

    private void ChangeColorOfMaterial(Material material,Color32 newColor) {
   
        material.SetColor("_Color", newColor);
    }

    ///<summary>
    ///set new colors for all material listed in sceneMaterials
    ///</summary>
    public void SetSceneMaterialsColor()
    {
        ColorPack color_pack = colorManager.getColorComb()[0];    // get new color comb from  ColorManager


        int sizeOfMaterial = sceneMaterials.Length;  // lenght of sceneMaterial 
        int indMat = 0;                                 // index of Material in sceneMaterial list
        int indClr = 0;                               // index of color in colorComb list

        mainCamera.backgroundColor = colorManager.getBackgroundColor();  // et color for backGround
       
        List<Color32> color_list = color_pack.colors_list;
        int sizeOfColorPacks = color_list.Count;                 // number of colors in Color Combination 
        while (indMat < sizeOfMaterial) {

            //if colors in colorComb finished, set pointer to zero and start over
            if (indClr >= sizeOfColorPacks) { indClr = 0; }

            ChangeColorOfMaterial(sceneMaterials[indMat], color_list[indClr]);

            indMat++;
            indClr++;
        }
    }



        
    



}
