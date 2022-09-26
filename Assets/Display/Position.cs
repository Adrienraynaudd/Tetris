using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position{
    public int posA;
    public int posB;
    public static List<Position> PiecesTetris = new List<Position>();
    public Position(int posA, int posB){
        this.posA = posA;
        this.posB = posB;
    }
           public static  void DownPiece (List<List<SquareColor>> board){
            for (int i = 21; i >=0; i--){
                for (int j = 9; j >=0; j--){
                    if (board[i][j] != SquareColor.LIGHT_BLUE && Contain(i,j)){
                        if (i< 21){
                        if (board[i+1][j] == SquareColor.LIGHT_BLUE ){
                            board[i+1][j] = board[i][j];
                            board[i][j] = SquareColor.LIGHT_BLUE;
                            PiecesTetris.Add(new Position(i+1,j));
                        }else {
                                PiecesTetris.Clear();
                                Pieces.piece(board);
                        }
                    }else {
                                PiecesTetris.Clear();
                                Pieces.piece(board);
                        }
                }
            }
        }
    }
    public static void MoveL(List<List<SquareColor>> board){
            for (int i=0;i<22;i++){
                        for (int j = 0;j<10;j++){
                            if (board[i][j] != SquareColor.LIGHT_BLUE && Contain(i,j)){
                                board[i][j-1] = board[i][j];
                                board[i][j] =SquareColor.LIGHT_BLUE;
                                PiecesTetris.Add(new Position(i,j-1));
                                }
                }
                }
        }

        public static void MoveR(List<List<SquareColor>> board){
            for (int k=0;k<22;k++){ // attention : ici on parcourt le tableau de droite à gauche afin de ne pas tomber sur la case qu'on vient juste de modifier.
                        for (int l = 9;l > -1;l--){
                            if (board[k][l] != SquareColor.LIGHT_BLUE && Contain(k,l)){
                                board[k][l+1] = board[k][l];
                                board[k][l] =SquareColor.LIGHT_BLUE;
                                PiecesTetris.Add(new Position(k,l+1));
                                }
                }
                }
        }
        public static void SpaceDown(List<List<SquareColor>> board){
            for (int i = 21; i >=0; i--){
                for (int j = 9; j >=0; j--){
            }
        }
    }

    public static bool Contain (int A , int B){
        Position myPos = new Position(A,B);
        foreach (Position pos in PiecesTetris){
            if (pos.posA == myPos.posA && pos.posB == myPos.posB){
                return true;
            }
        }
        return false;
    }
}
