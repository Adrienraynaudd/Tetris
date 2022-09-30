using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDisplay : MonoBehaviour
{
    // Hauteur de la grille en nombre de cases
    public static int height = 22;

    // Largeur de la grille en nombre de cases
    public static int width = 10;
    private static int check = 0;

    // Cette fonction se lance au lancement du jeu, avant le premier affichage.
    public static void Initialize(){
        List<List<SquareColor>> board = new List<List<SquareColor>>(); // Creation background board
        for (int i=0;i<height;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<width;j++){
                Ligne.Add(SquareColor.LIGHT_BLUE);
            }
            board.Add(Ligne);
        }
        SetTickTime(0.5f);
        SetColors(board); // Set the color of the squares
        Pieces.piece(board);// Create the first piece
        SetColors(board);
        SetTickFunction (() =>  { // We define the function that will be called at each tick
            Position.DownPiece(board);
            SetColors(board);
        });
        SetMoveLeftFunction(()=>{ // We define the function that will be called when the left arrow is pressed
        if (CheckPosition(board) !=2 ){
            Position.MoveL(board);
            SetColors(board);
            CheckPosition(board);
        }
        });
        SetMoveRightFunction(()=>{ // We define the function that will be called when the right arrow is pressed
        if (CheckPosition(board) !=1 ){
            Position.MoveR(board);
            SetColors(board);
            CheckPosition(board);
        }
        });
        SetRushFunction(()=>{ // We define the function that will be called when the down arrow is pressed
            Position.Rush(board);
            SetColors(board);
        });
        SetRotateFunction(()=>{ // We define the function that will be called when the down arrow is pressed
            Position.Rotate(board);
            SetColors(board);
        });
            }
    private static int CheckPosition (List<List<SquareColor>> board){ // Check if the piece can be moved left or right
        for (int i = height-1; i >=0; i--){
            for (int j = width-1; j >=0; j--){
                if ((j+1>9 || (board[i][j+1] != SquareColor.LIGHT_BLUE && !Position.Contain(i,j+1)) ) && Position.Contain(i,j)){
                    check = 1;
                    return check;
                }else if ((j-1<0 || (board[i][j-1] != SquareColor.LIGHT_BLUE && !Position.Contain(i,j-1)) ) && Position.Contain(i,j)){
                    check = 2;
                    return check;
                }
            }
        }
        return 0;
    }
    // Paramètre la fonction devant être appelée à chaque tick.
    // C'est ici que le gros de la logique temporelle de votre jeu aura lieu!
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetTickFunction(TickFunction function){
        _grid.Tick = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace
    // pour faire tourner la pièce dans le sens horaire.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRotateFunction(RotateFunction function){
        _grid.Rotate = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de gauche
    // pour bouger la pièce vers la gauche.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveLeftFunction(MoveFunction function){
        _grid.MoveLeft = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de droite
    // pour bouger la pièce vers la droite.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveRightFunction(MoveFunction function){
        _grid.MoveRight = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace
    // pour faire descendre la pièce tout en bas.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRushFunction(RushFunction function){
        _grid.Rush = function;
    }

    // Modifie l'intervale de rendu du jeu. A modifier pour modifier la difficulté en cours de partie.
    public static void SetTickTime(float seconds){
        _grid.tick = seconds;
    }

    // Modifie toutes les couleurs de chaque case de la grille.
    // Cette fonction doit prendre en argument un tableau de LIGNES, de haut vers le bas, contenant
    // des couleurs de case allant de gauche vers la droite.
    // Vous appellerez a priori cette fonction une fois par TickFunction, une fois le nouvel état de la grille
    // calculé.
    public static void SetColors(List<List<SquareColor>> colors){
        _grid.SetColors(colors);
    }

    // Modifie visuellement le score de l'utilisateur en bas à droite.
    public static void SetScore(int score){
        _grid.SetScore(score);
    }
    // Déclenche visuellement le GameOver et arrête le jeu.
    public static void TriggerGameOver(){
        _grid.TriggerGameOver();
    }


/// Les lignes au delà de celle-ci ne vous concernent pas.

    private static _GridDisplay _grid = null;
    void Awake()
    {
        _grid = GameObject.FindObjectOfType<_GridDisplay>();
        _grid.height = height;
        _grid.width = width;
    }

    void Start(){
        Initialize();
    }
}