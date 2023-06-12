using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiddenItem : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public bool isDestroying;
    public float destroyTimer;
    public Vector3 size;
    public Game g_Game;
    private void Start()
    {
        itemName.color = Color.white;
        destroyTimer = 1.0f;
        size = this.gameObject.transform.localScale;
        g_Game = GameObject.FindGameObjectWithTag("Script").GetComponent<Game>();
    }
    private void Update()
    {
        if (isDestroying == true)
        {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer >= 0.5f)
            {
                this.gameObject.transform.localScale = new Vector3(size.x += Time.deltaTime, size.y += Time.deltaTime, 0);
            }
            if (destroyTimer <= 0.5f)
            {
                this.gameObject.transform.localScale = new Vector3(size.x -= Time.deltaTime, size.y -= Time.deltaTime, 0);
            }
            if (destroyTimer <= 0)
            {
                g_Game.findedObjs++;
                itemName.color = Color.gray;
                Destroy(this.gameObject);
            }
        }
    }
    public void OnMouseDown()
    {
        isDestroying = true;
    }
}
