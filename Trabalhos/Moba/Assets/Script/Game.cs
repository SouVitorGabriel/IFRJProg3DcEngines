using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
    // background
    // pontuação ???
    CardManager cardManager;

	void Start () 
    {
        this.cardManager = new CardManager();	
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        this.cardManager.Update();
        this.TestWinLevel();
	}

    void TestWinLevel()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Card");

        if (g.Length <= 1)
        {
            int l = this.cardManager.levelManagerRef.GetLevel();

            if (l >= LevelManager.numberCards.Length)
            {
                // FIM DO JOGO
                // MUDAR PARA A CENA CONGRATS/GAMEOVER

                // provisorio - volta para o level 1
                this.cardManager.levelManagerRef.SetLevel(1);
                this.cardManager = new CardManager();
            }
            else
            {
                this.cardManager.levelManagerRef.SetLevel(l + 1);
                this.cardManager = new CardManager();
            }
        }

    }
}
