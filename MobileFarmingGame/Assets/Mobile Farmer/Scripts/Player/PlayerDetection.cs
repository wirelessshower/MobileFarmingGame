using UnityEngine;

public class PlayerDetection : MonoBehaviour {

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("ChunkTrigger"))
        {
            Chunk chunk = other.GetComponentInParent<Chunk>();
            chunk.TryUnlock();
        }
    }
}