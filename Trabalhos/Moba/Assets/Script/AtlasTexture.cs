using UnityEngine;
using System.Collections;

public class AtlasTexture
{
    public static Texture2D Create(Texture2D[] textures, out Rect[] rects)
    {
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.RGBA32, false);

        rects = texture.PackTextures(textures, 0, 1024);

        return texture;
    }
}
