using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Instagram.App
{
   public static class HelperData 
    {        
        public static string Generate(bool IsEmail)
        {
            string Generate_;
            string input = "qwertyuiopasdfghjklzxcvbnm";
            input += input.ToUpper();
            Random random = new Random();
            Generate_ = new string(Enumerable.Repeat(input, random.Next(1,6))
                .Select(item => item[random.Next(random.Next(1,input.Length))]).ToArray());
            if (IsEmail)
                return Generate_+random.Next(1,99999) + "@gmail.com";
            else
                return Generate_+ random.Next(1, 99999);

        }
        public static ObservableCollection<SignupViewModel> CollectionOfSignup(string Username,string Email,string Password)
        {
            var collection = new ObservableCollection<SignupViewModel>();
             collection.Add(new SignupViewModel()
            {
                Username = Username,
                Email = Email,
                Password = Password
            });
            return collection;
      
        }
    }
}
