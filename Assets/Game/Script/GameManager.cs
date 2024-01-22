using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public int diem=0;
    public Transform goc;
    public NumberSO numberSO;
    public Block block;
    public Block blockDangChay;
    public Block currentBlock;
    public Block nextBlock;
    public float buocNhay;
    public Vector2 vitriDen;
    public Vector2 vitriBan;
    public Vector2 toadoVitriDen;
    public IState currentState;
    public State currentEnumState;
    public int currentNumber;
    public int nextNumber;
    public int maxnumber;
    public List<int>[] quanLyNumber = new List<int>[5];
    public List<Block>[] quanLyBlock = new List<Block>[5];
    public Merge merge;
    private void Awake()
    {
        //tranh viec nguoi choi cham da diem vao man hinh
        Input.multiTouchEnabled = false;
        //target frame rate ve 60 fps
        Application.targetFrameRate = 60;
        //tranh viec tat man hinh
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //xu tai tho
        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            quanLyNumber[i] = new List<int>();
            quanLyBlock[i] = new List<Block>();
        }
        ChangeState(new ChoBanState());
        nextNumber = Random.Range(0, maxnumber);
        updateXemTruoc();
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public void KhoitaoMerge(Huonggop huonggop, Vector2 vitri, Color color)
    {
        Merge mergetmp =Instantiate(merge);
        mergetmp.transform.position = vitri;
        mergetmp.sR.color = color;
        switch(huonggop)
        {
            case Huonggop.phai:
                mergetmp.transform.rotation = Quaternion.Euler(new  Vector3(0, 0, -90));
                break;
            case Huonggop.trai:
                mergetmp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case Huonggop.tren:
                mergetmp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
        }
    }
    public void updateXemTruoc()
    {
        nextBlock.number.text = numberSO.listNumber[nextNumber].number.ToString();
        nextBlock.gameObject.GetComponent<SpriteRenderer>().color = numberSO.listNumber[nextNumber].color;
        currentBlock.number.text = numberSO.listNumber[currentNumber].number.ToString();
        currentBlock.gameObject.GetComponent<SpriteRenderer>().color = numberSO.listNumber[currentNumber].color;
    }
    public void updateBlock(Block block)
    {
        block.number.text = numberSO.listNumber[block.haimu].number.ToString();
        block.gameObject.GetComponent<SpriteRenderer>().color = numberSO.listNumber[block.haimu].color;
    }
    public void ban(int i)
    {
        if (currentEnumState == State.CHOBAN)
        {
            vitriBan = (Vector2)goc.position + new Vector2((float)i - 1, -7);
            RaycastHit2D hit = Physics2D.Raycast(vitriBan, Vector2.up);
            int vitriY = 0;
            if (hit.collider.transform.position.y > 4)
            {
                vitriY = 0;
            }
            else
            {
                vitriY = (int)(goc.position.y - hit.collider.transform.position.y) + 1;
            }
            vitriDen = (Vector2)goc.position + new Vector2((float)i - 1, -vitriY);
            toadoVitriDen =  (Vector2)goc.position-vitriDen;
            toadoVitriDen.x = -toadoVitriDen.x;
            quanLyNumber[i-1].Add(currentNumber);
            ChangeState(new BanState());
            quanLyBlock[i-1].Add(blockDangChay);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void KhoiTao()
    {
        blockDangChay = Instantiate(block);
        blockDangChay.number.text = numberSO.listNumber[currentNumber].number.ToString();
        blockDangChay.gameObject.GetComponent<SpriteRenderer>().color = numberSO.listNumber[currentNumber].color;
        blockDangChay.haimu = currentNumber;
    }
    public void DestroyBlock(int i ,int j)
    {
        Block block = quanLyBlock[i][j];
        quanLyNumber[i].RemoveAt(j);
        quanLyBlock[i].RemoveAt(j);
        Destroy(block.gameObject);

    }
}
public enum State
{
    CHOBAN,
    BAN,
    GOP,
}
