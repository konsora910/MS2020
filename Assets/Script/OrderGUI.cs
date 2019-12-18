using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderGUI : MonoBehaviour
{
    [Header("CuisineTexture")]
    public Sprite Omerice = null;
    public Sprite Soup = null;
    public Sprite Riceball = null;

    [Space(20)]
    public Order orderScript;
    public Image img;
    public GameObject InputOrderObj;
    private Sprite ord;
    private Sprite readSprite;
    private int num = 0;
    private int ArNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        orderScript = InputOrderObj.GetComponent<Order>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        num = orderScript.GetOrder(ArNum);

        switch (num)
        {
            case 3:
                readSprite = Omerice;
                break;
            case 4:
                readSprite = Soup;
                break;
            case 5:
                readSprite = Riceball;
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ord = readSprite;
            img.sprite = ord;
            ArNum++;
        }
    }

    public void OrderNext()
    {
        ord = readSprite;
        img.sprite = ord;
        ArNum++;
    }
}
