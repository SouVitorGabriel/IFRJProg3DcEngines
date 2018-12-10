using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager
{
    enum State
    {
        TEST_STOP,
        TEST_RUN,
    };

    public LevelManager levelManagerRef;
    static string[] cardNames;

    public static GameObject cardA = null;
    public static GameObject cardB = null;
    public static GameObject cardC = null;

    float wait = 0;

    State state = State.TEST_STOP;

    bool destroy = true;

    //public static bool update = false;

    public CardManager()
    {
        DestroyCards();

        cardNames = new string[]
		{
            "joker",
			"card01",
			"card02",
			"card03",
			"card04", // 9
			"card05",
			"card06", // 12 - joker
			"card07", // 15
			"card08",
			"card09", // 18 - joker
			"card10", // 21
		};

        this.levelManagerRef = LevelManager.GetInstance();

        int currentLevel = this.levelManagerRef.GetLevel() - 1;

        int currentNumberCard = (int)(LevelManager.numberCards[currentLevel] / 2);

        GameObject[] cards = new GameObject[LevelManager.numberCards[currentLevel]];
        
        int j = 0;

        for (var i = (currentLevel % 2 == 0) ? 0 : 1;
             i < currentNumberCard + 1; i++)
        {
            cards[j] = new GameObject(cardNames[i], typeof(Card));
            cards[j].tag = "Card";
            cards[j].GetComponent<Card>().SetId(i+1);
            cards[j++].GetComponent<Card>().SetId(0);

            if (i > 0)
            {
                cards[j] = new GameObject(cardNames[i], typeof(Card));// + "_", typeof(Card));
                cards[j].tag = "Card";
                cards[j].GetComponent<Card>().SetId(i + 1);
                cards[j++].GetComponent<Card>().SetId(0);
            }
        }

        this.Shuffle(ref cards);
        this.SetPosition(ref cards);
    }

    public void Shuffle(ref GameObject[] cards)
    {
        for (var i = 0; i < cards.Length; i++)
        {
            int rand = Random.Range(0,cards.Length);
            var temp = cards[i];
            cards[i] = cards[rand];
            cards[rand] = temp;
        }
    }

    void SetPosition(ref GameObject[] cards)
    {
        int column = cards.Length / 3;
        int row = 3;

        //float space = 1.1f;

        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < column; j++)
            {
                cards[i * column + j].transform.position = new Vector3((j * Card.width  * 2) - (column / 2.0f * Card.width  * 2) + Card.width,
                                                                       -((i * Card.height * 2) - (row    / 2.0f * Card.height * 2) + Card.height),
                                                                        0);
            }
        }
    }

    void DestroyCards()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject go in g)
        {
            GameObject.Destroy(go);
        }
    }

    void Reset()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject go in g)
        {
            go.GetComponent<Card>().State = Card.StateCard.CARD_BACK;
        }

        cardA = null;
        cardB = null;
        cardC = null;
        Card.numFrontCards = 0;

        this.state = State.TEST_STOP;
    }

    void TestCards()
    {
        switch (state)
        {
            case State.TEST_STOP:

                if (Card.numFrontCards >= Card.numMaxFrontCards)
                {
                    destroy = true;

                    if (cardA.name != "joker" && cardB.name != "joker")
                    {
                        if (cardA.name != cardB.name)
                        {
                            destroy = false;
                        }
                    }
                    else
                    {
                        string target;

                        if (cardA.name == "joker")
                        {
                            target = cardB.name;
                        }
                        else
                        {
                            target = cardA.name;
                        }

                        GameObject[] g = GameObject.FindGameObjectsWithTag("Card");
                        GameObject[] equal = new GameObject[2];

                        int i = 0;

                        foreach (GameObject go in g)
                        {
                            if (go.name == target)
                            {
                                equal[i++] = go;
                            }
                        }

                        if (cardA.name == "joker")
                        {
                            cardB = equal[0];
                            cardC = equal[1];
                        }
                        else
                        {
                            cardA = equal[0];
                            cardC = equal[1];
                        }
                    }

                    //new MonoBehaviour().StartCoroutine(Stop());

                    this.wait = 0;
                    this.state = State.TEST_RUN;
                }
                break;

                case State.TEST_RUN:

                    this.wait += Time.deltaTime;

                    if (this.wait > 1)
                    {
                        Debug.Log(this.wait);

                        if (destroy)
                        {
                            // ativa alguma função especial do(s) card(s)

                            GameObject.Destroy(cardA);
                            GameObject.Destroy(cardB);

                            if (cardC != null)
                            {
                                GameObject.Destroy(cardC);
                            }
                        }

                        this.Reset();
                    }
                    break;
        }
    }

    public void Update()
    {
        //update = false;

        this.TestCards();

        //update = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3);

        this.wait += Time.deltaTime;

        if (this.wait > 1)
        {
            Debug.Log(this.wait);

            if (destroy)
            {
                // ativa alguma função especial do(s) card(s)

                GameObject.Destroy(cardA);
                GameObject.Destroy(cardB);

                if (cardC != null)
                {
                    GameObject.Destroy(cardC);
                }
            }

            this.Reset();
        }
    }
}
