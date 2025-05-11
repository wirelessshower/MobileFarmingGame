using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerSowAbility : MonoBehaviour
{
    [Header("Elements")]
    private PlayerAnimator playerAnimator;
    private PlayerToolSelector playerToolSelector;    

    [Header("Settings")]
    private CropField currentCropField;


    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerToolSelector = GetComponent<PlayerToolSelector>();

        SeedParticles.onSeedsColided += SeedsCollidedCallBack;
        CropField.onFieldFullySown += CropFieldFullySownCallBack;
        PlayerToolSelector.onToolSelected += ToolSelectedCallBack;

    }    

    void OnDestroy()
    {
        SeedParticles.onSeedsColided -= SeedsCollidedCallBack;        
        CropField.onFieldFullySown -= CropFieldFullySownCallBack;
        PlayerToolSelector.onToolSelected -= ToolSelectedCallBack;
    }


    private void ToolSelectedCallBack(PlayerToolSelector.Tool selectedTool)
    {
        if(!playerToolSelector.CanSow())
            playerAnimator.StopSowAnimation();
    }

    private void SeedsCollidedCallBack(Vector3[] seedPositions)
    {
        if(currentCropField == null)
            return;

        currentCropField.SeedsCollidedCallBack(seedPositions);
    }

    private void CropFieldFullySownCallBack(CropField cropField)
    {
        if(currentCropField == cropField)
            playerAnimator.StopSowAnimation();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty() ){
            currentCropField = other.GetComponent<CropField>();
            EnterCropField(currentCropField);
            
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("CropField")){
            currentCropField = other.GetComponent<CropField>();
            EnterCropField(currentCropField);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField")){
            playerAnimator.StopSowAnimation();
            currentCropField = null;
        }
    }

    private void EnterCropField(CropField cropField)
    {        
        if(playerToolSelector.CanSow())
            playerAnimator.PlaySowAnimation();
    }
   
}
