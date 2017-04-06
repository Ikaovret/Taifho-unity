using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiManager : MonoBehaviour {

    private MovementManager man;
    public GameObject play;
    public GameObject quit;
    public GameObject back;
    public GameObject players2;
    public GameObject players3;
    public GameObject players4;
    public GameObject tutorial;
    public GameObject text;
    private bool boolean = false;

    // Use this for initialization
    void Start () {
        man = GetComponent<MovementManager>();
    }

    public void Play()
    {

        quit.SetActive(false);
        quit.GetComponent<Button>().interactable = false;

        players2.SetActive(true);
        players2.GetComponent<Button>().interactable = true;

        players3.SetActive(true);
        players3.GetComponent<Button>().interactable = true;

        players4.SetActive(true);
        players4.GetComponent<Button>().interactable = true;

        play.SetActive(false);
        play.GetComponent<Button>().interactable = false;

        back.SetActive(true);
        back.GetComponent<Button>().interactable = true;

        tutorial.SetActive(false);
        tutorial.GetComponent<Button>().interactable = false;
    }

    public void Back()
    {
        quit.SetActive(true);
        quit.GetComponent<Button>().interactable = true;

        players2.SetActive(false);
        players2.GetComponent<Button>().interactable = false;

        players3.SetActive(false);
        players3.GetComponent<Button>().interactable = false;

        players4.SetActive(false);
        players4.GetComponent<Button>().interactable = false;

        play.SetActive(true);
        play.GetComponent<Button>().interactable = true;

        back.SetActive(false);
        back.GetComponent<Button>().interactable = false;

        tutorial.SetActive(true);
        tutorial.GetComponent<Button>().interactable = true;

    }

    public void Tutorial()
    {
        boolean = !boolean;
        text.SetActive(boolean);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
