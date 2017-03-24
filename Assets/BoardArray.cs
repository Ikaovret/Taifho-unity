using UnityEngine;
using System.Collections;

public class BoardArray : MonoBehaviour {
    private Vector3[,] locations = new Vector3[10,10];
    private bool[,] isFree = new bool[10,10];
	// Use this for initialization
	void Awake ()
    {
        locations[0, 0] = GameObject.Find("A0").GetComponent<Transform>().position;
        for(int i = 0; i<10; i++)
        {
            for(int j = 0; j<10; j++)
            {
                locations[i, j].x = locations[0, 0].x + 1;
                locations[i, j].y = locations[0, 0].y;
                locations[i, j].z = locations[0, 0].z;
            }
        }
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j<10; j++)
            {
                isFree[i, j] = false;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {

	}

    public Vector3[,] GetLocations()
    {
        return locations;
    }

    public bool[,] GetIsFree()
    {
        return isFree;
    }

    public void PlaceIsFree(int x, int y)
    {
        isFree[x, y] = true;
    }

    public void EmptyIsFree(int x, int y)
    {
        isFree[x, y] = false;
    }
}
