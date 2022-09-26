using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public static void  piece (List<List<SquareColor>> board){
        int rand = Random.Range(1, 7);
        switch (rand){
            case 1:
                Pieces.carre(board);
                break;
            case 2:
                Pieces.LeT(board);
                break;
            case 3:
                Pieces.LeI(board);
                break;
            case 4:
                Pieces.LeLD(board);
                break;
            case 5:
                Pieces.LeLG(board);
                break;
            case 6:
                Pieces.LeZD(board);
                break;
            case 7:
                Pieces.LeZG(board);
                break;
        }
    }
        public static  void carre (List<List<SquareColor>> board){
            board[0][4] = SquareColor.YELLOW;
            board[0][5] = SquareColor.YELLOW;
            board[1][4] = SquareColor.YELLOW;
            board[1][5] = SquareColor.YELLOW;
            Position.PiecesTetris.Add(new Position (0,4));
            Position.PiecesTetris.Add(new Position (0,5));
            Position.PiecesTetris.Add(new Position (1,4));
            Position.PiecesTetris.Add(new Position (1,5));
        }
         public static void LeT (List<List<SquareColor>> board){
            board[0][3] = SquareColor.PURPLE;
            board[0][4] = SquareColor.PURPLE;
            board[0][5] = SquareColor.PURPLE;
            board[1][4] = SquareColor.PURPLE;
            Position.PiecesTetris.Add(new Position (0,3));
            Position.PiecesTetris.Add(new Position (0,4));
            Position.PiecesTetris.Add(new Position (0,5));
            Position.PiecesTetris.Add(new Position (1,4));
        }
         public static void LeI (List<List<SquareColor>> board){
            board[0][3] = SquareColor.DEEP_BLUE;
            board[0][4] = SquareColor.DEEP_BLUE;
            board[0][5] = SquareColor.DEEP_BLUE;
            board[0][6] = SquareColor.DEEP_BLUE;
            Position.PiecesTetris.Add(new Position (0,3));
            Position.PiecesTetris.Add(new Position (0,4));
            Position.PiecesTetris.Add(new Position (0,5));
            Position.PiecesTetris.Add(new Position (0,6));
        }
        public static void LeLD (List<List<SquareColor>> board){
            board[0][4] = SquareColor.GREEN;
            board[1][4] = SquareColor.GREEN;
            board[2][4] = SquareColor.GREEN;
            board[2][5] = SquareColor.GREEN;
            Position.PiecesTetris.Add(new Position (0,4));
            Position.PiecesTetris.Add(new Position (1,4));
            Position.PiecesTetris.Add(new Position (2,4));
            Position.PiecesTetris.Add(new Position (2,5));
        }
        public static void LeLG (List<List<SquareColor>> board){
            board[0][5] = SquareColor.RED;
            board[1][5] = SquareColor.RED;
            board[2][5] = SquareColor.RED;
            board[2][4] = SquareColor.RED;
            Position.PiecesTetris.Add(new Position (0,5));
            Position.PiecesTetris.Add(new Position (1,5));
            Position.PiecesTetris.Add(new Position (2,5));
            Position.PiecesTetris.Add(new Position (2,4));
        }
        public static void LeZD (List<List<SquareColor>> board){
            board[0][4] = SquareColor.ORANGE;
            board[0][5] = SquareColor.ORANGE;
            board[1][3] = SquareColor.ORANGE;
            board[1][4] = SquareColor.ORANGE;
            Position.PiecesTetris.Add(new Position (0,4));
            Position.PiecesTetris.Add(new Position (0,5));
            Position.PiecesTetris.Add(new Position (1,3));
            Position.PiecesTetris.Add(new Position (1,4));
        }
        public static void LeZG (List<List<SquareColor>> board){
            board[0][3] = SquareColor.ORANGE;
            board[0][4] = SquareColor.ORANGE;
            board[1][4] = SquareColor.ORANGE;
            board[1][5] = SquareColor.ORANGE;
            Position.PiecesTetris.Add(new Position (0,3));
            Position.PiecesTetris.Add(new Position (0,4));
            Position.PiecesTetris.Add(new Position (1,4));
            Position.PiecesTetris.Add(new Position (1,5));
        }
}