using UnityEngine;

namespace GameLogic.Board
{
    public class BoardModel
    {
        public PieceEnum[,] BoardMap = new PieceEnum[GlobalData.BoardDimension, GlobalData.BoardDimension];
        
        public void InitBoardMap()
        {
            for (var i = 0; i < GlobalData.BoardDimension; i++)
            {
                for (var j = 0; j < GlobalData.BoardDimension; j++)
                {
                    BoardMap[i, j] = PieceEnum.Null;
                    Debug.Log(BoardMap[i, j]);
                }
            }
        }
    }
}