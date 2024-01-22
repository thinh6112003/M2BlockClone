using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button button4;
    [SerializeField] private Button button5;
    [SerializeField] private TextMeshProUGUI diemTMP;
    private void Awake()
    {
        UpdateDiem();
        button1.onClick.AddListener(ban1);
        button2.onClick.AddListener(ban2);
        button3.onClick.AddListener(ban3);
        button4.onClick.AddListener(ban4);
        button5.onClick.AddListener(ban5);
    }
    private void ban1()
    {
        GameManager.Instance.ban(1);
    }
    private void ban2()
    {
        GameManager.Instance.ban(2);
    }
    private void ban3()
    {
        GameManager.Instance.ban(3);
    }
    private void ban4()
    {
        GameManager.Instance.ban(4);
    }
    private void ban5()
    {
        GameManager.Instance.ban(5);
    }
    public void UpdateDiem()
    {
        diemTMP.text = GameManager.Instance.diem.ToString();
    }
}
