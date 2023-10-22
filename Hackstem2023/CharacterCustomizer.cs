using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizer : MonoBehaviour
{
    // UI RawImages for displaying character parts
    public Image headImage;
    public Image hatImage;
    public Image shirtImage;
    public Image pantsImage;

    // Sprite Arrays for each character part
    public Sprite[] headSprites;
    public Sprite[] hatSprites;
    public Sprite[] shirtSprites;
    public Sprite[] pantsSprites;

    private int headIndex = 0;
    private int hatIndex = 0;
    private int shirtIndex = 0;
    private int pantsIndex = 0;

    private void Start()
    {
        LoadCharacterCustomization();
        ApplyCharacterCustomization();
    }

    private void OnEnable()
    {
        LoadCharacterCustomization();
        ApplyCharacterCustomization();
    }

    public void Changehead(int direction)
    {
        headIndex += direction;
        if (headIndex < 0) headIndex = headSprites.Length - 1;
        if (headIndex >= headSprites.Length) headIndex = 0;
        headImage.sprite = headSprites[headIndex];
    }

    public void Changehat(int direction)
    {
        hatIndex += direction;
        if (hatIndex < 0) hatIndex = hatSprites.Length - 1;
        if (hatIndex >= hatSprites.Length) hatIndex = 0;
        hatImage.sprite = hatSprites[hatIndex];
        Debug.Log("Changed hat to index: " + hatIndex);
    }

    public void Changeshirt(int direction)
    {
        shirtIndex += direction;
        if (shirtIndex < 0) shirtIndex = shirtSprites.Length - 1;
        if (shirtIndex >= shirtSprites.Length) shirtIndex = 0;
        shirtImage.sprite = shirtSprites[shirtIndex];
    }

    public void Changepants(int direction)
    {
        pantsIndex += direction;
        if (pantsIndex < 0) pantsIndex = pantsSprites.Length - 1;
        if (pantsIndex >= pantsSprites.Length) pantsIndex = 0;
        pantsImage.sprite = pantsSprites[pantsIndex];
    }

    public void SaveCharacterCustomization()
    {
        PlayerPrefs.SetInt("HeadIndex", headIndex);
        PlayerPrefs.SetInt("HatIndex", hatIndex);
        PlayerPrefs.SetInt("ShirtIndex", shirtIndex);
        PlayerPrefs.SetInt("PantsIndex", pantsIndex);
    }

    private void LoadCharacterCustomization()
    {
        headIndex = PlayerPrefs.GetInt("HeadIndex", 0);
        hatIndex = PlayerPrefs.GetInt("HatIndex", 0);
        shirtIndex = PlayerPrefs.GetInt("ShirtIndex", 0);
        pantsIndex = PlayerPrefs.GetInt("PantsIndex", 0);
    }

    private void ApplyCharacterCustomization()
    {
        headImage.sprite = headSprites[headIndex];
        hatImage.sprite = hatSprites[hatIndex];
        shirtImage.sprite = shirtSprites[shirtIndex];
        pantsImage.sprite = pantsSprites[pantsIndex];
    }
}
