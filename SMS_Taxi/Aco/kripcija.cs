using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS_Taxi.Aco
{
    class varS
    {
        // <#><☁> SEPARATOR

        public static char[] simboli = { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H', 'i', 'I', 'j', 'J'
                                      , 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'o', 'O', 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T'
                                      , 'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X', 'y', 'Y', 'z', 'Z', 'ć', 'Ć', 'č', 'Č', 'š', 'Š', 'ž', 'Ž'
                                      , ' ', '.', '/', ':', '-', '!', '?', ';', '+', '-', '*', '>', '<', ',' , '#', '\\', '_', '@'
                                      , '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        public static char[] kodovi = { '♔', '♕', '♖', '♗', '♘', '♙', '♚', '♛', '♜', '♝', '≫', '∀', '∃', '∄', '¬', '∆', '∈', '∉', '∋', '∌'
                                     , '⊂', '⊃', '⊄', '⊆', '⊅', '⊇', '∏', '∑', 'Ω', '±', '÷', '∅', '≪', '∗', '∂', '∛', '∜', '∝', '∞', '∁'
                                     , '∠', '∡', '∦', '⊕', '⊗', '∫', '¡', '¿', 'Á', 'æ', 'á', 'Ç', 'É', 'ç', 'é', '¥', 'ℚ', '€', '£', 'ℝ'
                                     , '≝', '≞', '≟', '≚', '≊', '℗', '♭', '♮', '♯', '♩', '☊', '♒', '☄', '✆', '#', 'W', 'Q', 'Đ'
                                     , '☢', '☤', '✝', '☦', '✒', '✑', '◆', '✵', '❆', '✉'};
    
    }
    class kripcija
    {
        private string[] input;
        private string[] output; public string[] getOut() { return output; }

        public kripcija() { }
        public kripcija(string[] a)
        {
            input = a;
        }
        public kripcija(string a)
        {
            input = new string[1];
            input[0] = a;
        }
        public string[] unos(string[] a)
        {
            input = a;
            enter();
            return output;

        }
        public string[] unos(string a)
        {
            input = new string[1];
            input[0] = a;
            enter();
            return output;
        }


        private void enter()
        {
            output = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = obrada(input[i]);
            }
        }
        private string obrada(string a)
        {
            string back = "";
            for (int i = 0; i < a.Length; i++)
            {
                for (int ii = 0; ii < varS.simboli.Length; ii++)
                {
                    if (a[i] == varS.simboli[ii])
                    {
                        back += varS.kodovi[ii].ToString();
                        break;
                    }
                }
            }
            return back;
        }        
    }
    class dekripcija
    {
        private string[] input;
        private string[] output; public string[] getOut() { return output; }

        public dekripcija() { }
        public dekripcija(string[] a)
        {
            input = a;
        }
        public dekripcija(string a)
        {
            input = new string[1];
            input[0] = a;
        }
        public string[] unos(string[] a)
        {
            input = a;
            enter();
            return output;

        }
        public string[] unos(string a)
        {
            input = new string[1];
            input[0] = a;
            enter();
            return output;
        }
        private void enter()
        {
            output = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = obrada(input[i]);
            }
        }
        private string obrada(string a)
        {
            string back = "";
            for (int i = 0; i < a.Length; i++)
            {
                for (int ii = 0; ii < varS.kodovi.Length; ii++)
                {
                    if (a[i] == varS.kodovi[ii])
                    {
                        back += varS.simboli[ii].ToString();
                        break;
                    }
                }
            }
            return back;
        }
    }
}
