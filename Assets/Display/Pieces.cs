using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
        public static void carre (List<List<SquareColor>> board){
            board[0][4] = SquareColor.YELLOW;
            board[0][5] = SquareColor.YELLOW;
            board[1][4] = SquareColor.YELLOW;
            board[1][5] = SquareColor.YELLOW;
        }
         public static void LeT (List<List<SquareColor>> board){
            board[0][3] = SquareColor.PURPLE;
            board[0][4] = SquareColor.PURPLE;
            board[0][5] = SquareColor.PURPLE;
            board[1][4] = SquareColor.PURPLE;
        }
         public static void LeI (List<List<SquareColor>> board){
            board[0][3] = SquareColor.DEEP_BLUE;
            board[0][4] = SquareColor.DEEP_BLUE;
            board[0][5] = SquareColor.DEEP_BLUE;
            board[0][6] = SquareColor.DEEP_BLUE;
        }
        public static void LeLD (List<List<SquareColor>> board){
            board[0][4] = SquareColor.GREEN;
            board[1][4] = SquareColor.GREEN;
            board[2][4] = SquareColor.GREEN;
            board[2][5] = SquareColor.GREEN;
        }
        public static void LeLG (List<List<SquareColor>> board){
            board[0][5] = SquareColor.RED;
            board[1][5] = SquareColor.RED;
            board[2][5] = SquareColor.RED;
            board[2][4] = SquareColor.RED;
        }
        public static void LeZD (List<List<SquareColor>> board){
            board[0][4] = SquareColor.ORANGE;
            board[0][5] = SquareColor.ORANGE;
            board[1][3] = SquareColor.ORANGE;
            board[1][4] = SquareColor.ORANGE;
        }
        public static void LeZG (List<List<SquareColor>> board){
            board[0][3] = SquareColor.ORANGE;
            board[0][4] = SquareColor.ORANGE;
            board[1][4] = SquareColor.ORANGE;
            board[1][5] = SquareColor.ORANGE;
        }
}