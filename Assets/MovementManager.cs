using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {
    private Vector3 pickerLocation;
    private Vector3[,] locations;
    public int shape;
    public int locationX = 0;
    public int locationY = 0;
    public int originX = 0;
    public int originY = 0;
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

        if (Input.GetKeyDown("escape"))
        {
            GetComponent<BoardArray>().GetPieces()[originY, originX] = piece;
            piece = null;
            pieceChosen = false;
        }

        //Chooses the piece you want to move
        if (Input.GetKeyDown("space"))
        {
            //Checks if a piece is chosen
            if (pieceChosen == true)
            {
                if(piece.layer == 8)
                {
                    CircleMovement();
                }
                else if (piece.layer == 9)
                {
                    SquareMovement();
                }
                else if(piece.layer == 10)
                {
                    TriangleMovement();
                }
                else if(piece.layer == 11)
                {
                    DiamondMovement();
                }
            }

            else if (pieceChosen == false)
            {
                //Checks if chosen location has a piece
                if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] != null)
                {
                    piece = GetComponent<BoardArray>().GetPieces()[locationY, locationX];

                    //Checks which players piece is chosen
                    if (piece.tag == "1" && GetComponent<TurnManager>().GetTurn() == 1)
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                        GetComponent<TurnManager>().TurnChange();
                        originX = locationX;
                        originY = locationY;
                    }

                    else if (piece.tag == "2" && GetComponent<TurnManager>().GetTurn() == 2)
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                        GetComponent<TurnManager>().TurnChange();
                        originX = locationX;
                        originY = locationY;
                    }

                    else if (piece.tag == "3" && GetComponent<TurnManager>().GetTurn() == 3)
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                        GetComponent<TurnManager>().TurnChange();
                        originX = locationX;
                        originY = locationY;
                    }

                    else if (piece.tag == "4" && GetComponent<TurnManager>().GetTurn() == 4)
                    {
                        GetComponent<BoardArray>().GetPieces()[locationY, locationX] = null;
                        pieceChosen = true;
                        GetComponent<TurnManager>().TurnChange();
                        originX = locationX;
                        originY = locationY;
                    }

                    //If player chooses another player's piece, it will not choose anything
                    else
                    {
                        piece = null;
                    }
                }
            }
        }
    }

    public void SquareMovement()
    {
        if (locationX == originX - 1 && locationY == originY)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX + 1 && locationY == originY)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX && locationY == originY - 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX && locationY == originY + 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
    }

    public void DiamondMovement()
    {
        if (locationX == originX - 1 && locationY == originY - 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX + 1 && locationY == originY + 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX + 1 && locationY == originY - 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX - 1 && locationY == originY + 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
    }

    public void CircleMovement()
    {
        if (locationX == originX - 1 && locationY == originY - 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX + 1 && locationY == originY + 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX + 1 && locationY == originY - 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX - 1 && locationY == originY + 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX - 1 && locationY == originY)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX + 1 && locationY == originY)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX && locationY == originY - 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
        else if (locationX == originX && locationY == originY + 1)
        {
            //Checks if location is clear of other pieces
            if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
            {
                piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                pieceChosen = false;
                GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
            }
        }
    }

    public void TriangleMovement()
    {
        if(piece.tag == "1")
        {
            if (locationX == originX - 1 && locationY == originY - 1)
            {
                //Checks if location is clear of other pieces
                if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
                {
                    piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                    pieceChosen = false;
                    GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
                }
            }
            else if (locationX == originX + 1 && locationY == originY - 1)
            {
                //Checks if location is clear of other pieces
                if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
                {
                    piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                    pieceChosen = false;
                    GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
                }
            }
            else if (locationX == originX && locationY == originY + 1)
            {
                //Checks if location is clear of other pieces
                if (GetComponent<BoardArray>().GetPieces()[locationY, locationX] == null)
                {
                    piece.GetComponent<Transform>().position = GetComponent<BoardArray>().GetLocations()[locationY, locationX];
                    pieceChosen = false;
                    GetComponent<BoardArray>().GetPieces()[locationY, locationX] = piece;
                }
            }
        }
    }
    public GameObject GetPiece()
    {
        return piece;
    }
}
