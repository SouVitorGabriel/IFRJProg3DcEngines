using UnityEngine;
using System.Collections;

public class AtlasManager : MonoBehaviour 
{
    public static Texture2D globalTexture;
    public static Rect[] rects;
    public static Material globalMaterial; 
    
    private Texture2D[] textures;
    
    void Awake () 
    {
        //string[] files = new string[] {"default"};

        int numImage = 16;

        textures = new Texture2D[numImage];

        this.textures[0] = (Texture2D)Resources.Load("Texture/" + "default");

        for (var i = 1; i < numImage; i++)
        {
            this.textures[i] = (Texture2D)Resources.Load("Texture/" + "monstro" + i);
        }
        
        globalTexture = AtlasTexture.Create(this.textures, out rects);

        globalMaterial =  new Material((Shader)Resources.Load("Shader/Basic2D")); // (Material)Resources.Load("material");
        globalMaterial.mainTexture = globalTexture;
	}
}
