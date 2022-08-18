using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseJump : MonoBehaviour
{
    Movement move;
    private void Awake()
    {
        move = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }
    public void InreaseJumps()
    {
        if (MaxNumberofJumps <= 3 && coinCount >= 3)
        {
            coinCount -= 3;
             MaxNumberofJumps++;
           

        }

    }
}
