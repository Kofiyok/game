using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 currentPosition;
    private Tuple<int, int> startPosition;
    private Tuple<int, int>[] targetPositions = new Tuple<int, int>[7];
    private Queue<Tuple<int, int>> enemyPath = new Queue<Tuple<int, int>>();
    public EnemyData enemyData;
    public float health;

    void Start()
    {
        health = enemyData.HP;
        currentPosition = transform.position;
        startPosition = new Tuple<int, int>((int)currentPosition.x, (int)currentPosition.z);
        for (int i = 0; i < targetPositions.Length; i++)
        {
            targetPositions[i] = new Tuple<int, int>((int)currentPosition.x, 7);
        }
        AddCellsPath();
    }

    private void Update()
    {
        if (health <= 0)
        {
            MissionController.cripsCount--;
            Destroy(gameObject);
        }
        enemyMovement();
    }

    private void enemyMovement()
    {
        if (!IsHeroOnPath())
        {
            if (enemyPath.Count > 0)
            {
                Vector3 target = new Vector3(enemyPath.Peek().Item1, 1, enemyPath.Peek().Item2);
                Vector3 direction = target - transform.position;

                if (direction.magnitude < enemyData.speed * Time.deltaTime)
                {
                    transform.position = target;
                    enemyPath.Dequeue();
                }
                else
                {
                    transform.position += direction.normalized * enemyData.speed * Time.deltaTime;
                }
            }
        }
        
    }

    public List<Tuple<int, int>> FindExit()
    {
        Queue<Tuple<int, int>> cells = new Queue<Tuple<int, int>>(); 
        bool[,] visitedCells = new bool[MazeManager.mapArray.GetLength(0), MazeManager.mapArray.GetLength(1)];
        var pathTo = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
        cells.Enqueue(startPosition);
        Tuple<int, int> indexNeighbour = new Tuple<int, int>(0, 0);
        visitedCells[startPosition.Item1, startPosition.Item2] = true;

        while (cells.Count > 0)
        {
            var current = cells.Dequeue();
            foreach (var targetPosition in targetPositions)
            {
                if (current.Equals(targetPosition))
                {
                    var path = new List<Tuple<int, int>>();
                    while (current != null)
                    {
                        path.Add(current);
                        pathTo.TryGetValue(current, out current);
                    }
                    path.Reverse();
                    return path;
                }
            }
            foreach (var neighbour in GetNeighbours(current))
            {
                for (int i = 0; i < MazeManager.mapArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MazeManager.mapArray.GetLength(1); j++)
                    {
                        if (neighbour.Item1 == i && neighbour.Item2 == j)
                        {
                            indexNeighbour = new Tuple<int, int>(i, j);
                        }
                    }
                }
                if (!visitedCells[indexNeighbour.Item1, indexNeighbour.Item2])
                {
                    cells.Enqueue(neighbour);
                    visitedCells[indexNeighbour.Item1, indexNeighbour.Item2] = true;
                    pathTo[neighbour] = current;
                }
            }
        }
        return null;
    }

    private IEnumerable<Tuple<int, int>> GetNeighbours(Tuple<int, int> cell)
    {
        var moves = new List<Tuple<int, int>> {
        new Tuple<int, int>(0, 1),
        new Tuple<int, int>(1, 0),
        new Tuple<int, int>(-1, 0),
        new Tuple<int, int>(0, -1),};

        foreach (var move in moves)
        {
            var indexRow = cell.Item1 + move.Item1;
            var indexCol = cell.Item2 + move.Item2;
            if (indexRow >= 0 && indexRow < MazeManager.mapArray.GetLength(0) &&
                indexCol >= 0 && indexCol < MazeManager.mapArray.GetLength(1) &&
                MazeManager.mapArray[indexRow, indexCol] <= 0 && (enemyData.typeEnemy == 0 || enemyData.typeEnemy == 1))
            {
                yield return new Tuple<int, int>(indexRow, indexCol);
            }
            else if (indexRow >= 0 && indexRow < MazeManager.mapArray.GetLength(0) &&
                indexCol >= 0 && indexCol < MazeManager.mapArray.GetLength(1) && enemyData.typeEnemy == 2)
            {
                yield return new Tuple<int, int>(indexRow, indexCol);
            }
        }
    }

    private void AddCellsPath()
    {
        foreach (var cell in FindExit())
        {
            int width = cell.Item2;
            int height = cell.Item1;
            Tuple<int, int> tupleCell = new Tuple<int, int>(height, width);
            enemyPath.Enqueue(tupleCell);
        }
    }

    private bool IsHeroOnPath()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, .5f))
        {
            if (hit.collider.CompareTag("Hero"))
            {
                return true;
            }
            if (hit.collider.CompareTag("ProtectWall"))
            {
                return true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.forward * .5f, Color.red);

        return false;
    }
}

