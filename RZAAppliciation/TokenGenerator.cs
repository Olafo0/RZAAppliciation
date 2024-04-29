using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace RZAAppliciation
{
    public class TokenGenerator
    {


        // Used to generate the verification token which is sent out to the users email
        public static string VerificationToken()
        {

            string[] characters = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
            "0","1","2","3","4","5","6","7","8","9","%","$","!","+" };
        
            StringBuilder token = new StringBuilder();

            for(int i = 0; i < 9; i++)
            {
                Random randomCharacter = new Random();
                
                string charaFromList = characters[randomCharacter.Next(characters.Length)];
                
                token.Append(charaFromList);
            }
            return token.ToString();
        }

        // Used to generate the reference token when a user books an order
        public static string ReferenceGenerator(string OrderType, int ticketID)
        {
            string[] characters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", };

            string tokenGenerated = "";

            if(OrderType == "Zoo")
            {
                Random random = new Random();

                string numberGenerated = Convert.ToString(random.Next(0, 999));
                string characterGenerated = characters[random.Next(characters.Length)];

                tokenGenerated = $"ZOT{ticketID}{numberGenerated}{characterGenerated}";

                
            }
            if (OrderType == "Hotel")
            {
                Random random = new Random();

                string numberGenerated = Convert.ToString(random.Next(0, 999));
                string characterGenerated = characters[random.Next(characters.Length)];

                tokenGenerated = $"HOT{ticketID}{numberGenerated}{characterGenerated}";
            }



            return tokenGenerated;
        }

    }
}
