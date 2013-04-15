/*   DPS916 - Visual Basic Course
 *   Coded By: Raymond Hung and Stanley Tsang
 *   Assignment 1
 *   RecordA1.cs
 *   Last Modified February 20 2013
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ClassLibraryCS
{
    // Derived class of Record Base class; contains additional data members including phone number list, address list, and notes
    public class RecordA1 : RecordBase
    {
        private List<string> phoneNumbers;
        private List<string> addresses;
        private string notes;

        public RecordA1()
        {
            userName = String.Empty;
            emailAddresses = new List<string>();
            phoneNumbers = new List<string>();
            addresses = new List<string>();
            notes = String.Empty;
        }

        public List<string> PhoneNumbers
        {
            get
            {
                return phoneNumbers;
            }
            set
            {
                phoneNumbers = value;
            }
        }

        public List<string> Addresses
        {
            get
            {
                return addresses;
            }
            set
            {
                addresses = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        // If we ever need to implement the changing of phone number order in our collection, then this function can do that for us.
        public void changePhoneNumberOrder(int sourceIndex, int destinationIndex)
        {
            if (sourceIndex < phoneNumbers.Count || destinationIndex <= phoneNumbers.Count)
            {
                string phoneNumber = phoneNumbers[sourceIndex];          

                if (sourceIndex > destinationIndex)
                {
                    phoneNumbers.Insert(destinationIndex, phoneNumber);
                    phoneNumbers.RemoveAt(sourceIndex + 1);
                }
                else
                {
                    phoneNumbers.Insert(destinationIndex + 1, phoneNumber);
                    phoneNumbers.RemoveAt(sourceIndex);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        // If we ever need to implement the changing of address order in our collection, then this function can do that for us.
        public void changeAddressOrder(int sourceIndex, int destinationIndex)
        {
            if (sourceIndex < addresses.Count || destinationIndex < addresses.Count)
            {
                string address = addresses[sourceIndex];               

                if (sourceIndex > destinationIndex)
                {
                    addresses.Insert(destinationIndex, address);
                    addresses.RemoveAt(sourceIndex + 1);
                }
                else
                {
                    addresses.Insert(destinationIndex + 1, address);
                    addresses.RemoveAt(sourceIndex);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
