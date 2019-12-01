using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] diceSprites;
    public SpriteRenderer diceRenderer;
    private int randomDiceSide;
    private bool moveAllow;
    private int target;

    public Transform[] wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        diceRenderer.sprite = diceSprites[0];
        moveAllow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DiceGenerator());
            moveAllow = true;
            
        }
        if (wayPoints.Length > target && moveAllow)
        {
            MovePlayer();
        }
    }

    IEnumerator DiceGenerator()
    {
        randomDiceSide = 0;

        for(int i = 0; i<6; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            diceRenderer.sprite = diceSprites[randomDiceSide];
        }

        yield return new WaitForSecondsRealtime(0.05f);

        
            
        Debug.Log("Before: " + target);
        if (wayPoints.Length >= (target + randomDiceSide + 1))
        {
            target += randomDiceSide + 1;
            Debug.Log("After: " + target);
        }

    }

    private void MovePlayer()
    {
        
            float navigationTime = Time.deltaTime * 3;
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[target-1].position, navigationTime);
        
    }
}
