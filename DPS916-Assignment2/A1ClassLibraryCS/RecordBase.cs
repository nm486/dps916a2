/*   DPS916 - Visual Basic Course
 *   Coded By: Raymond Hung and Stanley Tsang
 *   Assignment 1
 *   RecordBase.cs
 *   Last Modified February 20 2013
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace A1ClassLibraryCS
{
    // Base class for Records used in Address Books.  This is the minimum requirement for Assignment 1
    public abstract class RecordBase
    {
        protected string userName;
        protected List<string> emailAddresses;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z.,' ]+$"))
                {
                    userName = value;
                }
                else
                {
                    throw new ArgumentException("User name can only have alphabet, space, period, comma, or apostrophe characters.");
                }
            }
        }

        public List<string> EmailAddresses
        {
            get
            {
                return emailAddresses;
            }
            set
            {
                emailAddresses = value;
            }
        }

        // If we ever need to implement the changing of email order in our collection, then this function can do that for us.
        public void changeEmailOrder(int sourceIndex, int destinationIndex)
        {
            if (sourceIndex < emailAddresses.Count || destinationIndex <= emailAddresses.Count)
            {
                string email = emailAddresses[sourceIndex];
             
                if (sourceIndex > destinationIndex)
                {
                    emailAddresses.Insert(destinationIndex, email);
                    emailAddresses.RemoveAt(sourceIndex + 1);
                }
                else
                {
                    emailAddresses.Insert(destinationIndex + 1, email);
                    emailAddresses.RemoveAt(sourceIndex);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
