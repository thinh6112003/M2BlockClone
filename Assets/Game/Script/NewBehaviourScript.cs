using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<bool[,]> visited = new List<bool[,]>();
    //public List<int>[,] matrixSolution= new List<int>[1,1];
    public int rows = 2, cols = 2;
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        
        for (int i = 0; i < 4; i++)
        {
            bool[,] t = new bool[cols, rows];
            visited.Add(t);
        }
        visited[0][0, 0] = true;

    }
}
