using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	private int turn = 1;
    private int players = 2;
    public void SetPlayers(int players){
        this.players = players;
    }
	public int GetTurn(){
		return turn;
	}
	public void SetTurn(int turn){
		this.turn = turn;
	}
	public void TurnChange(){
		if (turn > players) {
			turn = 1;
		} 
		else {
			turn = +1;
		}
	}

    public void TwoPlayers()
    {
        SetPlayers(2);
    }

    public void ThreePlayers()
    {
        SetPlayers(3);
    }
    public void FourPlayers()
    {
        SetPlayers(4);
    }
	// Use this for initialization

}
