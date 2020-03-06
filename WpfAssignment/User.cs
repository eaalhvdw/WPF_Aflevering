using System.Collections.Generic;
using System.IO;

namespace WpfAssignment
{
    public class User
    {
        /* 
         * Constructor takes a string as argument 
         * in the format: id;name;age;score.
         */
        public User(string str)
        {
            var result = str.Split(';');
            Id = int.Parse(result[0]);
            Name = result[1];
            Age = int.Parse(result[2]);
            Score = int.Parse(result[3]);
        }

        // Properties.
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Score { get; set; }

        /*
         * ToString method for ListBox only 
         * shows id and name of user objects.
         */
        public string ListBoxToString
        {
            get
            {
                return "Id: " + Id + "\t\tName: " + Name;
            }
        }

        /*
         * This method takes a filename(filepath) and 
         * reads the file line by line. A user object 
         * is created for each line and all user objects 
         * are saved in a list.
         * Returns a list of user objects.
         */
        public static List<User> ReadCSVFile(string filename)
        {
            List<User> usersRead = new List<User>();

            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var u = new User(line);
                    usersRead.Add(u);
                }
            }
            return usersRead;
        }
    }
}
