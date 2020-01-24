using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class FileReader : MonoBehaviour
{
    public static FileReader instance;
    public string[] gatterSprites;
    
    private string root;

    void Start()
    {
        if(instance == null)
            instance = this;

        root = Directory.GetCurrentDirectory();
        ReadGatterSprites();
    }

    private void ReadGatterSprites()
    {
        gatterSprites = Directory.GetFiles(root + "/Assets/Materials/GatterSprites");
        gatterSprites = gatterSprites.Where(s => !s.EndsWith("meta")).ToArray();
    }

    /// <summary>
    /// Compilea a file to an Texture2D
    /// </summary>
    /// <param name="s">the path where the file can be found</param>
    /// <returns>Texture2D of the file</returns>
    public Texture2D FileToTex(string s)
    {
        byte[] fileData = File.ReadAllBytes(s);
        Texture2D tex = new Texture2D(2, 2); //Die Werte hier sind egal
        tex.LoadImage(fileData); //passt die TexturGröße automatisch an
        return tex;
    }

    /// <summary>
    /// Compilea a file to an Sprite
    /// </summary>
    /// <param name="s">the path where the file can be found</param>
    /// <returns>Sprite of the file</returns>
    public Sprite FileToSprite(string s)
    {
        Texture2D tex = FileToTex(s);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
        return sprite;
    }
}
