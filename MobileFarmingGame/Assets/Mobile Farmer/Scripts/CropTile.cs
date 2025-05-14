using UnityEngine;

public enum TileFieldState{Empty, Sown, Watered}

public class CropTile : MonoBehaviour
{
    private TileFieldState state;

    [Header("Elements")]
    [SerializeField] private Transform cropParent;
    [SerializeField] private MeshRenderer tileRenderer;
    private Crop crop;
    
    void Start()
    {
        state = TileFieldState.Empty;
    }

    public void Sow(CropData cropData){
        state = TileFieldState.Sown;
        crop = Instantiate(cropData.cropPrefub, transform.position, Quaternion.identity, cropParent);

    }

   public void Water(){
       state = TileFieldState.Watered;
       tileRenderer.material.color = Color.white * .3f;

       crop.ScaleUp();
   }

    public bool IsEmpty(){        
         return state == TileFieldState.Empty;
    }

    public bool IsSown(){
        return state == TileFieldState.Sown;    
    }
}
