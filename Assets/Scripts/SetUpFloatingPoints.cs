using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUpFloatingPoints : MonoBehaviour
{
    [SerializeField] private FoodSO foodSO;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private ParticleSystem explosion;
    
    private void Start()
    {
        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
       
        texto.text = foodSO.points.ToString();
        
        Destroy(gameObject, 1.5f);

    }

   

}
