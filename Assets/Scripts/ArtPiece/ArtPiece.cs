using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject currentArt;

    public void ChangePieace(GameObject piece)
    {
        if (currentArt != null)
        {
            Destroy(currentArt);
            
        }

        currentArt = Instantiate(piece, transform);
        currentArt.transform.localPosition = Vector3.zero;
    }
}
