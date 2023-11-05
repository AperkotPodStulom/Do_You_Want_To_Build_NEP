using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RegionCreator : MonoBehaviour
{
    [SerializeField] private int numberOfRegions;
    
    private int _maxNumberOfCells;
    private bool _seedsCreated = false, _firstRegionCellsCreated = false, _isWorldCreated = false, _isWorldCleaned = false;
    private List<GameObject> seeds = new List<GameObject>();

    private Vector2Int[] CreateRegionSeeds()
    {
        Vector2 startPos =
            Grid.Cells[
                Vector2Int.zero - new Vector2Int((int)GameObject.Find("GridManager").GetComponent<Grid>().GetSizeX,
                    -(int)GameObject.Find("GridManager").GetComponent<Grid>().GetSizeY) / 2].transform.position;
        Vector2 endPos = Grid
            .Cells[
                Vector2Int.zero + new Vector2Int((int)GameObject.Find("GridManager").GetComponent<Grid>().GetSizeX,
                    -(int)GameObject.Find("GridManager").GetComponent<Grid>().GetSizeY) / 2].transform.position;

        Vector2Int[] seeds = new Vector2Int[numberOfRegions];

        for (int i = 0; i < seeds.Length; i++)
        {
            seeds[i] = GenerateSeed(startPos, endPos);
        }

        return seeds;
    }

    private Vector2Int GenerateSeed(Vector2 startPos, Vector2 endPos)
    {
        return new Vector2Int((int)Random.Range(startPos.x, endPos.x), (int)Random.Range(startPos.y, endPos.y));
    }

    private void Update()
    {
        if (!_seedsCreated)
        {
            List<Color> colors = new List<Color>() {Color.yellow, Color.blue, Color.green, Color.cyan, Color.magenta,
                Color.red};
            Vector2Int[] seeds = CreateRegionSeeds();
            foreach (var seed in seeds)
            {
                Grid.Cells[seed].GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)];
                colors.Remove(Grid.Cells[seed].GetComponent<SpriteRenderer>().color);
                Grid.Cells[seed].GetComponent<Cell>().IsOccupied = true;
                Grid.Cells[seed].GetComponent<Cell>().RegionSeed = Grid.Cells[seed];
                this.seeds.Add(Grid.Cells[seed]);
            }

            _seedsCreated = true;

            for (int i = 0; i < this.seeds.Count; i++)
            {
                var gobj = new GameObject();
                gobj.name = "region" + i.ToString();
                this.seeds[i].transform.parent = gobj.transform;
            }
        }

        if (_seedsCreated && !_firstRegionCellsCreated)
        {
            foreach (var seed in seeds)
            {
                Vector2Int up = new Vector2Int((int)seed.transform.position.x, (int)seed.transform.position.y + 1);
                Vector2Int upRight = new Vector2Int((int)seed.transform.position.x + 1, (int)seed.transform.position.y + 1);
                Vector2Int right = new Vector2Int((int)seed.transform.position.x + 1, (int)seed.transform.position.y);
                Vector2Int downRight = new Vector2Int((int)seed.transform.position.x + 1, (int)seed.transform.position.y - 1);
                Vector2Int down = new Vector2Int((int)seed.transform.position.x, (int)seed.transform.position.y - 1);
                Vector2Int downLeft = new Vector2Int((int)seed.transform.position.x - 1, (int)seed.transform.position.y - 1);
                Vector2Int left = new Vector2Int((int)seed.transform.position.x - 1, (int)seed.transform.position.y);
                Vector2Int upLeft = new Vector2Int((int)seed.transform.position.x - 1, (int)seed.transform.position.y + 1);

                if (MoveCheckPos(up))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + up;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
                if (MoveCheckPos(upLeft))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + upLeft;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
                if (MoveCheckPos(left))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + left;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
                if (MoveCheckPos(downLeft))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + downLeft;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
                if (MoveCheckPos(down))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + down;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
                if (MoveCheckPos(downRight))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + downRight;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
                if (MoveCheckPos(right))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + right;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
                if (MoveCheckPos(upRight))
                {
                    Vector2Int cellPos = new Vector2Int((int)transform.position.x, (int)transform.position.y) + upRight;
                    Grid.Cells[cellPos].GetComponent<Cell>().IsOccupied = true;
                    Grid.Cells[cellPos].GetComponent<SpriteRenderer>().color =
                        seed.GetComponent<SpriteRenderer>().color;
                    Grid.Cells[cellPos].GetComponent<Cell>().RegionSeed = seed;
                    Grid.Cells[cellPos].transform.parent = seed.transform.parent;
                }
            }

            _firstRegionCellsCreated = true;
        }

        if (!_isWorldCreated)
        {
            _maxNumberOfCells = Grid.Cells.Count / numberOfRegions;
            //Debug.Log(_maxNumberOfCells);
            
            foreach (var cell in Grid.Cells)
            {
                if (cell.Value.GetComponent<Cell>().IsOccupied)
                {
                    if (cell.Value.GetComponent<Cell>().RegionSeed.transform.parent.childCount < _maxNumberOfCells)
                    {
                        Vector2Int up = new Vector2Int((int)cell.Value.transform.position.x, (int)cell.Value.transform.position.y + 1);
                        Vector2Int upRight = new Vector2Int((int)cell.Value.transform.position.x + 1, (int)cell.Value.transform.position.y + 1);
                        Vector2Int right = new Vector2Int((int)cell.Value.transform.position.x + 1, (int)cell.Value.transform.position.y);
                        Vector2Int downRight = new Vector2Int((int)cell.Value.transform.position.x + 1, (int)cell.Value.transform.position.y - 1);
                        Vector2Int down = new Vector2Int((int)cell.Value.transform.position.x, (int)cell.Value.transform.position.y - 1);
                        Vector2Int downLeft = new Vector2Int((int)cell.Value.transform.position.x - 1, (int)cell.Value.transform.position.y - 1);
                        Vector2Int left = new Vector2Int((int)cell.Value.transform.position.x - 1, (int)cell.Value.transform.position.y);
                        Vector2Int upLeft = new Vector2Int((int)cell.Value.transform.position.x - 1, (int)cell.Value.transform.position.y + 1);

                        if (MoveCheckPos(up))
                        {
                            Vector2Int pos = up;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                            //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                        if (MoveCheckPos(upRight))
                        {
                            Vector2Int pos = upRight;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                            //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                        if (MoveCheckPos(right))
                        {
                            Vector2Int pos = right;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                            //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                        if (MoveCheckPos(downRight))
                        {
                            Vector2Int pos = downRight;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                            //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                        if (MoveCheckPos(down))
                        {
                            Vector2Int pos = down;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                           //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                        if (MoveCheckPos(downLeft))
                        {
                            Vector2Int pos = downLeft;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                            //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                        if (MoveCheckPos(left))
                        {
                            Vector2Int pos = left;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                            //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                        if (MoveCheckPos(upLeft))
                        {
                            Vector2Int pos = upLeft;
                            Grid.Cells[pos].GetComponent<Cell>().IsOccupied = true;
                            Grid.Cells[pos].GetComponent<Cell>().RegionSeed = cell.Value.GetComponent<Cell>().RegionSeed;
                            Grid.Cells[pos].GetComponent<SpriteRenderer>().color = cell.Value.GetComponent<Cell>()
                                .RegionSeed.GetComponent<SpriteRenderer>().color;
                            Grid.Cells[pos].transform.parent =
                                Grid.Cells[pos].GetComponent<Cell>().RegionSeed.transform.parent;
                            
                            //Debug.Log("Generated at " + pos.ToString() + " by " + cell.Value.transform.position.ToString());
                        }
                    }
                }
            }
            
            foreach (var cell in Grid.Cells)
            {
                if (!cell.Value.GetComponent<Cell>().IsOccupied)
                {
                    foreach (var seed in this.seeds)
                    {
                        if (seed.transform.parent.childCount < _maxNumberOfCells)
                        {
                            Debug.Log(_maxNumberOfCells.ToString() + " " + seed.transform.parent.childCount);
                            return;
                        }
                    }
                }
                    
            }
            
            _isWorldCreated = true;
            ClearWorld();
        }
    }

    private void ClearWorld()
    {
        foreach (var cell in Grid.Cells)
        {
            if (!cell.Value.GetComponent<Cell>().IsOccupied)
            {  
                Destroy(cell.Value);
                Debug.Log("Cleared");
            }
        }
    }

    private bool MoveCheckPos(Vector2Int direction)
    {
        try
        {
            var cell = Grid.Cells[direction];

            if (!cell.GetComponent<Cell>().IsOccupied)
                return true;
            else
                return false;
        }
        catch
        { 
            return false;
        }
    }
}
