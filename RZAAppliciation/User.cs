using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZAAppliciation
{
    // Used for storing the user information when the user logs into their account
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password_ { get; set; }
        public string Email { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean IsTwoFA {  get; set; }
        public string MemberType {  get; set; }
        public int MemberStreak {  get; set; }
        public int Points { get; set; }
        public string HomeAddress { get; set; }

        public User(int userID, string username, string password_, string email, string firstName, string lastName, bool isTwoFA, string memberType, int memberStreak, int points, string homeAddress)
        {
            UserID = userID;
            Username = username;
            Password_ = password_;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsTwoFA = isTwoFA;
            MemberType = memberType;
            MemberStreak = memberStreak;
            Points = points;
            HomeAddress = homeAddress;
        }
        public User()
        {

        }
    }
}
