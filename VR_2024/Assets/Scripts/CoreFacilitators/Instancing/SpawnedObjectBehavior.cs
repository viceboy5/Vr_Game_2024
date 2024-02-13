using UnityEngine;

public class SpawnedObjectBehavior : MonoBehaviour
{
    private SpawnedObjectData _spawnedObjectData;
    public float ammoRespawnTime;
    
    private void Awake()
    {
        _spawnedObjectData = ScriptableObject.CreateInstance<SpawnedObjectData>();
        if (GetComponent<SpawnManager>()) _spawnedObjectData.spawnManager = GetComponent<SpawnManager>();
    }
    
    public void SetSpawnManager(SpawnManager spawnManager) { _spawnedObjectData.spawnManager = spawnManager; }
    public SpawnManager GetSpawnManager() { return _spawnedObjectData.spawnManager; }
    
    public void SetSpawnPosition(Vector3 spawnPosition) { _spawnedObjectData.SetSpawnPosition(spawnPosition); }
    public Vector3 GetSpawnPosition() { return _spawnedObjectData.GetSpawnPosition(); }
    
    public void SetSpawnRotation(Quaternion spawnRotation) { _spawnedObjectData.SetSpawnRotation(spawnRotation); }
    public Quaternion GetSpawnRotation() { return _spawnedObjectData.GetSpawnRotation(); }

    public void TriggerRespawn()
    {
        _spawnedObjectData.spawnManager.StartSpawn(_spawnedObjectData.spawnManager.numToSpawn);
    }
    
    public void SetSpawnTime()
    {
        if (_spawnedObjectData.spawnManager.GetSpawnDelay() != ammoRespawnTime)
        {
            _spawnedObjectData.spawnManager.SetSpawnDelay(ammoRespawnTime);
        }
    }
}