using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    [Header("Customization")] 
    [SerializeField] private SkinnedMeshRenderer _playerMesh;
    
    [SerializeField] private Material[] _materials;

    public void SetNewMaterial(Material chosenMaterial)
    {
        Debug.Log("called customization");
        _materials[1] = chosenMaterial;
        _playerMesh.sharedMaterials = _materials;
    }
}
