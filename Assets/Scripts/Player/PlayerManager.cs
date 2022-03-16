using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public enum SpawnPositionLocation {
    StartPos = 1,
    Ocean = 2,

}

public class PlayerManager : MonoBehaviour
{
    [Header("Customization")] 
    [SerializeField] private SkinnedMeshRenderer _playerMesh;
    
    [SerializeField] private Material[] _materials;

    [SerializeField] private Transform _playerTransform;

    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _oceanPos;

    public void SetNewMaterial(Material chosenMaterial)
    {
        Debug.Log("called customization");
        _materials[1] = chosenMaterial;
        _playerMesh.sharedMaterials = _materials;
    }

    public void SetPlayerPosition(SpawnPositionLocation spawnPos) 
    {
        switch (spawnPos)
                {
                    case SpawnPositionLocation.StartPos:
                        _playerTransform.position = _startPos.position;
                        break;
                    case SpawnPositionLocation.Ocean:
                        _playerTransform.position = _oceanPos.position;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(spawnPos), spawnPos, null);
                }
        Debug.Log("move player");
    }
}
