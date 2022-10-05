using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : Position{
    private static int score = 0;
    public static void checkPiece(List<List<SquareColor>> board){ // check if the piece can be moved down
        for (int i = 0; i <=Pheight-1; i++){
                for (int j = 0; j <=Pwidth-1; j++){
                    if (Position.Contain(i,j) ){
                        if (i<21){
                            if (board[i+1][j] != SquareColor.BACKGROUND && !Position.Contain(i+1,j)){
                                checkLigne(board);
                                Position.PiecesTetris.Clear();
                                Pieces.piece(board);
                                Position.index =0;
                            }
                        }
                    }
            }
        }
    }
    public static void checkLigne(List<List<SquareColor>> board){ // check if there is a line to delete
        for (int i = 0; i <=Pheight-1; i++){
                for (int j = 0; j <=Pwidth-1; j++){
                    if (board[i][j] == SquareColor.BACKGROUND){
                        break;
                    }else if (j == Pwidth-1){
                        for (int k = 0; k <=Pwidth-1; k++){
                            board[i][k] = SquareColor.BACKGROUND;
                        }
                        score = score+100;
                        GridDisplay.SetScore(score);
                        for (int l = i; l >=0; l--){
                            for (int m = 0; m <=Pwidth-1; m++){
                                if (board[l][m] != SquareColor.BACKGROUND){
                                    board[l+1][m] = board[l][m];
                                    board[l][m] = SquareColor.BACKGROUND;
                                }
                            }
                        }
                    }
            }
        }
    }
    public static int CheckPosition (List<List<SquareColor>> board){ // Check if the piece can be moved left or right
        for (int i = Pheight-1; i >=0; i--){
            for (int j = Pwidth-1; j >=0; j--){
                if ((j+1>9 || (board[i][j+1] != SquareColor.BACKGROUND && !Position.Contain(i,j+1)) ) && Position.Contain(i,j)){
                    GridDisplay.check = 1;
                    return GridDisplay.check;
                }else if ((j-1<0 || (board[i][j-1] != SquareColor.BACKGROUND && !Position.Contain(i,j-1)) ) && Position.Contain(i,j)){
                    GridDisplay.check = 2;
                    return GridDisplay.check;
                }
            }
        }
        return 0;
    }


}