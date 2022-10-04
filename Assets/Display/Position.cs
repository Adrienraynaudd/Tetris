using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position{
    public int posY;
    public int posX;
    public static List<Position> PiecesTetris = new List<Position>();
    public Position(int posY, int posX){
        this.posY = posY;
        this.posX = posX;
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
                            Position myPos = new Position(i,j);
                            foreach (Position pos in PiecesTetris){
                                if (pos.posY == myPos.posY && pos.posX == myPos.posX){
                                    pos.posY = pos.posY + 1;
                                         }
                                }
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
                            if (Contain(i,j)){
                                if (board[i][j-1]== SquareColor.LIGHT_BLUE){
                                board[i][j-1] = board[i][j];
                                board[i][j] =SquareColor.LIGHT_BLUE;
                                 Position myPos = new Position(i,j);
                            foreach (Position pos in PiecesTetris){
                                if (pos.posY == myPos.posY && pos.posX == myPos.posX){
                                    pos.posX = pos.posX - 1;
                                         }
                                }
                            }
                        }
                }
            }
        }

        public static void MoveR(List<List<SquareColor>> board){ // move the piece to the right
            for (int k=0;k<Pheight;k++){
                        for (int l = Pwidth-1;l > -1;l--){//Warning: here we go through the table from right to left so as not to fall on the box that we have just modified.
                            if (Contain(k,l)){
                                if (board[k][l+1] == SquareColor.LIGHT_BLUE){
                                board[k][l+1] = board[k][l];
                                board[k][l] =SquareColor.LIGHT_BLUE;
                                 Position myPos = new Position(k,l);
                            foreach (Position pos in PiecesTetris){
                                if (pos.posY == myPos.posY && pos.posX == myPos.posX){
                                    pos.posX = pos.posX + 1;
                                         }
                                }
                            }
                        }
                }
            }
        }
    public static void Rush(List<List<SquareColor>> board){ // move the piece to the bottom
            for (int i = Pheight-1; i >=0; i--){
                for (int j = Pwidth-1; j >=0; j--){
                    if (Contain(i,j)){
                        GridDisplay.SetTickTime(0.01f);
                    }
            }
        }
    }

    public static bool Contain (int A , int B){ // check if the square is part of the piece
        Position myPos = new Position(A,B);
        foreach (Position pos in PiecesTetris){
            if (pos.posY == myPos.posY && pos.posX == myPos.posX){
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
                    }else if (j == Pwidth-1){
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
        foreach(Position item in PiecesTetris){
            if (item.posY < ymin){
                ymin = item.posY;
            }
            if (item.posX < xmin){
                xmin = item.posX;
            }
             if (item.posY > ymax){
                ymax = item.posY;
            }
             if (item.posX > xmax){
                xmax = item.posX;
            }
            }
        if (xmin != 0 && xmax != 9 ){ // empêcher la rotation sur le bords !
        int middleY = (ymin +ymax)/2;
        int middleX = (xmin +xmax)/2;
        List<Position> NewPiecesTetris = new List<Position>(); //a list of the new positions of the turned piece.
        SquareColor color = board[PiecesTetris[0].posY][PiecesTetris[0].posX]; //here I get the color of the falling piece.
        foreach(Position item in PiecesTetris){
            int newY = middleY +(item.posX - middleX);
            int newX = middleX -(item.posY - middleY);
            board[item.posY][item.posX-1] = SquareColor.LIGHT_BLUE ;
            board[newY][newX] = color;
            NewPiecesTetris.Add(new Position (newY,newX));
            }
            PiecesTetris = NewPiecesTetris; 
            foreach(Position item in PiecesTetris){ //I make sure to color my new positions well.
                board[item.posY][item.posX] = color;
            }

            //TODO : Regler le décalage lier aux int qui arrondissent décale le centre legerment vers la gauche.
        }
    }
}