namespace GameLogic.Board
{
    public class BoardCtrl
    {
        private BoardModel _boardModel = new BoardModel();
        private BoardView _boardView = new BoardView();

        public BoardCtrl()
        {
            _boardModel.InitBoardMap();
            _boardView.DisplayPieces(_boardModel.BoardMap);
        }
    }
}