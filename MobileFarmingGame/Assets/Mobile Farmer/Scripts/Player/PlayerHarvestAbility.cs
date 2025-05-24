using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerHarvestAbility : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform harvestSphere;
    private PlayerAnimator playerAnimator;
    private PlayerToolSelector playerToolSelector;

    [Header("Settings")]
    private CropField currentCropField;
    private bool canHarvest;



    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerToolSelector = GetComponent<PlayerToolSelector>();

        //WaterParticles.onWaterColided += WaterCollidedCaback;
        CropField.onFullyHarvested += CropFieldFullyHarvestedCallback;
        PlayerToolSelector.onToolSelected += ToolSelectedCallback;

    }

    void OnDestroy()
    {
        //WaterParticles.onWaterColided -= WaterCollidedCaback;
        CropField.onFullyHarvested -= CropFieldFullyHarvestedCallback;
        PlayerToolSelector.onToolSelected -= ToolSelectedCallback;
    }


    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool)
    {
        if (!playerToolSelector.CanHarvest())
            playerAnimator.StopHarvestAnimation();
    }


    private void CropFieldFullyHarvestedCallback(CropField cropField)
    {
        if (currentCropField == cropField)
            playerAnimator.StopHarvestAnimation();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsWatered())
        {
            currentCropField = other.GetComponent<CropField>();
            EnterCropField(currentCropField);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsWatered())
            EnterCropField(other.GetComponent<CropField>());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            playerAnimator.StopHarvestAnimation();
            currentCropField = null;
        }
    }

    private void EnterCropField(CropField cropField)
    {
        if (playerToolSelector.CanHarvest())
        {
            if (currentCropField == null)
                currentCropField = cropField;

            playerAnimator.PlayHarvestAnimation();

            if (canHarvest)
                currentCropField.Harvest(harvestSphere);
        }
    }

    public void HarvestingStartedCallback()
    {
        canHarvest = true;
    }

    public void HarvestingStoppedCallback()
    {
        canHarvest = false;     
    }
   
}
