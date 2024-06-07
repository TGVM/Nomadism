using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraManager : MonoBehaviour
{
    SaveFile saveFile;
    [SerializeField] int minimapLevel;
    [SerializeField] bool isActive = false;
    Camera camera;

    private void Awake()
    {
        saveFile = SaveManager.Instance.LoadFromJson();
        minimapLevel = saveFile.upgradesList[6].currentLevel;
        camera = GetComponent<Camera>();
    }

    private void Start()
    {
        ActivateLayers();
    }


    void ActivateLayers()
    {
        if(minimapLevel > 0)
        {
            isActive = true;
            camera.cullingMask |= 1 << LayerMask.NameToLayer("Ground");
            camera.cullingMask |= 1 << LayerMask.NameToLayer("PlayerMiniMap");
        }
        if(minimapLevel > 1)
        {
            camera.cullingMask |= 1 << LayerMask.NameToLayer("ObjectsMiniMap");
        }
        if(minimapLevel > 2)
        {
            camera.cullingMask |= 1 << LayerMask.NameToLayer("EnemyMiniMap");
        }

    }

    public bool IsActive()
    {
        return isActive;
    }
}
