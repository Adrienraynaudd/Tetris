using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position{
    private int posA; //Y 
    private int posB; //X
    public static List<Position> PiecesTetris = new List<Position>();
    public Position(int posA, int posB){
        this.posA = posA;
        this.posB = posB;
    }
        private static int index = 4;
        private static int score = 0;
        private static int Pheight = GridDisplay.height;
        private static int Pwidth = GridDisplay.width;
           public static  void DownPiece (List<List<SquareColor>> board){ // move the piece down
            for (int i = Pheight-1; i >=0; i--){
                for (int j = Pwidth-1; j >=0; j--){
                    if (board[i][j] != SquareColor.LIGHT_BLUE && Contain(i,j)){ // if the square is not empty and if the square is part of the piece
                        if (i< 21){
                        if (board[i+1][j] == SquareColor.LIGHT_BLUE ){
                            board[i+1][j] = board[i][j];
                            board[i][j] = SquareColor.LIGHT_BLUE;
                            PiecesTetris.Add(new Position(i+1,j));
                            PiecesTetris.Remove(new Position(i,j));
                            index++;
                            if (index >= 4){ // verifie if the piece can be moved down
                                checkPiece(board);
                                index =0;
                            }
                        }else {
                                checkLigne(board);
                                PiecesTetris.Clear();
                                Pieces.piece(board);
                                index =0;
                        }
                    }else {
                                checkLigne(board);
                                PiecesTetris.Clear();
                                Pieces.piece(board);
                                index =0;
                        }
                }
            }
        }
    }
    public static void MoveL(List<List<SquareColor>> board){ // move the piece to the left
            for (int i=0;i<Pheight;i++){
                        for (int j = 0;j<Pwidth;j++){
                            if (board[i][j] != SquareColor.LIGHT_BLUE && Contain(i,j)){
                                if (board[i][j-1]== SquareColor.LIGHT_BLUE){
                                board[i][j-1] = board[i][j];
                                board[i][j] =SquareColor.LIGHT_BLUE;
                                 PiecesTetris.Remove(new Position(i,j));
                                PiecesTetris.Add(new Position(i,j-1));
                                }
                                }
                }
                }
        }

        public static void MoveR(List<List<SquareColor>> board){ // move the piece to the right
            for (int k=0;k<Pheight;k++){
                        for (int l = Pwidth-1;l > -1;l--){//Warning: here we go through the table from right to left so as not to fall on the box that we have just modified.
                            if (board[k][l] != SquareColor.LIGHT_BLUE && Contain(k,l)){
                                if (board[k][l+1] == SquareColor.LIGHT_BLUE){
                                board[k][l+1] = board[k][l];
                                board[k][l] =SquareColor.LIGHT_BLUE;
                                PiecesTetris.Remove(new Position(k,l));
                                PiecesTetris.Add(new Position(k,l+1));
                                }
                                }
                }
                }
        }
        public static void Rush(List<List<SquareColor>> board){ // move the piece to the bottom
            for (int i = Pheight-1; i >=0; i--){
                for (int j = Pwidth-1; j >=0; j--){
                    if (board[i][j] != SquareColor.LIGHT_BLUE && Contain(i,j)){
                        GridDisplay.SetTickTime(0.01f);
                    }
            }
        }
    }

    public static bool Contain (int A , int B){ // check if the square is part of the piece
        Position myPos = new Position(A,B);
        foreach (Position pos in PiecesTetris){
            if (pos.posA == myPos.posA && pos.posB == myPos.posB){
                return true;
            }
        }
        return false;
    }
    private static void checkPiece(List<List<SquareColor>> board){ // check if the piece can be moved down
        for (int i = 0; i <=Pheight-1; i++){
                for (int j = 0; j <=Pwidth-1; j++){
                    if (Contain(i,j) ){
                        if (i<21){
                            if (board[i+1][j] != SquareColor.LIGHT_BLUE && !Contain(i+1,j)){
                                checkLigne(board);
                                PiecesTetris.Clear();
                                Pieces.piece(board);
                                index =0;
                            }
                        }
                    }
            }
        }
    }
    private static void checkLigne(List<List<SquareColor>> board){ // check if there is a line to delete
        for (int i = 0; i <=Pheight-1; i++){
                for (int j = 0; j <=Pwidth-1; j++){
                    if (board[i][j] == SquareColor.LIGHT_BLUE){
                        break;
                    }
                    if (j == Pwidth-1){
                        for (int k = 0; k <=Pwidth-1; k++){
                            board[i][k] = SquareColor.LIGHT_BLUE;
                        }
                        score = score+100;
                        GridDisplay.SetScore(score);
                        for (int l = i; l >=0; l--){
                            for (int m = 0; m <=Pwidth-1; m++){
                                if (board[l][m] != SquareColor.LIGHT_BLUE){
                                    board[l+1][m] = board[l][m];
                                    board[l][m] = SquareColor.LIGHT_BLUE;
                                }
                            }
                        }
                    }
            }
        }
    }
    public static void Rotate(List<List<SquareColor>> board){
        int xmin = 99;
        int ymin = 99;
        int xmax = 0;
        int ymax = 0;
        //(xmin,ymin)
        foreach(Position item in PiecesTetris){
            if (item.posA < xmin){
                xmin = item.posA;
            }
            if (item.posB < ymin){
                ymin = item.posB;
            }
             if (item.posA > xmax){
                xmax = item.posA;
            }
             if (item.posB > ymax){
                ymax = item.posB;
            }
            }
        int middleX = (xmin +xmax)/2;
        int middleY = (ymin +ymax)/2;
        foreach(Position item in PiecesTetris){
            int newY = middleY +(item.posA - middleX);
            int newX = middleX -(item.posB - middleY);
            SquareColor color = board[item.posA][item.posB];
            //board[item.posA][item.posB] = SquareColor.LIGHT_BLUE;
            board[newX][newY] = color;
            item.posA = newX;
            item.posB = newY;
            }
            foreach(Position item in PiecesTetris){
                UnityEngine.Debug.Log(item.posA);
                UnityEngine.Debug.Log(item.posB);
            }
        /*if (board[xmin][ymin] != SquareColor.YELLOW && board[xmin][ymin] != SquareColor.DEEP_BLUE){
            for (int i=0;i<4;i++){
            List<bool> Ligne = new List<bool>();
            for (int j = 0;j<4;j++){
                if (board[xmin+i][ymin+j] != SquareColor.LIGHT_BLUE){
                    Ligne.Add(true);
                }else{
                    Ligne.Add(true);
                }
            }
            intermediatePiecesTetris.Add(Ligne);
        }

        for (int i=0;i<4;i++){
            for (int j = 0;j<4;j++){
                List<List<bool>> Tampon = intermediatePiecesTetris[i][j];
                intermediatePiecesTetris[i][j]=intermediatePiecesTetris[j][i];
                intermediatePiecesTetris[j][i] = Tampon;
            }
        }*/

        
        /*Position.PiecesTetris.Add(new Position (0,3));
        Position.PiecesTetris.Add(new Position (0,4));
        Position.PiecesTetris.Add(new Position (1,4));
        Position.PiecesTetris.Add(new Position (1,5));*/
        /*foreach(Position item in PiecesTetris){
                                int stock = item.posA;
                                if (item.posA != 1-(item.posB-1)){
                                    board[item.posA][item.posB] = SquareColor.LIGHT_BLUE;
                                }
                                board[item.posA][item.posB] = SquareColor.LIGHT_BLUE;
                                item.posA = 1-(item.posB-1);
                                item.posB = stock;
                                board[item.posA][item.posB] = SquareColor.RED;
                            }*/
    }
}