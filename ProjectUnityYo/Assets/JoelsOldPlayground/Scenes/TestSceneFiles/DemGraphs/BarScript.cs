using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    #region PublicData
    public GameObject barType;
    [Range(0, 500)]
    public int amountOfBars;
    [Range(20, 500)]
    public float heightLimiter;
    public Text barsText, coroutineText;
    public Slider barAmountSlider;
    public Slider coroutineAmountSlider;
    #endregion

    #region PrivateData
    private List<GameObject> listOfBarHolders = new List<GameObject>();
    private List<Coroutine> listOfCoroutines = new List<Coroutine>();
    private float maxHeight;
    private Color barColor = new Color();
    private float cR, cG, cB;
    private int numOfCoroutines;

    private IEnumerator coroutine;

    #endregion

    #region Start
    // Use this for initialization
    void Start ()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        barAmountSlider.onValueChanged.AddListener      (delegate { ChangeBarAmount(); });
        coroutineAmountSlider.onValueChanged.AddListener(delegate { CoroutineUpdateValue(); });

        //heightLimiter = transform.parent.GetComponent<RectTransform>().sizeDelta.y;
        //maxHeight = maxHeight - (maxHeight / 10);

        //Create our initialized bars
        for (int i = 0; i < amountOfBars; i++)
        {
            CreateBars();
        }

        //StartCoroutine("RandomlyChangeBarSize");
        coroutine = WaitAndPrint(0.00001f);
        

    }
    #endregion

    #region Update
    // Update is called once per frame
    void Update ()
    {
        heightLimiter = Random.Range(20, 500);
        
        maxHeight = heightLimiter;

       // RandomlyChangeBarSize();

        if (listOfBarHolders.Count != 0)
        {
            if (amountOfBars < listOfBarHolders.Count)
            {
                while(amountOfBars < listOfBarHolders.Count)
                RemoveBars();
            }
            else if (amountOfBars > listOfBarHolders.Count)
            {
                while(amountOfBars > listOfBarHolders.Count)
                CreateBars();
            }

           // RandomlyChangeBarSize();

        }
        else if(amountOfBars > 0)
        {
            CreateBars();
        }

	}
    #endregion

    #region BarFunctions
    void CreateBars()
    {
        cR = Random.Range(0f, 1f);
        cG = Random.Range(0f, 1f);
        cB = Random.Range(0f, 1f);
        barColor = new Color(cR, cG, cB);

        listOfBarHolders.Add(Instantiate(barType));
        listOfBarHolders[listOfBarHolders.Count - 1].transform.SetParent(gameObject.transform);
        listOfBarHolders[listOfBarHolders.Count - 1].transform.GetChild(0).GetComponent<Image>().color = barColor;
    }

    void RemoveBars()
    {
        Destroy(listOfBarHolders[listOfBarHolders.Count - 1]);
        listOfBarHolders.RemoveAt(listOfBarHolders.Count - 1);
    }

    void RandomlyChangeBarSize()
    {
            RectTransform tempBarSize;
            //left/right padding (sort of). then height is setted.
            Vector2 sizeOfBar = new Vector2(0, Random.Range(0, maxHeight));
            //Get the bar from our barholder so we can modify its size values
            if (listOfBarHolders.Count != 0)
            {
                tempBarSize = listOfBarHolders[Random.Range(0, listOfBarHolders.Count)].transform.GetChild(0).GetComponentInChildren<RectTransform>();
                //Set the bars size
                tempBarSize.sizeDelta = sizeOfBar;
            }
    }
    #endregion

    #region Coroutine
    // every 2 seconds perform the print()
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            RandomlyChangeBarSize();
        }
    }
    #endregion

    #region SliderFunctions
    public void ChangeBarAmount()
    {
        amountOfBars = (int)barAmountSlider.value;
        barsText.text = amountOfBars.ToString();
    }

    public void CoroutineUpdateValue()
    {
        if (coroutineAmountSlider.value < listOfCoroutines.Count)
        {
            while (coroutineAmountSlider.value < listOfCoroutines.Count)
            {
                StopCoroutine(listOfCoroutines[listOfCoroutines.Count - 1]);
                listOfCoroutines.RemoveAt(listOfCoroutines.Count - 1);
            }
        }
        else if (coroutineAmountSlider.value > listOfCoroutines.Count)
        {
            while (coroutineAmountSlider.value > listOfCoroutines.Count)
            {
                listOfCoroutines.Add(StartCoroutine(coroutine));
            }
        }

        coroutineText.text = listOfCoroutines.Count.ToString();

    }
    #endregion
}
