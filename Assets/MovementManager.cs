using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {
    private Vector3 pickerLocation;
    private Vector3[,] locations;
    public int locationX = 0;
    public int locationY = 0;
    public bool pieceChosen = false;
    public GameObject piece;
	// Use this for initialization
	void Start () {
        locations = gameObject.GetComponent<BoardArray>().GetLocations();
        pickerLocation = locations[0, 0];
    }
	
	// Update is called once per frame
	void Update () {
        //Moves selector piece up on the board
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


        //Moves selector piece down on the board
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


        //Moves selector piece left on the board
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

        //Moves selector piece right on the board
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

        //Chooses the piece you want to move
        if (Input.GetKeyDown("space"))
        {
            //Checks if a piece is chosen
            if (pieceChosen == true)
            {
                //Checks if location us clear of other pieces
                if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
                {
                    piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                    pieceChosen = false;
                    GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
                }
            }

            else if (pieceChosen == false)
            {
                //Checks if chosen location has a piece
                if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] != null)
                {
                    piece = GetComponent<BoardArray>().GetPieces()[locationY, locationX];
                    //Checks which players piece is chosen
                    if (piece.tag == "1")
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                    }
                    else if (piece.tag == "2")
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                    }
                    else if(piece.tag == "3")
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                    }
                    else if(piece.tag == "4")
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                    }
                    else
                    {
                        piece = null;
                    }
                }
            }
        }
    }
}
