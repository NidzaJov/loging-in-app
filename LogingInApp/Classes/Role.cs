using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingInApp.Classes
{
    class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Role> AllRoles { get; set; }

        private static string projectDirectoryPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9);

        private readonly string _path = Path.Combine(projectDirectoryPath, @"Data\roles.json");
        public Role()
        {

        }

        public Role(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public int SaveRole(string name)
        { 
            IList<Role> list = new List<Role>();
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<Role>>(json);
            }
            else
            {
                throw new FileNotFoundException($"File on path {_path} does not exist");
            }
            try
            {
                int id = list.Count > 0 ? list.Count + 1 : 1;
                Role role = new Role(id, name);
                list.Add(role);
                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);

                return id;
            } catch (Exception ex)
            {
                return 0;
            }
        }

        public void GetAllRoles()
        {
            var list =  new List<Role> ();
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<Role>>(json);
            }
            else
            {
                throw new FileNotFoundException($"File on path {_path} does not exist");
            }

            AllRoles =  list;
        }

        public Role GetRole(int id)
        {
            if (AllRoles == null) GetAllRoles();
            Role role = AllRoles.Where(r => r.ID == id).FirstOrDefault();

            return role;
        }

        public bool EditRole(int id, Role editedRole)
        {
            var list = new List<Role>();
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<Role>>(json);
            }
            else
            {
                throw new FileNotFoundException($"File on path {_path} does not exist");
            }
            try
            {
                var index = list.FindIndex(r => r.ID == id);
                list.RemoveAt(index);
                list.Insert(index, editedRole);
                if (File.Exists(_path))
                {
                    string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(_path, serializedJson);
                }
                else
                {
                    throw new FileNotFoundException($"File on path {_path} does not exist");
                }

                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRole(int id)
        {
            if (AllRoles == null) GetAllRoles();
            try
            {
                var index = AllRoles.FindIndex(r => r.ID == id);
                AllRoles.RemoveAt(index);
                if (File.Exists(_path))
                {
                    string serializedJson = JsonConvert.SerializeObject(AllRoles, Formatting.Indented);
                    File.WriteAllText(_path, serializedJson);
                }
                else
                {
                    throw new FileNotFoundException($"File on path {_path} does not exist");
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<Role> GetRolesList(string name)
        {
            if (AllRoles == null) GetAllRoles();
            return AllRoles.Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }

    }
}
