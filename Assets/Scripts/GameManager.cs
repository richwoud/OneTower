using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   

    private int _ordinaryMoney;
    private int _gold;
    private float _score;
    private float _maxScore;

    public int OrdinaryMoney { get { return _ordinaryMoney; } set { _ordinaryMoney = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }
    public float Score { get { return _score; } set { _score = value; } }
    public float MaxScore { get { return _maxScore; } set { _maxScore = value; } }



    private void Awake()
    {
        
    }

    private void Update()
    {
        
    }


}
