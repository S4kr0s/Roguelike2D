using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefabPlacer : MonoBehaviour
{
    private void Awake()
    {
        AbstractDungeonGenerator.OnDungeonGenerationComplete += OnDungeonGenerationComplete;
    }

    private void OnDungeonGenerationComplete()
    {
        throw new System.NotImplementedException();
    }
}
