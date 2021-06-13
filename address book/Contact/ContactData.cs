using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName && LastName == other.LastName);
        }

        public int CompareTo(ContactData other)
        {
            if(ReferenceEquals(other, null))
            {
                return 1;
            }
            if(LastName != other.LastName)
            {
                return LastName.CompareTo(other.LastName);
            }
            if (LastName == other.LastName && FirstName != other.FirstName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return 0;
        }
    }
}
