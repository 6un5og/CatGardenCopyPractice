using UnityEngine;
using UnityEngine.UI;

public class SelectSlot : MonoBehaviour
{
    public static SelectSlot instance;

    public MainGameUI selectSlot;

    [SerializeField]
    private Image selectImage;

    void Start()
    {
        selectImage = transform.GetComponent<Image>();
    }

    public void SetSelectSlot(Image image)
    {
        selectImage = image;
        SetColor(1);
    }

    public void SetColor(float alpha)
    {
        Color color = selectImage.color;
        color.a = alpha;
        selectImage.color = color;
    }
}
