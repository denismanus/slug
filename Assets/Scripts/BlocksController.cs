using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{

    // Use this for initialization
    public GameObject blockPrefab;
    public GameObject parentPrefab;
    private bool isCreating;
    private int maxCount = 15;
    private bool isKeeping;
    void Start()
    {

    }
    public List<GameObject> blocksList = new List<GameObject>();
    public GameObject parent;
    // Update is called once per frame

    public void DestroyBlocks()
    {
        foreach (GameObject block in blocksList)
        {
            Destroy(block);
        }
        blocksList.Clear();
        Destroy(parent);
    }

    public void StartCreating()
    {
        if (!isCreating)
        {
            isKeeping = true;
            DestroyBlocks();
            isCreating = true;
            parent = Instantiate(parentPrefab, GetComponent<Transform>());
        }

    }

    public string GetLastDirection()
    {
        if(blocksList.Count!=0)
            return blocksList[blocksList.Count - 1].GetComponent<Block>().GetDirectionCreated();
        return null;
    }
    private bool CheckIfUndo(string direction)
    {
        string lastDirection = GetLastDirection();
        if (lastDirection == null)
            return true;
        if (direction == "Left" && lastDirection == "Right")
            return false;
        if (direction == "Top" && lastDirection == "Bottom")
            return false;
        if (direction == "Right" && lastDirection == "Left")
            return false;
        if (direction == "Bottom" && lastDirection == "Top")
            return false;
        return true;
    }

    public void CreateBlock(string side)
    {
       
        if (!CheckIfUndo(side))
        {
            Destroy(blocksList[blocksList.Count - 1]);
            blocksList.RemoveAt(blocksList.Count - 1);
            return;
        }
        if (maxCount == blocksList.Count)
            return;
        Vector3 lastBlock;
        if (blocksList.Count == 0)
        {
            lastBlock = GetComponent<Transform>().position;
            lastBlock.y += 0.45f;
        }
        else
        {
            lastBlock = blocksList[blocksList.Count - 1].GetComponent<Transform>().position;
        }
        if (side == "Left")
        {
            lastBlock.x -= 1;
        }
        else if (side == "Top")
        {
            lastBlock.y += 1;
        }
        else if (side == "Right")
        {
            lastBlock.x += 1;
        }
        else if (side == "Bottom")
        {
            lastBlock.y -= 1;
        }
        //if (blocksList.Count > 2)
        //{
        //    Debug.Log("1 " + blocksList[blocksList.Count - 2].GetComponent<Transform>().position);
        //    Debug.Log("2 " + lastBlock);
        //    if (blocksList[blocksList.Count - 2].GetComponent<Transform>().position == lastBlock)
        //    {
        //        Destroy(blocksList[blocksList.Count - 1]);
        //        return;
        //    }
        //}
        blocksList.Add(Instantiate(blockPrefab, lastBlock, Quaternion.identity, parent.GetComponent<Transform>()));
        blocksList[blocksList.Count - 1].GetComponent<Block>().SetDirectionCreate(side);
    }

    public void EndCreating()
    {
        isCreating = false;
        if (blocksList.Count == 0)
            Destroy(parent);
    }

    public void Throw(bool side)
    {
        if (!isCreating && isKeeping)
        {
            parent.AddComponent<Rigidbody2D>();
            parent.GetComponent<Rigidbody2D>().freezeRotation = true;
            parent.GetComponent<Transform>().SetParent(null);
            Vector2 direction = new Vector2();
            direction.y = 2;
            if (side)
            {
                direction.x = -2;
            }
            else
            {
                direction.x = 2;
            }
            parent.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
            isKeeping = false;
        }
    }
}
