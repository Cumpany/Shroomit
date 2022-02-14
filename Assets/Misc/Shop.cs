using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopObject;
    void Start() {
        ShopObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col) {
        ShopObject.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D col) {
        ShopObject.SetActive(false);
    }
}
