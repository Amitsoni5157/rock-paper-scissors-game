using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public delegate void ReplayAction();
    public static event ReplayAction OnReplayedEvent;

    public static GameManager Ins = null;

    public Data _data;//scriptable object

    private string nameOfPlayerHand;
    private string nameOfOppHand;
    [Header("Win Panel Data")]
    [SerializeField] private GameObject m_Loose_Win_Panel;
    [SerializeField] private Text m_Loose_Win_Text;
    private void Awake()
    {
        Ins = this;
    }


    public void GetOppHandName(string _hndName)
    {
        nameOfOppHand = _hndName;
    }

    public void GetPlayrHandName(string _hndName)
    {
        nameOfPlayerHand = _hndName;
    }

    /// <summary>
    /// Winner declare from here 
    /// </summary>
    /// <returns></returns>
    public IEnumerator DeclareWinner()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log(nameOfOppHand + " :::Opp plyr:::" + nameOfPlayerHand);

        if (nameOfPlayerHand == "Rock" && nameOfOppHand == "Rock")
        {
       //     Debug.Log("Match Draw");
            WinLoosePanel("Match Draw");
        }
        if (nameOfPlayerHand == "Rock" && nameOfOppHand == "Paper")
        {
      //      Debug.Log("Player B Win");
            WinLoosePanel("Player B Win");
        }
        if (nameOfPlayerHand == "Rock" && nameOfOppHand == "Scissors")
        {
      //      Debug.Log("Player A Win");
            WinLoosePanel("Player A Win");

        }
    }


    private void WinLoosePanel(string winLoose)
    {
        m_Loose_Win_Panel.SetActive(true);
        m_Loose_Win_Text.text = winLoose;
    }

    public void ReplayButton()
    {
        m_Loose_Win_Panel.SetActive(false);
        OnReplayedEvent();
    }
}
