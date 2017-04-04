using UnityEngine;
using System.Collections;

public class BoardArray : MonoBehaviour {
    private Vector3[,] locations = new Vector3[10,10];
    private GameObject[,] pieces = new GameObject[10,10];
	// Use this for initialization
	void Start ()
    {
        locations[0, 0] = GameObject.Find("A0").GetComponent<Transform>().position;
        float y = locations[0, 0].y;
        for (int i = 0; i<10; i++)
        {
            for(int j = 0; j<10; j++)
            {
                if (j == 0)
                {
                    locations[i, j].x = locations[0, 0].x;
                    locations[i, j].y = y;
                }
                else
                {
                    locations[i, j].x = locations[0, j-1].x + 1;
                    locations[i, j].y = y;
                    locations[i, j].z = 0;
                }
            }
            y -= 1;
        }
        pieces[3, 9] = GameObject.Find("Player One Circle");
    }

    // Update is called once per frame
    void Update ()
    {

	}

    public Vector3[,] GetLocations()
    {
        return locations;
    }

    public GameObject[,] GetPieces()
    {
        return pieces;
    }

    
}
