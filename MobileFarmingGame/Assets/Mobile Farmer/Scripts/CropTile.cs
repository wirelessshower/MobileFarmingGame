using UnityEngine;

public enum TileFieldState{Empty, Sown, Watered}

public class CropTile : MonoBehaviour
{
    private TileFieldState state;

    [Header("Elements")]
    [SerializeField] private Transform cropParent;
    
    void Start()
    {
        state = TileFieldState.Empty;
    }

    public void Sow(CropData cropData){
        state = TileFieldState.Sown;
        Crop crop = Instantiate(cropData.cropPrefub, transform.position, Quaternion.identity, cropParent);

    }

   

    public bool IsEmpty(){        
         return state == TileFieldState.Empty;
    }
}
