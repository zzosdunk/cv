using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class WaterLocation : MonoBehaviour
{
    [SerializeField] private float _waterDeathTime;

    private float currentTimeStomp;

    private bool _isInWater;

    [SerializeField] private SharkBehaviour _sharkBehaviour;
    
    private void Awake() {
        _isInWater = false;
    }

    private void Update() {
        if (_isInWater) {
            if (Time.time - currentTimeStomp > _waterDeathTime) 
            {
                _isInWater = false;
                GameManager.Instance.UIManager.DynamicUiBehaviour.ResetPlayer(SpawnPositionLocation.Ocean);
                return;
            }
            else {
                Debug.Log("be careful");
            }
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        currentTimeStomp = Time.time;
        _isInWater = true;
        
        _sharkBehaviour.SharkState(_isInWater);
        Debug.Log("water entered");
    }

    private void OnTriggerExit(Collider other) 
    {
        _isInWater = false;
        
        _sharkBehaviour.SharkState(_isInWater);
        Debug.Log("water exit");
    }
}
