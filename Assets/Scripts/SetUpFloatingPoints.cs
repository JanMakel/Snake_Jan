using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUpFloatingPoints : MonoBehaviour
{
    [SerializeField] private FoodSO foodSO;
    private TextMeshProUGUI texto;

    private void Start()
    {

        texto.text = foodSO.points.ToString();
        Destroy(gameObject, 5);

    }

}
