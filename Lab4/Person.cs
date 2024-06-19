using System;

namespace MyLibrary
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
        public DateTime BirthDate => _birthDate;

        public override string ToString()
        {
            return $"{_firstName} {_lastName}, Born: {_birthDate.ToShortDateString()}";
        }
    }
}
