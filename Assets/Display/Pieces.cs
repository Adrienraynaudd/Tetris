using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public static List<Position> PiecesTetris = new List<Position>();

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
            PiecesTetris.Add(new Position (0,4));
            PiecesTetris.Add(new Position (0,5));
            PiecesTetris.Add(new Position (1,4));
            PiecesTetris.Add(new Position (1,5));
        }
         public static void LeT (List<List<SquareColor>> board){
            board[0][3] = SquareColor.PURPLE;
            board[0][4] = SquareColor.PURPLE;
            board[0][5] = SquareColor.PURPLE;
            board[1][4] = SquareColor.PURPLE;
            PiecesTetris.Add(new Position (0,3));
            PiecesTetris.Add(new Position (0,4));
            PiecesTetris.Add(new Position (0,5));
            PiecesTetris.Add(new Position (1,4));
        }
         public static void LeI (List<List<SquareColor>> board){
            board[0][3] = SquareColor.DEEP_BLUE;
            board[0][4] = SquareColor.DEEP_BLUE;
            board[0][5] = SquareColor.DEEP_BLUE;
            board[0][6] = SquareColor.DEEP_BLUE;
            PiecesTetris.Add(new Position (0,3));
            PiecesTetris.Add(new Position (0,4));
            PiecesTetris.Add(new Position (0,5));
            PiecesTetris.Add(new Position (0,6));
        }
        public static void LeLD (List<List<SquareColor>> board){
            board[0][4] = SquareColor.GREEN;
            board[1][4] = SquareColor.GREEN;
            board[2][4] = SquareColor.GREEN;
            board[2][5] = SquareColor.GREEN;
            PiecesTetris.Add(new Position (0,4));
            PiecesTetris.Add(new Position (1,4));
            PiecesTetris.Add(new Position (2,4));
            PiecesTetris.Add(new Position (2,5));
        }
        public static void LeLG (List<List<SquareColor>> board){
            board[0][5] = SquareColor.RED;
            board[1][5] = SquareColor.RED;
            board[2][5] = SquareColor.RED;
            board[2][4] = SquareColor.RED;
            PiecesTetris.Add(new Position (0,5));
            PiecesTetris.Add(new Position (1,5));
            PiecesTetris.Add(new Position (2,5));
            PiecesTetris.Add(new Position (2,4));
        }
        public static void LeZD (List<List<SquareColor>> board){
            board[0][4] = SquareColor.ORANGE;
            board[0][5] = SquareColor.ORANGE;
            board[1][3] = SquareColor.ORANGE;
            board[1][4] = SquareColor.ORANGE;
            PiecesTetris.Add(new Position (0,4));
            PiecesTetris.Add(new Position (0,5));
            PiecesTetris.Add(new Position (1,3));
            PiecesTetris.Add(new Position (1,4));
        }
        public static void LeZG (List<List<SquareColor>> board){
            board[0][3] = SquareColor.ORANGE;
            board[0][4] = SquareColor.ORANGE;
            board[1][4] = SquareColor.ORANGE;
            board[1][5] = SquareColor.ORANGE;
            PiecesTetris.Add(new Position (0,3));
            PiecesTetris.Add(new Position (0,4));
            PiecesTetris.Add(new Position (1,4));
            PiecesTetris.Add(new Position (1,5));
        }
        // down piece in board
        //index down
        public static  void DownPiece (List<List<SquareColor>> board){
            for (int i = 21; i >=0; i--){
                for (int j = 9; j >=0; j--){
                    Position myPos = new Position(i,j);
                    if (board[i][j] != SquareColor.LIGHT_BLUE && PiecesTetris.Contains(myPos)){
                        if (i< 21){
                        if (board[i+1][j] == SquareColor.LIGHT_BLUE ){
                            board[i+1][j] = board[i][j];
                            board[i][j] = SquareColor.LIGHT_BLUE;
                            PiecesTetris.Remove(myPos);
                            PiecesTetris.Add(new Position(i+1,j));
                        }else {
                                PiecesTetris.Clear();
                                piece(board);
                        }
                    }else {
                                PiecesTetris.Clear();
                                piece(board);
                        }
                }
            }
        }
    }
    public static void MoveL(List<List<SquareColor>> board)
        {
            for (int i=0;i<22;i++){
                        for (int j = 0;j<10;j++){
                            if (board[i][j] != SquareColor.LIGHT_BLUE){
                                board[i][j-1] = board[i][j];
                                board[i][j] =SquareColor.LIGHT_BLUE;
                                }
                }  
                }
        }

        public static void MoveR(List<List<SquareColor>> board)
        {
            for (int k=0;k<22;k++){ // attention : ici on parcourt le tableau de droite à gauche afin de ne pas tomber sur la case qu'on vient juste de modifier.
                        for (int l = 9;l > -1;l--){
                            if (board[k][l] != SquareColor.LIGHT_BLUE){
                                board[k][l+1] = board[k][l];
                                board[k][l] =SquareColor.LIGHT_BLUE;
                                }
                }  
                }
        }
}
public class Position{
    public int posA;
    public int posB;
    public Position(int posA, int posB){
        this.posA = posA;
        this.posB = posB;
    }
}
