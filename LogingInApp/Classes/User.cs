using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingInApp.Classes
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }
        public int AddressId { get; set; }
        [JsonIgnore]
        public IList<User> AllUsers { get; set; }

        private const string _path = @"C:\Users\Nikola\Desktop\LogingInApp\LogingInApp\Data\users.json";

        public User()
        {

        }

        public User(int iD, string name, string email, int age, int roleId, int addressId)
        {
            ID = iD;
            Name = name;
            Email = email;
            RoleId = roleId;
            AddressId = addressId;
        }

        public int SaveUser(string _name, string _email, int age ,int  _roleId, int _addressId)
        {
            var list = new List<User>();

            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<User>>(json);
            }
            try
            {
                int id = list.Count > 0 ? list.LastOrDefault().ID + 1 : 1;
                var user = new User(id, _name, _email, age, _roleId, _addressId);
                list.Add(user);
                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);

                return id;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public User GetUser(int userId)
        {
            var user = AllUsers.Where(x => x.ID == userId).FirstOrDefault();
            return user;
        }

        public IList<User> GetUserList(string name = "")
        {
            if (AllUsers == null) _getAllUsers();
            return AllUsers.Where(x => x.Name.ToLower().Contains(name)).ToList();
        }

        private void _getAllUsers()
        {
            using (StreamReader file = File.OpenText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                var list = (List<User>)serializer.Deserialize(file, typeof(List<User>));
                AllUsers = list;
            }
        }
    }
}
