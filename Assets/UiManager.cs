using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiManager : MonoBehaviour {
    private MovementManager man;
    private GameObject play;
    private GameObject quit;
    private GameObject back;
    private GameObject players2;
    private GameObject players3;
    private GameObject players4;
    // Use this for initialization
    void Start () {
        man = GetComponent<MovementManager>();
        play = GameObject.Find("Play Button");
        quit = GameObject.Find("Quit Button");
        back = GameObject.Find("Back Button");
        players2 = GameObject.Find("2Players");
        players3 = GameObject.Find("3Players");
        players4 = GameObject.Find("4Players");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        back.SetActive(true);
        back.GetComponent<Button>().interactable = true;
        quit.SetActive(false);
        quit.GetComponent<Button>().interactable = false;
        play.SetActive(false);
        play.GetComponent<Button>().interactable = false;
        players2.SetActive(true);
        players2.GetComponent<Button>().interactable = true;
        players3.SetActive(true);
        players3.GetComponent<Button>().interactable = true;
        players4.SetActive(true);
        players4.GetComponent<Button>().interactable = true;
        man.enabled = !man.enabled;
    }
}
