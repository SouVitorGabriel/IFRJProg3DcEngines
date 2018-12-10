using UnityEngine;
using System.Collections;

public class LevelManager
{
    private static LevelManager instance = null;

    private int level;

    static public int[] numberCards = new int[] { 9, 12, 15, 18, 21 };

    private LevelManager()
    {
        this.SetLevel(1);
    }

    public static LevelManager GetInstance()
    {
        if (instance == null)
        {
            instance = new LevelManager();
        }

        return instance;
    }

    public void SetLevel(int level)
    {
        if (level < 1)
        {
            this.level = 1;
        }
        else if (level > numberCards.Length)
        {
            this.level = numberCards.Length;
        }
        else
        {
            this.level = level;
        }
    }

    public int GetLevel()
    {
        return this.level;
    }
}
