using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Encryption
    {

        public Dictionary<byte, byte> SwitchedLetterPairsInPlugBoard = new Dictionary<byte, byte>();
        public byte PositionRotor1;
        public byte PositionRotor2;
        public byte PositionRotor3;

        //public char[] RotorChoice1 = { '0', 'T', 'H', 'V', 'O', 'I', 'F', 'L', 'B', 'X', 'C', 'S', 'M', 'Q', 'N', 'A', 'P', 'D', 'Z', 'J', 'R', 'K', 'U', 'Y', 'G', 'E', 'W' };
        public byte[] RotorChoice1    = { 0, 20, 8, 22, 15, 9, 6, 12, 2, 24, 3, 19, 13, 17, 14, 1, 16, 4, 26, 10, 18, 11, 21, 25, 7, 5, 23 };

        //public char[] RotorChoice2 = { '0', 'F', 'N', 'E', 'T', 'B', 'R', 'W', 'I', 'H', 'O', 'U', 'S', 'M', 'C', 'X', 'Q', 'L', 'G', 'K', 'D', 'Y', 'V', 'P', 'Z', 'A', 'J' };       
        public byte[] RotorChoice2 = { 0, 6, 14, 5, 20, 2, 18, 23, 9, 8, 15, 21, 19, 13, 3, 24, 17, 12, 7, 11, 4, 25, 22, 16, 26, 1, 10 };

        //public char[] RotorChoice3 = { '0', 'Z', 'U', 'A', 'M', 'V', 'P', 'I', 'E', 'R', 'S', 'W', 'L', 'N', 'H', 'D', 'B', 'F', 'J', 'G', 'Y', 'K', 'T', 'Q', 'C', 'X', 'O' };
        public byte[] RotorChoice3 = { 0, 26, 21, 1, 13, 22, 16, 9, 5, 18, 19, 23, 12, 14, 8, 4, 2, 6, 10, 7, 25, 11, 20, 17, 3, 24, 15 };

        private byte[] Reflector   = {  0,  25,  19,  14,  22,  17,  26, 15, 18, 21, 20, 24, 23, 16 };

        //public char[] RotorChoice4 = { '0', 'M', 'Q', 'C', 'A', 'P', 'Z', 'J', 'V', 'L', 'K', 'X', 'S', 'G', 'F', 'Y', 'E', 'U', 'T', 'N', 'I', 'D', 'O', 'B', 'H', 'R', 'W' };
        public byte[] RotorChoice4 = { 0, 13, 17, 3, 1, 16, 26, 10, 22, 12, 11, 24, 19, 7, 6, 25, 5, 21, 20, 14, 9, 4, 15, 2, 8, 18, 23 };
        //public char[] RotorChoice5 = { '0', 'H', 'G', 'B', 'A', 'C', 'Q', 'E', 'Z', 'X', 'D', 'R', 'M', 'P', 'K', 'V', 'T', 'Y', 'S', 'L', 'N', 'U', 'F', 'W', 'J', 'I', 'O' };
        public byte[] RotorChoice5 = { 0, 8, 7, 2, 1, 3, 17, 5, 26, 24, 4, 18, 13, 16, 11, 22, 20, 25, 19, 12, 14, 21, 6, 23, 10, 9, 15 };


        private byte[] Rotor1;
        private byte[] Rotor2;
        private byte[] Rotor3;

       
        private char[] KeyBoadKey =   { '?', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        
        // The default rotors in 1,2,3
        public Encryption(byte rotorPlacement1Number = 1, byte rotorPlacement2Number = 2, byte rotorPlacement3Number = 3, byte positionRotor1 = 1, byte positionRotor2 = 1, byte positionRotor3 = 1) 
        {
            PlaceMainRotorInMachine(rotorPlacement1Number, 1);
            PlaceMainRotorInMachine(rotorPlacement2Number, 2);
            PlaceMainRotorInMachine(rotorPlacement3Number, 3);

            this.PositionRotor1 = positionRotor1;
            this.PositionRotor2 = positionRotor2;
            this.PositionRotor3 = positionRotor3;
        }

        public char EncryptCharacter(byte charNumberInAlphabet) 
        {
            //you need to understand that the right side of the rotors is fixed ex: we have a 4 letter rotors:
            // the reflector makes a circle 

            //	   reflector ||   	rotor 3  		||	    rotor 2		  ||	    rotor 1
            //				 ||	 left ----- right   ||  left ----- right  ||    left ----- right
            //			 	 ||					    ||                    ||
            //		D <-- B	 ||		B ----- A	  	|| 	   A ----- A	  || 	(3) C ----- A (1)
            //		C <-- A	 ||		A ----- B	  	||     D ----- B	  || 	(4) D ----- B (2)
            //		A <-- C	 ||		C ----- C		||     B ----- C	  || 	(1) A ----- C (3)
            //		B <-- D	 ||		D ----- D		||	   C ----- D	  ||	(2 )B ----- D (4)


            // switch letter if it is changed in the plugboard

            byte letterAfterPlugBoard = SwitchLetterFromPlugBoard(charNumberInAlphabet);

            // the letterAfterPlugBoard go into rotor and out as another letter
            short insideRotor1KeyIndex = Rotor1[letterAfterPlugBoard];

            // we get what letter is facing the output from rotor1 in rotor2 (alignment only)
            short indexThatMatchRotor1InRotor2 = MatchingBetweenRotors(PositionRotor1, PositionRotor2, insideRotor1KeyIndex);
            // the letter that goes out from rotor2 
            short insideRotor2KeyIndex = Rotor2[indexThatMatchRotor1InRotor2];

            // we get what letter is facing the output from rotor2 in rotor3 (alignment only)
            short indexThatMatchRotor2InRotor3 = MatchingBetweenRotors(PositionRotor2, PositionRotor3, insideRotor2KeyIndex);
            // the letter that goes out from rotor3 
            short insideRotor3KeyIndex = Rotor3[indexThatMatchRotor2InRotor3];

            // form insideRotor3KeyIndex to reflector output
            short outOfReflectorIndexOnRotor3 = insideRotor3KeyIndex <= 13 ? Reflector[insideRotor3KeyIndex] : (short)Array.IndexOf(Reflector, (byte)insideRotor3KeyIndex);

            // the letter that goes out from rotor3 
            short insideRotor3KeyIndexBack = (short)Array.IndexOf(Rotor3, (byte)outOfReflectorIndexOnRotor3);

            

            // we get what letter is facing the output from rotor3 in rotor2 (alignment only)
            short indexThatMatchRotor3InRotor2 = MatchingBetweenRotors(PositionRotor3, PositionRotor2, insideRotor3KeyIndexBack);
            // the letter that goes out from rotor2 
            short insideRotor2KeyIndexBack = (short)Array.IndexOf(Rotor2, (byte)indexThatMatchRotor3InRotor2);

            // we get what letter is facing the output from rotor2 in rotor1(alignment only)
            short indexThatMatchRotor2InRotor1 = MatchingBetweenRotors(PositionRotor2, PositionRotor1, insideRotor2KeyIndexBack);

            // the letter that goes out from rotor1 
            short insideRotor1KeyIndexBack = (short)Array.IndexOf(Rotor1, (byte)indexThatMatchRotor2InRotor1);

            // switch letter if it is changed in the plugboard
            short letterAfterPlugBoardFinal = SwitchLetterFromPlugBoard((byte)insideRotor1KeyIndexBack);

            return KeyBoadKey[letterAfterPlugBoardFinal];
        }

        // the PositionRotor1,2,3 represents the current position of rotor
        // this will tell us each time what index of rotor is facing the adjacent rotor index
        // ex: if PositionRotor1 = 5 and PositionRotor2 = 22 
        // what index is facing ex: 20 in PositionRotor1 on the PositionRotor2 ?
        private short MatchingBetweenRotors(byte fromRotorIndex, byte toRotorIndex, short keyIndex)  
         {
            
             if (fromRotorIndex > keyIndex)
            {
                short stepsToMatch = (short)(fromRotorIndex - keyIndex);

                if (stepsToMatch - toRotorIndex == 0) return 26;

                if (stepsToMatch < toRotorIndex)
                {
                    return (short)(toRotorIndex - stepsToMatch);
                }
                else
                {
                    return (short)(26 - (stepsToMatch - toRotorIndex));
                }
            }
            else if (fromRotorIndex < keyIndex) 
             {
                short stepsToMatch = (short)(keyIndex - fromRotorIndex);

                if (stepsToMatch <= (26 - toRotorIndex))
                {
                    return (short)(toRotorIndex + stepsToMatch);
                }
                else
                {
                    return (short)(stepsToMatch - (26 - toRotorIndex));
                }
            }
            
            return toRotorIndex;
        }

        
        public void PlaceMainRotorInMachine(byte rotorChoice, byte rotorPlace ) 
        {
            if (rotorPlace == 1) 
            {
                switch (rotorChoice) 
                { 
                    case 1:
                        Rotor1 = RotorChoice1;
                        break;
                    case 2:
                        Rotor1 = RotorChoice2;
                        break;
                    case 3:
                        Rotor1 = RotorChoice3;
                        break;
                    case 4:
                        Rotor1 = RotorChoice4;
                        break;
                    case 5:
                        Rotor1 = RotorChoice5;
                        break;
                    default:
                        Rotor1 = RotorChoice1;
                        break;
                }
            }
            else if(rotorPlace == 2) 
            {
                switch (rotorChoice)
                {
                    case 1:
                        Rotor2 = RotorChoice1;
                        break;
                    case 2:
                        Rotor2 = RotorChoice2;
                        break;
                    case 3:
                        Rotor2 = RotorChoice3;
                        break;
                    case 4:
                        Rotor2 = RotorChoice4;
                        break;
                    case 5:
                        Rotor2 = RotorChoice5;
                        break;
                    default:
                        Rotor2 = RotorChoice2;
                        break;
                }
            }
            else if (rotorPlace == 3)
            {
                switch (rotorChoice)
                {
                    case 1:
                        Rotor3 = RotorChoice1;
                        break;
                    case 2:
                        Rotor3 = RotorChoice2;
                        break;
                    case 3:
                        Rotor3 = RotorChoice3;
                        break;
                    case 4:
                        Rotor3 = RotorChoice4;
                        break;
                    case 5:
                        Rotor3 = RotorChoice5;
                        break;
                    default:
                        Rotor3 = RotorChoice2;
                        break;
                }
            }

        }

        
        // If a letter exists as a key or value in SwitchedLetterPairsInPlugBoard, swap it.
        private byte SwitchLetterFromPlugBoard(byte letterIndex) 
        {
            if (SwitchedLetterPairsInPlugBoard.ContainsKey(letterIndex))
            {
                return SwitchedLetterPairsInPlugBoard[letterIndex];
            }
                foreach (var plugBoardControl in SwitchedLetterPairsInPlugBoard)
                {
                    if (plugBoardControl.Value == letterIndex)
                    {
                    return plugBoardControl.Key;

                    }
                }
            return letterIndex;
        }
        
    }
}
