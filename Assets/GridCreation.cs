using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreation : MonoBehaviour
{
    [SerializeField] private int boardSize = 3;
    [SerializeField] private GameObject tile;
    [SerializeField] private Camera camera;

    [SerializeField] private Color light = Color.white;
    [SerializeField] private Color dark = Color.black;


    private void Start()
    {
        CreateBoard(boardSize);
    }


    private void CreateBoard(int boardSize){
        for (int i = 0; i < boardSize; i++){
            for (int j = 0; j < boardSize; j++){
                GameObject currentTile = Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
                SpriteRenderer renderer = currentTile.GetComponent<SpriteRenderer>();
                SetGridTileColor(i, j, renderer);
            }
        }

        CenterCamera(boardSize);
    }


    private void SetGridTileColor(int x, int y, SpriteRenderer renderer){
        if (y % 2 == 0){
            if (x % 2 == 0){
                renderer.color = dark;
            } else { renderer.color = light; }
        } else {
            if (x % 2 != 0){
                renderer.color = dark;
            } else { renderer.color = light; }
        }
    }


    private void CenterCamera(int boardSize){ // going to need math to edit size of camera if cannot fit board in view
        if (boardSize % 2 != 0){
            camera.transform.position = new Vector3(boardSize/2, boardSize/2, camera.transform.position.z);
        } else {
            camera.transform.position = new Vector3(boardSize/2-.5f, boardSize/2-.5f, camera.transform.position.z);
        }
    }
}
