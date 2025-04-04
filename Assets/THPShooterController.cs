using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class THPShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;

    private StarterAssetsInputs starterAssetsinput;

    // Start is called before the first frame update
    void Start()
    {
        starterAssetsinput = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsinput.aim) 
        {
            aimVirtualCamera.gameObject.SetActive(true);
        }
        else {
            aimVirtualCamera.gameObject.SetActive(false);
        }
    }
}
