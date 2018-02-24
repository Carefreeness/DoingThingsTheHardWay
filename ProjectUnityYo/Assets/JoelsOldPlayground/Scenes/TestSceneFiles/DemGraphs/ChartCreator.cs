using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChartCreator : MonoBehaviour {

    public Slider chartSlider;
    public GameObject chartHolder;

    private List<GameObject> listOfCharts = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        chartSlider.onValueChanged.AddListener(delegate { UpdateAmountOfCharts(); });
    }

    void UpdateAmountOfCharts()
    {
        if(chartSlider.value > listOfCharts.Count)
        {
            while (chartSlider.value > listOfCharts.Count)
            {
                listOfCharts.Add(Instantiate(chartHolder));
                listOfCharts[listOfCharts.Count - 1].transform.SetParent(gameObject.transform);
            }
        }
        else if (chartSlider.value < listOfCharts.Count && listOfCharts.Count != 0)
        {
            while (chartSlider.value < listOfCharts.Count)
            {
                Destroy(listOfCharts[listOfCharts.Count - 1]);
                listOfCharts.RemoveAt(listOfCharts.Count - 1);
            }
        }
    }
}
