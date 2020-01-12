using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomPassword
{
    class PasswordModel
    {
        private readonly int _seed;

        private readonly Random _random;

        public PasswordModel(int seed)
        {
            _seed = seed;
            _random = new Random(_seed);
        }

        public ObservableCollection<PasswordClass> GetPassword(int num, int bits)
        {
            ObservableCollection<PasswordClass> passwords = new ObservableCollection<PasswordClass>();
            using(SHA256 sha256Hash = SHA256.Create())
            {
                for (int i = 0; i < num; i++)
                {
                    var temp1 = _random.Next(10000, 100000000);
                    var temp2 = _random.Next(100000, 100000000);
                    var temp3 = _random.Next(1000000, 100000000);
                    var temp4 = _random.Next(10000000, 100000000);
                    byte[] bytes = Encoding.UTF8.GetBytes(temp1.ToString() + @"http://zhihu.com/" + 
                                                          temp2.ToString() + @"https://docs.microsoft.com/zh-cn/?view=vs-2019" +
                                                          temp3.ToString() + @"https://docs.microsoft.com/zh-cn/dotnet/api/system.random?view=netframework-4.8" +
                                                          temp4.ToString());
                    var result = sha256Hash.ComputeHash(bytes);
                    var sBuilder = new StringBuilder();
                    for (int j = 0; j < result.Length; j++)
                    {
                        sBuilder.Append(result[i].ToString("x2"));
                    }
                    var sString = sBuilder.ToString();
                    sBuilder.Clear();
                    var mynum = sString.Substring(bits + _random.Next(0, sString.Length - bits - 9), 8);
                    Random random = new Random(Convert.ToInt32("0x" + mynum, 16));
                    for (int k = 0; k < bits; k++)
                    {
                        sBuilder.Append(PasswordClass.GetChar(random.Next(0, 64)));
                    }
                    passwords.Add(new PasswordClass() { Password = sBuilder.ToString() });
                }
            }
            
            return passwords;
        }
    }
}
