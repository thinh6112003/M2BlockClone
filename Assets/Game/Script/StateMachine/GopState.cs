using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GopState : IState
{
    public bool check= false;
    public float timer;
    public void OnEnter(GameManager gM)
    {

        void Check(Vector2 toado)
        {
            Block block=  gM.quanLyBlock[(int)toado.x][(int)toado.y];
            block.checkDuyet = false;
            block.checkXoa = false;
            block.dem = 0;
            block.cophai = false;
            block.cotrai = false;
            block.cotren = false;
            if (toado.y > 0)
            {
                if (gM.quanLyNumber[(int)toado.x][(int)toado.y - 1] ==
                    gM.quanLyNumber[(int)toado.x][(int)toado.y])
                {
                    block.cotren = true;
                    gM.quanLyBlock[(int)toado.x][(int)toado.y].dem++;
                }
            }
            if ((int)toado.x != 4 && gM.quanLyNumber[(int)toado.x + 1].Count > (int)toado.y)
            {
                if (gM.quanLyNumber[(int)toado.x + 1][(int)toado.y] ==
                    gM.quanLyNumber[(int)toado.x][(int)toado.y])
                {
                    block.cophai = true;
                    gM.quanLyBlock[(int)toado.x][(int)toado.y].dem++;
                }
            }
            if ((int)toado.x != 0 && gM.quanLyNumber[(int)toado.x - 1].Count > (int)toado.y)
            {
                if (gM.quanLyNumber[(int)toado.x - 1][(int)toado.y] ==
                    gM.quanLyNumber[(int)toado.x][(int)toado.y])
                {
                    block.cotrai = true;
                    gM.quanLyBlock[(int)toado.x][(int)toado.y].dem++;
                }
            }
        }
        gM.currentEnumState = State.GOP;
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < gM.quanLyNumber[i].Count; j++)
            {
                Check(new Vector2(i, j));
                if (gM.quanLyBlock[i][j].dem > 0) check = true;
            }
        }
        if (check == false)
        {
            gM.ChangeState(new ChoBanState());
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < gM.quanLyNumber[i].Count; j++)
            {
                Block block = gM.quanLyBlock[i][j];
                if (block.dem == 3)
                {
                    block.checkDuyet = true;
                    if (j > 0)
                    {
                        gM.quanLyBlock[i][j - 1].checkDuyet = true;
                        gM.quanLyBlock[i][j - 1].checkXoa = true;
                        gM.quanLyBlock[i][j - 1].huonggop = Huonggop.tren;
                        gM.quanLyBlock[i][j - 1].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }
                    if (i != 4 && gM.quanLyNumber[i + 1].Count > j)
                    {
                        gM.quanLyBlock[i + 1][j].checkDuyet = true;
                        gM.quanLyBlock[i + 1][j].checkXoa = true;
                        gM.quanLyBlock[i + 1][j].huonggop = Huonggop.trai;
                        gM.quanLyBlock[i + 1][j].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }
                    if (i != 0 && gM.quanLyNumber[i - 1].Count > j)
                    {
                        gM.quanLyBlock[i - 1][j].checkDuyet = true;
                        gM.quanLyBlock[i - 1][j].checkXoa = true;
                        gM.quanLyBlock[i - 1][j].huonggop = Huonggop.phai;
                        gM.quanLyBlock[i - 1][j].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }

                }
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < gM.quanLyNumber[i].Count; j++)
            {
                Block block = gM.quanLyBlock[i][j];
                if (block.dem == 2 && block.checkDuyet == false)
                {
                    block.checkDuyet = true;
                    if (j > 0 && block.cotren)
                    {
                        gM.quanLyBlock[i][j - 1].checkDuyet = true;
                        gM.quanLyBlock[i][j - 1].checkXoa = true;
                        gM.quanLyBlock[i][j - 1].huonggop = Huonggop.tren;
                        gM.quanLyBlock[i][j - 1].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }
                    if (i != 4 && gM.quanLyNumber[i + 1].Count > j && block.cophai)
                    {
                        gM.quanLyBlock[i + 1][j].checkDuyet = true;
                        gM.quanLyBlock[i + 1][j].checkXoa = true;
                        gM.quanLyBlock[i + 1][j].huonggop = Huonggop.trai;
                        gM.quanLyBlock[i + 1][j].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }
                    if (i != 0 && gM.quanLyNumber[i - 1].Count > j && block.cotrai)
                    {
                        gM.quanLyBlock[i - 1][j].checkDuyet = true;
                        gM.quanLyBlock[i - 1][j].checkXoa = true;
                        gM.quanLyBlock[i - 1][j].huonggop = Huonggop.phai;
                        gM.quanLyBlock[i - 1][j].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }

                }
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < gM.quanLyNumber[i].Count; j++)
            {
                Block block = gM.quanLyBlock[i][j];
                if (block.dem == 1 && block.checkDuyet == false)
                {
                    block.checkDuyet = true;
                    if (j > 0 && block.cotren)
                    {
                        gM.quanLyBlock[i][j - 1].checkDuyet = true;
                        gM.quanLyBlock[i][j - 1].checkXoa = true;
                        gM.quanLyBlock[i][j - 1].huonggop = Huonggop.tren;
                        gM.quanLyBlock[i][j - 1].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }
                    if (i != 4 && gM.quanLyNumber[i + 1].Count > j && block.cophai)
                    {
                        gM.quanLyBlock[i + 1][j].checkDuyet = true;
                        gM.quanLyBlock[i + 1][j].checkXoa = true;
                        gM.quanLyBlock[i + 1][j].huonggop = Huonggop.trai;
                        gM.quanLyBlock[i + 1][j].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }
                    if (i != 0 && gM.quanLyNumber[i - 1].Count > j && block.cotrai)
                    {
                        gM.quanLyBlock[i - 1][j].checkDuyet = true;
                        gM.quanLyBlock[i - 1][j].checkXoa = true;
                        gM.quanLyBlock[i - 1][j].huonggop = Huonggop.phai;
                        gM.quanLyBlock[i - 1][j].maugop = block.gameObject.GetComponent<SpriteRenderer>().color;
                    }

                }
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = gM.quanLyBlock[i].Count - 1; j >= 0; j--)
            {
                Block block = gM.quanLyBlock[i][j];
                if (block.checkXoa)
                {
                    gM.DestroyBlock(i, j);
                    gM.KhoitaoMerge(block.huonggop, block.transform.position,block.maugop );
                }
                else
                {
                    if (block.checkDuyet)
                    {
                        gM.quanLyNumber[i][j] += block.dem;
                        block.haimu += block.dem;
                        gM.StartCoroutine(updateBlock(block,gM));
                        gM.diem += gM.numberSO.listNumber[block.haimu].number;
                        UIManager.Instance.UpdateDiem();
                    }
                }
            }
        }
        timer = 0;
    }
    public void OnExecute(GameManager gM)
    {
        timer += Time.deltaTime;
        if (timer > 0.6f) gM.ChangeState(new DonState());
    }

    public void OnExit(GameManager gM)
    {
    }
    IEnumerator updateBlock( Block block, GameManager gM)
    {
        yield return new WaitForSeconds(0.3f);
        GameManager.Instance.updateBlock(block);
    }
}
public enum Huonggop
{
    trai,
    phai,
    tren,
}
