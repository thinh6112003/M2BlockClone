using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanState : IState
{
    bool check ;
    float timer;
    public void OnEnter(GameManager gM)
    {
        gM.currentEnumState = State.BAN;
        gM.KhoiTao();
        gM.blockDangChay.transform.position = gM.vitriBan;
        gM.currentNumber = gM.nextNumber;
        gM.nextNumber = Random.Range(0, gM.maxnumber);
        gM.updateXemTruoc();
        check = false;
        timer = 0;
    }

    public void OnExecute(GameManager gM)
    {
        if (check)
        {
            if (timer>0.0)
            {
                gM.ChangeState(new GopState());
            }
            timer += Time.deltaTime;
        }
        else
        {
            if (Vector2.Distance(gM.blockDangChay.transform.position, gM.vitriDen) < 0.01)
            {
                gM.blockDangChay.transform.position = gM.vitriDen;
                //gM.StartCoroutine(updateBlock(gM));
                check = true;
            }
            else
            {
                gM.blockDangChay.transform.position = Vector2.MoveTowards(gM.blockDangChay.transform.position, gM.vitriDen, 2f * gM.buocNhay* Time.deltaTime);
            }
        }
    }

    public void OnExit(GameManager gM)
    {
    }
}
