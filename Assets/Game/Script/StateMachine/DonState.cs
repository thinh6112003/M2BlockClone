using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonState : IState
{
    bool checkalldendich;
    bool checkalldendich2;
    float timer ;
    public void OnEnter(GameManager gM)
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j=0;j< gM.quanLyBlock[i].Count; j++)
            {
                Block block= gM.quanLyBlock[i][j];
                int vty = (int)gM.goc.position.y- (int)block.transform.position.y;
                block.vitrichinhxac =  new Vector2(gM.goc.position.x +i,gM.goc.position.y -j);
                if (vty != j) 
                {
                    block.checkCandichuyen = true;
                }
                else block.checkCandichuyen = false;
            }
        }
        checkalldendich2 = false;
        timer = 0;
    }

    public void OnExecute(GameManager gM)
    {
        if(checkalldendich2)
        {
            if (timer > 0f)
            {
                gM.ChangeState(new GopState());
            }
            timer += Time.deltaTime;
        }
        else
        {
            checkalldendich = true;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < gM.quanLyBlock[i].Count; j++)
                {
                    Block block = gM.quanLyBlock[i][j];
                    if (block.checkCandichuyen)
                    {
                        block.transform.position = Vector2.MoveTowards(block.transform.position, block.vitrichinhxac, 0.3f * gM.buocNhay*Time.deltaTime);
                        if (block.vitrichinhxac.y - block.transform.position.y < 0.01)
                        {
                            block.transform.position = block.vitrichinhxac;
                            block.checkCandichuyen = false;
                        }
                        checkalldendich = false;
                    }
                }
            }
            if (checkalldendich == true)
            {
                checkalldendich2 = true;
            }
        }
    }

    public void OnExit(GameManager gM)
    {
    }
}
