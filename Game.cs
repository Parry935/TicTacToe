using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe
{
    //Enum specifying property for field in game
    public enum FieldProperty
    { 
       Empty,
       Cross,
       Circle,
       Bloced,
       Win
    }

    //Enum specifying current player
    public enum CurrentPlayer
    {
        CrossPlayer,
        CirclePlayer
    }

    class Game
    {
        //Array specifying fields in game 
        public FieldProperty[,] FieldArray;

        public Game()
        {
            //Array initialization - defaul value {FieldProperty.Empty}
            FieldArray = new FieldProperty[3,3];
        }


        // Function checking win for current player
        public bool CurrentPlayerWin()
        {
            bool Win = false;

            //Check if 3 fields are the same and not empty 
            //If condition is true - assign to fields value {FieldProperty.Win} and return Win {true}

            if (((FieldArray[0, 0] & FieldArray[0, 1] & FieldArray[0, 2]) == FieldArray[0, 0]) && FieldArray[0, 0] != FieldProperty.Empty)
            {
                FieldArray[0, 0] = FieldProperty.Win;
                FieldArray[0, 1] = FieldProperty.Win;
                FieldArray[0, 2] = FieldProperty.Win;
                Win = true;
            }
            else if (((FieldArray[1, 0] & FieldArray[1, 1] & FieldArray[1, 2]) == FieldArray[1, 0]) && FieldArray[1, 0] != FieldProperty.Empty)
            {
                FieldArray[1, 0] = FieldProperty.Win;
                FieldArray[1, 1] = FieldProperty.Win;
                FieldArray[1, 2] = FieldProperty.Win;
                Win = true;
            }
            else if (((FieldArray[2, 0] & FieldArray[2, 1] & FieldArray[2, 2]) == FieldArray[2, 0]) && FieldArray[2, 0] != FieldProperty.Empty)
            {
                FieldArray[2, 0] = FieldProperty.Win;
                FieldArray[2, 1] = FieldProperty.Win;
                FieldArray[2, 2] = FieldProperty.Win;
                Win = true;
            }
            else if (((FieldArray[0, 0] & FieldArray[1, 0] & FieldArray[2, 0]) == FieldArray[0, 0]) && FieldArray[0, 0] != FieldProperty.Empty)
            {
                FieldArray[0, 0] = FieldProperty.Win;
                FieldArray[1, 0] = FieldProperty.Win;
                FieldArray[2, 0] = FieldProperty.Win;
                Win = true;
            }
            else if (((FieldArray[0, 1] & FieldArray[1, 1] & FieldArray[2, 1]) == FieldArray[0, 1]) && FieldArray[0, 1] != FieldProperty.Empty)
            {
                FieldArray[0, 1] = FieldProperty.Win;
                FieldArray[1, 1] = FieldProperty.Win;
                FieldArray[2, 1] = FieldProperty.Win;
                Win = true;
            }
            else if (((FieldArray[0, 2] & FieldArray[1, 2] & FieldArray[2, 2]) == FieldArray[0, 2]) && FieldArray[0, 2] != FieldProperty.Empty)
            {
                FieldArray[0, 2] = FieldProperty.Win;
                FieldArray[1, 2] = FieldProperty.Win;
                FieldArray[2, 2] = FieldProperty.Win;
                Win = true;
            }
            else if (((FieldArray[0, 0] & FieldArray[1, 1] & FieldArray[2, 2]) == FieldArray[0, 0]) && FieldArray[0, 0] != FieldProperty.Empty)
            {
                FieldArray[0, 0] = FieldProperty.Win;
                FieldArray[1, 1] = FieldProperty.Win;
                FieldArray[2, 2] = FieldProperty.Win;
                Win = true;
            }
            else if (((FieldArray[0, 2] & FieldArray[1, 1] & FieldArray[2, 0]) == FieldArray[0, 2]) && FieldArray[0, 2] != FieldProperty.Empty)
            {
                FieldArray[0, 2] = FieldProperty.Win;
                FieldArray[1, 1] = FieldProperty.Win;
                FieldArray[2, 0] = FieldProperty.Win;
                Win = true;
            }

            return Win;
        }
    }
}
