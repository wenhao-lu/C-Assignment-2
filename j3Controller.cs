using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WenhaoLu_Assign1.Controllers
{
    public class j3Controller : ApiController
    {
        /// <summary>
        /// j3 - Cell-Phone Messaging (CCC)
        /// GET: api/j3/PhoneSms/{message}
        /// </summary>
        /// <param name="message">user string input</param>
        /// <returns>the total time using phone message(typing time plus pause time)</returns>
        /// <example>
        /// api/j3/PhoneSms/abba   ->     12
        /// </example>
        [HttpGet]
        [Route("api/j3/PhoneSms/{message}")]
        public int Get(string message)
        {

            // sort the characters by the number of times pressing the button
            // when input characters in array.firstLetter, that means Joe only needs to press the button for one time (one time counts one second)
            // when input characters in array.secondLetter, that means Joe needs to press the button twice
            // eg. Joe needs to press three times to type the character 'c', which would take 3 seconds
            char[] firstLetter = { 'a', 'd', 'g', 'j', 'm', 'p', 't', 'w' };
            char[] secondLetter = { 'b', 'e', 'h', 'k', 'n', 'q', 'u', 'x' };
            char[] thirdLetter = { 'c', 'f', 'i', 'l', 'o', 'r', 'v', 'y' };
            char[] fourthLetter = { 's', 'z' };


            // define variables 
            // smsLength is the length of input string, will be used in loops, counting the repeats
            // timeCount is the time used when pressing the specific button, eg. press 's' counts for 4 seconds
            // letterSum is the total time when typing all the letters (excludes pause time)
            int smsLength = message.Length;
            int timeCount = 0;
            int letterSum = 0;

            //  a loop for checking the characters one-by-one from user's input letter, then calculate the total time of typing letters  
            for (int i = 0; i <= smsLength - 1; i++)
            {

                // check where the character locates (in four character arrays above)
                // from the first character to the last, one by one
                char smsLetter = message[i];
                int firstLetterIdx = Array.IndexOf(firstLetter, smsLetter);
                int secondLetterIdx = Array.IndexOf(secondLetter, smsLetter);
                int thirdLetterIdx = Array.IndexOf(thirdLetter, smsLetter);
                int fourthLetterIdx = Array.IndexOf(fourthLetter, smsLetter);

                // if the input is "halt", then exit this application
                if (message == "halt")
                {
                    break;
                }


                // the input character should have an index number from the array, if not, then means the character doesn't exist in the array 
                // when the input character locates in the firstLetter array, then count the pressing button time for 1 second
                // when the input character locates in the secondLetter array, then count the pressing button time for 2 seconds
                if (firstLetterIdx > -1)
                {
                    timeCount = 1;
                }
                else if (secondLetterIdx > -1)
                {
                    timeCount = 2;
                }
                else if (thirdLetterIdx > -1)
                {
                    timeCount = 3;
                }
                else if (fourthLetterIdx > -1)
                {
                    timeCount = 4;
                }


                // add up every character's timeCount to total time
                letterSum = letterSum + timeCount;
            }


            // a section to count the pause time
            // sort the characters by the position, eg. 'a', 'b', 'c' all locate on the phone button "2"
            // when typing characters that are on the same phone button, user needs to pause 2 seconds for the interval
            // eg. when typing 'a', user has to press phone button '2' one time first, 
            // then wait (pause) for 2 seconds to press phone button '2' twice times to get 'b'

            char[] secondKeyLetter = { 'a', 'b', 'c' };
            char[] thirdKeyLetter = { 'd', 'e', 'f' };
            char[] fourthKeyLetter = { 'g', 'h', 'i' };
            char[] fifthKeyLetter = { 'j', 'k', 'l' };
            char[] sixthKeyLetter = { 'm', 'n', 'o' };
            char[] seventhKeyLetter = { 'p', 'q', 'r', 's' };
            char[] eighthKeyLetter = { 't', 'u', 'v' };
            char[] ninethKeyLetter = { 'w', 'x', 'y', 'z' };


            // define variables 
            // pauseLetter is the time used when typing characters on the same button
            // eg. press 'g' one time, then pause 2 seconds, and then press the button twice to get 'h'
            // pauseSum is the total pause time
            int pauseLetter = 0;
            int pauseSum = 0;

            //  a loop for checking the two adjacent characters to see if they locate on the same button
            //  if they are on the same button, then will count the pause time for 2 seconds  
            for (int j = 1; j <= smsLength - 1; j++)
            {
                // smsLetterFirst is the first character of the input string
                // smsLetterNext is the next character of the input string (adjacent character)
                // set initial value of j to 1, in order to avoid the array value exceeding error
                char smsLetterFirst = message[j - 1];
                char smsLetterNext = message[j];

                // check if they locate in the same character array (in eight character arrays above) 
                int letterKeyTwoFirst = Array.IndexOf(secondKeyLetter, smsLetterFirst);
                int letterKeyTwoNext = Array.IndexOf(secondKeyLetter, smsLetterNext);
        
                int letterKeyThreeFirst = Array.IndexOf(thirdKeyLetter, smsLetterFirst);
                int letterKeyThreeNext = Array.IndexOf(thirdKeyLetter, smsLetterNext);
                
                int letterKeyFourFirst = Array.IndexOf(fourthKeyLetter, smsLetterFirst);
                int letterKeyFourNext = Array.IndexOf(fourthKeyLetter, smsLetterNext);
                
                int letterKeyFiveFirst = Array.IndexOf(fifthKeyLetter, smsLetterFirst);
                int letterKeyFiveNext = Array.IndexOf(fifthKeyLetter, smsLetterNext);
                
                int letterKeySixFirst = Array.IndexOf(sixthKeyLetter, smsLetterFirst);
                int letterKeySixNext = Array.IndexOf(sixthKeyLetter, smsLetterNext);
                
                int letterKeySevenFirst = Array.IndexOf(seventhKeyLetter, smsLetterFirst);
                int letterKeySevenNext = Array.IndexOf(seventhKeyLetter, smsLetterNext);
                
                int letterKeyEightFirst = Array.IndexOf(eighthKeyLetter, smsLetterFirst);
                int letterKeyEightNext = Array.IndexOf(eighthKeyLetter, smsLetterNext);
                
                int letterKeyNineFirst = Array.IndexOf(ninethKeyLetter, smsLetterFirst);
                int letterKeyNineNext = Array.IndexOf(ninethKeyLetter, smsLetterNext);

                // the adjacent input characters should have index numbers from the same array 
                // when the adjacent input characters are in the array (on the same button), then count the pause time for 2 seconds
                // check on eight phone buttons 
                if (letterKeyTwoFirst > -1 && letterKeyTwoNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeyThreeFirst > -1 && letterKeyThreeNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeyThreeFirst > -1 && letterKeyThreeNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeyFourFirst > -1 && letterKeyFourNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeyFiveFirst > -1 && letterKeyFiveNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeySixFirst > -1 && letterKeySixNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeySevenFirst > -1 && letterKeySevenNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeyEightFirst > -1 && letterKeyEightNext > -1)
                {
                    pauseLetter = 2;
                }
                else if (letterKeyNineFirst > -1 && letterKeyNineNext > -1)
                {
                    pauseLetter = 2;
                }

                // adding up to total pause time
                pauseSum = pauseSum + pauseLetter;
            }

            // total Phone Messaging time = typing time + pause time
            int timeSum = letterSum + pauseSum;
            return timeSum;

        }
     

    }
}
