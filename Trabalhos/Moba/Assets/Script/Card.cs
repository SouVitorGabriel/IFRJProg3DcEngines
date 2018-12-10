using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour 
{
    public enum StateCard
    {
        CARD_BACK,
        CARD_FRONT,
    };

    private int id = -1;
    private int image_id = -1;

    static public float width = 0.6f;
    static public float height = 0.6f;

    static public int numFrontCards = 0;
    static public int numMaxFrontCards = 2;

    private StateCard state;


    public GameObject go;

    GameObject[] array_ = new GameObject[10];

    public bool update = false;
    
	void Start () 
    {
        for (var i = 0; i < 10; i++)
        {
            array_[i] = go;
        }

        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();
        
        Mesh mesh = Quad.Create(0.5f, 0.5f); // Card.width, Card.height);

        this.gameObject.GetComponent<MeshFilter>().mesh = mesh;
        this.gameObject.GetComponent<MeshRenderer>().material = AtlasManager.globalMaterial;

        this.gameObject.GetComponent<MeshFilter>().mesh.uv = new Vector2[] 
        {
            new Vector2(AtlasManager.rects[id].xMin, AtlasManager.rects[id].yMax),
            new Vector2(AtlasManager.rects[id].xMax, AtlasManager.rects[id].yMax),
            new Vector2(AtlasManager.rects[id].xMax, AtlasManager.rects[id].yMin),
            new Vector2(AtlasManager.rects[id].xMin, AtlasManager.rects[id].yMin)
        };

        state = StateCard.CARD_BACK;
	}
	
	void Update () 
    {
        switch (this.state)
        {
            case StateCard.CARD_BACK:
                this.SetId(0);
                break;

            case StateCard.CARD_FRONT:
                this.SetId(this.image_id);
                break;
        }

        if (numFrontCards < numMaxFrontCards)// && CardManager.update)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (state != StateCard.CARD_FRONT)
                {
                    if (v.x > transform.position.x - 0.5f &&
                        v.x < transform.position.x + 0.5f &&
                        v.y < transform.position.y + 0.5f &&
                        v.y > transform.position.y - 0.5f)
                    {
                        this.state = StateCard.CARD_FRONT;
                        numFrontCards++;

                        if (CardManager.cardA == null)
                        {
                            CardManager.cardA = this.gameObject;
                        }
                        else if (CardManager.cardB == null)
                        {
                            CardManager.cardB = this.gameObject;
                        }
                    }
                }
            }
        }

        this.update = true;
	}

    public void SetId(int id)
    {
        if (id != 0)
        {
            this.image_id = id;
        }

        if (this.id != id)
        {
            this.id = id;

            if (this.gameObject.GetComponent<MeshFilter>() != null)
            {
                this.gameObject.GetComponent<MeshFilter>().mesh.uv = new Vector2[] 
                {
                    new Vector2(AtlasManager.rects[id].xMin, AtlasManager.rects[id].yMax),
                    new Vector2(AtlasManager.rects[id].xMax, AtlasManager.rects[id].yMax),
                    new Vector2(AtlasManager.rects[id].xMax, AtlasManager.rects[id].yMin),
                    new Vector2(AtlasManager.rects[id].xMin, AtlasManager.rects[id].yMin)
                };
            }
        }
    }

    public int GetId()
    {
        return this.id;
    }

    public StateCard State
    {
        get
        {
            return this.state;
        }

        set
        {
            this.state = value;
        }
    }
}
