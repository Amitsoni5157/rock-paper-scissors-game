using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Hand : MonoBehaviour
{
    [SerializeField] private string m_name_Gesture;     //Name Of Hand Action
    [SerializeField] private Image m_Icon_Gesture;      //Action Image
    [SerializeField] private Transform pointTomove;     //Hand Move Point
    private int randomNumber;
    private int lastNumber;

    Vector3 startpos_A;
    Vector3 startpos_B;

    public playerType playerType;
    private void OnEnable()
    {   
        Invoke("DelayInInit",0.5f);
        GameManager.OnReplayedEvent += ReplayAction;
        // StartCoroutine("CO_MoveHand");
    }

    /// <summary>
    /// Game Will be replay from here
    /// </summary>
    private void ReplayAction()
    {
        ResetHandPosition();
        Invoke("DelayInInit", 0.5f);
    }


    /// <summary>
    /// Sprite and Name of hand will be assign from here
    /// </summary>
    /// <param name="_Name"></param>
    /// <param name="_Icon"></param>
    public void Init(string _Name, Sprite _Icon)
    {
        m_name_Gesture = _Name;
        m_Icon_Gesture.sprite = _Icon;
    }

    /// <summary>
    /// Just Give Delay of .5 from here
    /// </summary>
   private void DelayInInit()
    {
        HandMove();
        switch (playerType)
        {
            case playerType.Player:
                Init(GameManager.Ins._data.handdata[0].hName, GameManager.Ins._data.handdata[0].hIcon);
                GameManager.Ins.GetPlayrHandName(GameManager.Ins._data.handdata[0].hName);
                break;
            case playerType.opponent:
                int rndCount = NewRandomNumber();
                Init(GameManager.Ins._data.handdata[rndCount].hName, GameManager.Ins._data.handdata[rndCount].hIcon);                
                GameManager.Ins.GetOppHandName(GameManager.Ins._data.handdata[rndCount].hName);
                break;
        }
        StartCoroutine(GameManager.Ins.DeclareWinner());
    }

    /// <summary>
    /// Hand Move Action will work from here
    /// </summary>
    private void HandMove()
    {
        switch (playerType)
        {
            case playerType.Player:
                startpos_A = this.transform.position;
                this.transform.DOMove(pointTomove.position,0.15f);
                break;
            case playerType.opponent:
                startpos_B = this.transform.position;
                this.transform.DOMove(pointTomove.position, 0.15f);
                break;
        }
    }

    /// <summary>
    /// Random number genration
    /// </summary>
    /// <returns></returns>
    private int NewRandomNumber()
    {
        randomNumber = Random.Range(0, 3);
        while (randomNumber == lastNumber)
        {
            randomNumber = Random.Range(0, 3);
        }
        lastNumber = randomNumber;
        return randomNumber;
    }

    /// <summary>
    /// Hand Will be reset after game end
    /// </summary>
    private void ResetHandPosition()
    {
        switch (playerType)
        {
            case playerType.Player:
                this.transform.position = startpos_A;
                break;
            case playerType.opponent:
                this.transform.position = startpos_B;
                break;
        }
    }
    private void OnDisable()
    {
        GameManager.OnReplayedEvent -= ReplayAction;
    }

}
