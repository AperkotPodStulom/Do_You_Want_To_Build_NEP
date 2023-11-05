using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Grid : MonoBehaviour
// {
//     [SerializeField] private float _sizeX, _sizeY;
//     
//     [HideInInspector] public static Dictionary<Vector2Int, GameObject> Cells = new Dictionary<Vector2Int, GameObject>();
//     [HideInInspector] public bool Generated { get; set; }
//
//     private void GenerateGrid()
//     {
//         for (float x = transform.position.x - (_sizeX / 2); x < transform.position.x + (_sizeX / 2 + 1); x++)
//         {
//             for (float y = transform.position.y + (_sizeY / 2); y > transform.position.y - (_sizeY / 2 + 1); y--)
//             {
//                 GameObject obj = new GameObject();
//                 obj.AddComponent<Cell>();
//                 obj.GetComponent<Cell>().Position = new Vector2Int((int)x, (int)y);
//                 obj.GetComponent<Cell>().IsOccupied = false;
//                 obj.GetComponent<Cell>().RegionSeed = null;
//                 obj.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Square");
//                 obj.AddComponent<BoxCollider2D>();
//                 obj.isStatic = true;
//                 Cells.Add(new Vector2Int((int)x, (int)y), obj);
//             }
//         }
//     }
//
//     private void Start()
//     {
//         GenerateGrid();
//         Generated = true;
//     }
//
//     public float GetSizeX
//     {
//         get { return _sizeX; }
//     }
//     
//     public float GetSizeY
//     {
//         get { return _sizeY; }
//     }
