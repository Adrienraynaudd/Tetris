using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position{
    private int posY;
    private int posX;
    public static List<Position> PiecesTetris = new List<Position>();
    public Position(int posY, int posX){
        this.posY = posY;
        this.posX = posX;
    }
        protected static int index = 4;
        protected static int Pheight = GridDisplay.height;
        protected static int Pwidth = GridDisplay.width;
            public static  void DownPiece (List<List<SquareColor>> board){// move the piece down
            for (int i = Pheight-1; i >=0; i--){
                for (int j = Pwidth-1; j >=0; j--){
                    if (board[i][j] != SquareColor.BACKGROUND && Contain(i,j)){ // if the square is not empty and if the square is part of the piece
                        if (i< 21){
                        if (board[i+1][j] == SquareColor.BACKGROUND ){
                            board[i+1][j] = board[i][j];
                            board[i][j] = SquareColor.BACKGROUND;
                            Position myPos = new Position(i,j);
                            foreach (Position pos in PiecesTetris){
                                if (pos.posY == myPos.posY && pos.posX == myPos.posX){
                                    pos.posY = pos.posY + 1;
                                         }
                                }
                            index++;
                            if (index >= 4){ // check if the piece can be moved down
                                Check.checkPiece(board);
                                index =0;
                            }
                        }else {
                                Check.checkLigne(board);
                                PiecesTetris.Clear();
                                Pieces.piece(board);
                                index =0;
                        }
                    }else {
                                Check.checkLigne(board);
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
                                if (board[i][j-1]== SquareColor.BACKGROUND){
                                board[i][j-1] = board[i][j];
                                board[i][j] =SquareColor.BACKGROUND;
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
                                if (board[k][l+1] == SquareColor.BACKGROUND){
                                board[k][l+1] = board[k][l];
                                board[k][l] =SquareColor.BACKGROUND;
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
    protected static bool Contain (int A , int B){ // check if the square is part of the piece
        Position myPos = new Position(A,B);
        foreach (Position pos in PiecesTetris){
            if (pos.posY == myPos.posY && pos.posX == myPos.posX){
                return true;
            }
        }
        return false;
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
        if (xmin != 0 && xmax != 9 ){ // empêcher la rotation sur les bords !
        int middleY = (ymin +ymax)/2;
        int middleX = (xmin +xmax)/2;
        bool isPossibleToRotate = true;
        List<Position> NewPiecesTetris = new List<Position>(); //a list of the new positions of the turned piece.
        SquareColor color = board[PiecesTetris[0].posY][PiecesTetris[0].posX]; //here I get the color of the falling piece.
        foreach(Position item in PiecesTetris){
            int newY = middleY +(item.posX - middleX);
            int newX = middleX -(item.posY - middleY);
            if (board[newY][newX] == SquareColor.BACKGROUND || board[newY][newX] == color){ // check around the piece to make sure it's possible to rotate 
                board[item.posY][item.posX] = SquareColor.BACKGROUND ;
                NewPiecesTetris.Add(new Position (newY,newX));
            } else {
                isPossibleToRotate = false;
            }
            }
            if (isPossibleToRotate == true){
                PiecesTetris = NewPiecesTetris;    
                foreach(Position item in PiecesTetris){ //I make sure to color my new positions well.
                board[item.posY][item.posX] = color;
            }
            } else {
                foreach(Position item in PiecesTetris){
                    board[item.posY][item.posX] = color;
                } 
            } //TODO : Regler le décalage lier aux int qui arrondissent décale le centre legerment vers la gauche.
        }
    }
}