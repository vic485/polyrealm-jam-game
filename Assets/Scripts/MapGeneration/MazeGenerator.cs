using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class MazeGenerator : MonoBehaviour
{

    struct Cell
    {
        public bool visited;
        public bool left;
        public bool right;
        public bool up;
        public bool bottom;
    };

    public GameObject roomPrefab;

    private Vector2 curPos;

    [SerializeField] const int mazeX = 16;
    [SerializeField] const int mazeY = 16;

    private bool done;

    public int roomSizeX;
    public int roomSizeY;

    private Cell[,] cells = new Cell[mazeX, mazeY];
    private List<Vector2> cellLog = new List<Vector2>();

    Vector2 getNeighbours(Vector2 pos)
    {
        List<Vector2> n = new List<Vector2>();

        if (pos.x > 0f)
        {
            if (cells[(int)pos.x - 1, (int)pos.y].visited == false)
            {
                n.Add(new Vector2(pos.x - 1f, pos.y));
            }
        }

        if (pos.x < (float)mazeX - 1f)
        {
            if (cells[(int)pos.x + 1, (int)pos.y].visited == false)
            {
                n.Add(new Vector2(pos.x + 1f, pos.y));
            }
        }

        if (pos.y > 0f)
        {
            if (cells[(int)pos.x, (int)pos.y - 1].visited == false)
            {
                n.Add(new Vector2(pos.x, pos.y - 1f));
            }
        }

        if (pos.y < (float)mazeY - 1f)
        {
            if (cells[(int)pos.x, (int)pos.y + 1].visited == false)
            {
                n.Add(new Vector2(pos.x, pos.y + 1f));
            }
        }

        int r = Random.Range(0, n.Count);

        if (n.Count > 0)
        {
            return n[r];
        }

        return new Vector2(-1f, -1f); //In Lua I just returned nil, but seeing as this is statically typed, I can't return null, so I'll use an impossible value
    }

    void MazeStep()
    {
        Vector2 nextPos = getNeighbours(curPos);
        if (nextPos.x != -1f && nextPos.y != -1f) //See comment at the last return in getNeighbours()
        {
            if (cells[(int)nextPos.x, (int)nextPos.y].visited == false)
            {
                cells[(int)nextPos.x, (int)nextPos.y].visited = true;
                cellLog.Add(nextPos);

                if (curPos.x < nextPos.x)
                {
                    cells[(int)curPos.x, (int)curPos.y].right = false;
                    cells[(int)nextPos.x, (int)nextPos.y].left = false;
                }
                else if (curPos.x > nextPos.x)
                {
                    cells[(int)curPos.x, (int)curPos.y].left = false;
                    cells[(int)nextPos.x, (int)nextPos.y].right = false;
                }
                else if (curPos.y < nextPos.y)
                {
                    cells[(int)curPos.x, (int)curPos.y].bottom = false;
                    cells[(int)nextPos.x, (int)nextPos.y].up = false;
                }
                else if (curPos.y > nextPos.y)
                {
                    cells[(int)curPos.x, (int)curPos.y].up = false;
                    cells[(int)nextPos.x, (int)nextPos.y].bottom = false;
                }

                curPos = nextPos;
            }
        }
        else if (cellLog.Count > 0)
        {
            curPos = cellLog[cellLog.Count - 1];
            cellLog.RemoveAt(cellLog.Count - 1);
        }
        else
        {
            done = true;
        }
    }

    void InstantiateMaze()
    {
        for (int x = 0; x < mazeX; x++)
        {
            for (int y = 0; y < mazeY; y++)
            {
                GameObject go = Instantiate(roomPrefab, new Vector3((float)(x * roomSizeX), 0.0f, (float)(y * roomSizeY)), Quaternion.identity);

                RoomPrefab rpcomp = go.GetComponent<RoomPrefab>();
                if (cells[x, y].left == false)
                    rpcomp.wall_left.SetActive(false);
                if (cells[x, y].right == false)
                    rpcomp.wall_right.SetActive(false);
                if (cells[x, y].bottom == false)
                    rpcomp.wall_up.SetActive(false);
                if (cells[x, y].up == false)
                    rpcomp.wall_bottom.SetActive(false);
            }
        }
    }

    void Start()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        cells[0, 0].visited = true;
        for (int x = 0; x < mazeX; x++)
        {
            for (int y = 0; y < mazeY; y++)
            {
                cells[x, y].left = true;
                cells[x, y].right = true;
                cells[x, y].up = true;
                cells[x, y].bottom = true;
            }
        }

        while (!done)
        {
            MazeStep();
        }

        InstantiateMaze();

        sw.Stop();
        print("Time elapsed: " + sw.ElapsedMilliseconds.ToString() + "MS");
    }
}