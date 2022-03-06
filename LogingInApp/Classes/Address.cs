using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingInApp.Classes
{
    class Address
    {
        public int ID { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int PostCode { get; set; }
        [JsonIgnore]
        public IList<Address> AllAddresses { get; set; }

        private const string _path = @"C:\Users\Nikola\Desktop\LogingInApp\LogingInApp\Data\addresses.json";

        public Address()
        {

        }

        public Address(int iD, string streetAddress, string city, int countryId, int postCode)
        {
            ID = iD;
            StreetAddress = streetAddress;
            City = city;
            CountryId = countryId;
            PostCode = postCode;
        }

        public int SaveAddress(string _street, string _city, int _postCode, int _countryId)
        {
            var list = new List<Address>();

            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<Address>>(json);
            }

            try
            {
                int id = list.Count > 0 ? list.LastOrDefault().ID + 1 : 1;
                Address address = new Address(id, _street, _city , _postCode, _countryId);
                list.Add(address);
                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IList<Address> FilterAddress(string _adress)
        {
            if (AllAddresses == null) _getAllAddresses();
            var list = AllAddresses.Where(x => x.StreetAddress.ToLower().Contains(_adress)).ToList();
            return list;
        }

        private void _getAllAddresses()
        {
            var list = new List<Address>();
            using (StreamReader file = File.OpenText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                list = (List<Address>)serializer.Deserialize(file, typeof(List<Address>));
                AllAddresses = list;
            };
        }
    }
}
