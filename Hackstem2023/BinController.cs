using UnityEngine;
using UnityEngine.EventSystems;

public class BinController : MonoBehaviour, IDropHandler
{
    public string binType; // Set this manually in the inspector for each bin (e.g., "Plastic", "Glass", "Paper")

    public TrashGameController trashGameController; // Drag and drop the game object with the TrashGameController script attached in the inspector

    public void OnDrop(PointerEventData eventData)
    {
        if (trashGameController && trashGameController.gameIsActive)
        {
            bool isCorrectBin = binType == trashGameController.currentTrashType;

            if (isCorrectBin)
            {
                Debug.Log("Dropped in the correct bin!");
                trashGameController.getTrashImage(); // Generate another trash item
            }
            else
            {
                Debug.Log("Dropped in the wrong bin!");
            }
        }
    }
}
