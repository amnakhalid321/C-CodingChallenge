

/*
 *  Name: Amna Khalid
 *  C# Coding Challenge
 * 
 * 
 * */

using System;
using System.Collections.Generic;
using System.Text;

public class OldPhonePadDecoder
{
    private static readonly Dictionary<char, string> Keypad = new Dictionary<char, string>
    {
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"}
    };

    public static string OldPhonePad(string input)
    {
        StringBuilder result = new StringBuilder();  //This variable is used to store the final input
        StringBuilder stringblock = new StringBuilder(); //This variable is used to store the  digites which is  input from user to which furthere action is applied
        bool endedWithHash = false;

        foreach (char ch in input) //this loop  will execute all characters of input
        {
            if (ch == '#') // To check that if any # comes in the input means that end of input and call the function to convert it to character and  break the loop return the output
            {
                StringBlock(stringblock, result);
                endedWithHash = true;
                break;
            }
            else if (ch == '*') // if * comes then it mean we need to do backspace in the input  first convert input into character and then  remove it in  final output
            {
                if (stringblock.Length > 0)
                {
                    StringBlock(stringblock, result);
                    stringblock.Clear();
                }
                if (result.Length > 0)
                {
                    result.Length--;
                }
            }
            else if (ch == ' ') //if  '' comes in the input means there is a pause  before starting new input and convert previous input into output
            {
                StringBlock(stringblock, result);
            } 
            else if (char.IsDigit(ch)) //if digit comes then first we need to check either it is first charatcer  input then we will append in a string block  and do it for same  digits input.
            {
                if (stringblock.Length == 0 || stringblock[0] == ch)
                {
                    stringblock.Append(ch);
                }
                else   //if different difit comes then convert it to putput and clear the string and append new different digit in string block
                {
                    StringBlock(stringblock, result);
                    stringblock.Clear();
                    stringblock.Append(ch);
                }
            }
            // else ignore unknown characters, or you can handle them if needed
        }

        if (!endedWithHash) //if the input is not ending  with # the we nend to convert the stringblock in to output
        {
            StringBlock(stringblock, result);
        }

        return result.ToString();
    }
     //This is main function that will actually get the  letters from dictioanry against input and then  retireve the specific character  from letters and append it into final output.
    private static void StringBlock(StringBuilder stringblock, StringBuilder result)
    {
        if (stringblock.Length == 0)
            return;

        char key = stringblock[0];
        if (!Keypad.TryGetValue(key, out string letters))
            return;

        int presses = stringblock.Length;
        int index = (presses - 1) % letters.Length;
        result.Append(letters[index]);

        stringblock.Clear();
    }

    public static void Main()
    {

        string[] testInputs = {
                "2#",
                "7777 666 555 3#",
                "7777*77 666#",
                "33#",
                "22**#",
                "44 444* 33#",
                "7777 666 88 7777 33 3 1111",
                "7a7 6!6#",
                "",
                "2 2#3 3#",
                "222 2 22",
                "8 88777444666*664#",
                "#543534534*",
                 "7777777#",        
                "77777777#",       
                "2 22 222 2222#",  
                "9 99 999 9999#",   
                "*#",              
                "2*2#",             
                "2 3 4 5 6 7 8 9#", 
                "22 33 44 55 66 77 88 99#", 
                "#",              
                "**2#",             
                "2 2 2*2*2#",      
                "000#",           
                "1 1 1#",           
                "2 3 4*#",         
                "22 33* 44#",      
                "23456789#",        
                "777*7777#",        
                "222222222#",       
                "234 23 4 2 3 4#",  
                "99999*999#",       
                "2*3*4*#",          
                "   #",             
                    };

        foreach (var input in testInputs)
        {
            Console.WriteLine($"Input: {input} => Output: {OldPhonePad(input)}");
        }


        /********* Final Output *********************/

        //Input: 222 2 22 => Output: CAB
        //Input: 8 88777444666 * 664# => Output: TURING
        //Input: #543534534* => Output:
        //Input: 7777777# => Output: R
        //Input: 77777777# => Output: S
        //Input: 2 22 222 2222# => Output: ABCA
        //Input: 9 99 999 9999# => Output: WXYZ
        //Input: *# => Output:
        //Input: 2 * 2# => Output: A
        //Input: 2 3 4 5 6 7 8 9# => Output: ADGJMPTW
        //Input: 22 33 44 55 66 77 88 99# => Output: BEHKNQUX
        //Input: # => Output:
        //Input: **2# => Output: A
        //Input: 2 2 2 * 2 * 2# => Output: AAA
        //Input: 000# => Output:
        //Input: 1 1 1# => Output:
        //Input: 2 3 4 *# => Output: AD
        //Input: 22 33 * 44# => Output: BH
        //Input: 23456789# => Output: ADGJMPTW
        //Input: 777 * 7777# => Output: S
        //Input: 222222222# => Output: C
        //Input: 234 23 4 2 3 4# => Output: ADGADGADG
        //Input: 99999 * 999# => Output: Y
        //Input: 2 * 3 * 4 *# => Output:
        //Input:    # => Output:
    }
}
