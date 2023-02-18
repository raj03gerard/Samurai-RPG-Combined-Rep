using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Animation_To_Statemachine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartStatemachine()
    {
        Enemy3 enemy = this.GetComponent<Enemy3>();
        enemy.stateMachine.ChangeState(enemy.moveState);
    }
}
