using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class TrashGameController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image trashImage;
    public Sprite[] trashImages;
    public float gameDuration = 60f;

    private float elapsedTime = 0f;
    public bool gameIsActive = true;
    public TMP_Text timerText;

    private Vector3 startPosition;
    private Transform startParent;

    public string currentTrashType; // Store the type of the current trash

    private void Start()
    {
        elapsedTime = gameDuration;
        getTrashImage();
    }

    private void Update()
    {
        if (gameIsActive)
        {
            elapsedTime -= Time.deltaTime;

            if (elapsedTime <= 0f)
            {
                elapsedTime = 0f; // Ensure it doesn't go negative
                EndGame();
            }

            // Calculate minutes and seconds from the remaining time
            int minutes = (int)(elapsedTime / 60);
            int seconds = (int)(elapsedTime % 60);

            // Update the timer text
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void getTrashImage()
    {
        if (trashImages.Length > 0)
        {
            int randomIndex = Random.Range(0, trashImages.Length);
            trashImage.sprite = trashImages[randomIndex];

            // Determine trash type based on index
            if (randomIndex == 0 || randomIndex == 1)
            {
                currentTrashType = "Plastic";
            }
            else if (randomIndex == 2 || randomIndex == 3)
            {
                currentTrashType = "Glass";
            }
            else
            {
                currentTrashType = "Paper";
            }
        }
        else
        {
            Debug.LogError("No trash images in the array.");
        }
    }

    private void EndGame()
    {
        gameIsActive = false;
        Debug.Log("Time's up!");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!gameIsActive) return;

        startPosition = trashImage.transform.position;
        startParent = trashImage.transform.parent;
        trashImage.transform.SetParent(this.transform);
        trashImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!gameIsActive) return;

        trashImage.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!gameIsActive) return;

        trashImage.transform.position = startPosition;
        trashImage.transform.SetParent(startParent);
        trashImage.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Entrou ");
        if (!gameIsActive) return;

        // Check for collision with bins
        Collider2D hitCollider = Physics2D.OverlapPoint(trashImage.transform.position);
        if (hitCollider != null)
        {
            bool isCorrectBin = hitCollider.tag == currentTrashType;

            if (isCorrectBin)
            {
                Debug.Log("Dropped in the correct bin!");
                getTrashImage(); // Generate another trash item
            }
            else
            {
                Debug.Log("Dropped in the wrong bin!");
            }
        }
    }
}
