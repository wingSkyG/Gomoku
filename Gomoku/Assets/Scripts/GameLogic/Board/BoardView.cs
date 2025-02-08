using System;
using System.Diagnostics;
using Managers;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace GameLogic.Board
{
    public class BoardView
    {
        public void DisplayPieces(PieceEnum[,] boardMap)
        {
            for (int i = 0; i < GlobalData.BoardDimension; i++)
            {
                for (int j = 0; j < GlobalData.BoardDimension; j++)
                {
                    CreatePiece(boardMap[i, j], i, j);
                }
            }
        }

        private void CreatePiece(PieceEnum pieceEnum, int iIndex, int jIndex)
        {

            GameObject obj;
            switch (pieceEnum)
            {
                case PieceEnum.BlackPiece:
                    obj = AssetManager.Instance.LoadAsset<GameObject>("Assets/Resources_moved/Prefabs/BlackPiece.prefab");
                    CreateAndPlacePieceUI(obj, iIndex, jIndex);
                    break;
                case PieceEnum.WhitePiece:
                    obj = AssetManager.Instance.LoadAsset<GameObject>("Assets/Resources_moved/Prefabs/BlackPiece.prefab");
                    CreateAndPlacePieceUI(obj, iIndex, jIndex);
                    break;
                case PieceEnum.Null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            
        }

        private void CreateAndPlacePieceUI(GameObject UI, int iIndex, int jIndex)
        {
            var pieceUI = UIManager.Instance.CreateUI(UI, UIManager.Instance.GetUI("PlaceArea"));
            UIManager.Instance.SetAnchoredPosition( pieceUI,new Vector2(iIndex * GlobalData.CellSize, jIndex * GlobalData.CellSize));
        }
    }
}