using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {
    private Vector3 pickerLocation;
    private Vector3[,] locations;
    public int locationX = 0;
    public int locationY = 0;
	// Use this for initialization
	void Start () {
        locations = gameObject.GetComponent<BoardArray>().GetLocations();
        pickerLocation = locations[0, 0];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            if(locationY-1 < 0)
            {
                locationY = 9;
            }
            else
            {
                locationY -= 1;
            }
            pickerLocation.y = locations[locationY, locationX].y;
            pickerLocation.z = 0;
            GameObject.Find("picker").GetComponent<Transform>().position = pickerLocation;
        }

        if (Input.GetKeyDown("down"))
        {
            if (locationY + 1 > 9)
            {
                locationY = 0;
            }
            else
            {
                locationY += 1;
            }
            pickerLocation.y = locations[locationY, locationX].y;
            pickerLocation.z = 0;
            GameObject.Find("picker").GetComponent<Transform>().position = pickerLocation;
        }

        if (Input.GetKeyDown("left"))
        {
            if (locationX - 1 < 0)
            {
                locationX = 9;
            }
            else
            {
                locationX -= 1;
            }
            pickerLocation.x = locations[locationY, locationX].x;
            pickerLocation.z = 0;
            GameObject.Find("picker").GetComponent<Transform>().position = pickerLocation;
        }

        if (Input.GetKeyDown("right"))
        {
            if (locationX + 1 > 9)
            {
                locationX = 0;
            }
            else
            {
                locationX += 1;
            }
            pickerLocation.x = locations[locationY, locationX].x;
            pickerLocation.z = 0;
            GameObject.Find("picker").GetComponent<Transform>().position = pickerLocation;
        }
    }
}
