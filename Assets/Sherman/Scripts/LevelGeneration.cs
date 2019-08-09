using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private const float CAMERA_DISTANCE_SPAWN_LEVEL_PART = 100f;
    [SerializeField] private Transform level_start;
    [SerializeField] private Transform level_1;
    [SerializeField] private Transform mainCamera;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = level_start.Find("EndPosition").position;
        int startLevelParts = 4;
        for (int i = 0; i < startLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(mainCamera.Find("CameraRightEnd").position, lastEndPosition) < CAMERA_DISTANCE_SPAWN_LEVEL_PART)
            SpawnLevelPart();
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(level_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

}
