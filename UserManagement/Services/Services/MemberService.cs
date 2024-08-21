using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MemberService
    {
        public readonly static MemberService Instance = new MemberService();
        private readonly UserRepository userRepository = UserRepository.Instance;

        static MemberService() { }

        public void AddNewMember(string username, string password)
        {
            var newMember = new Member()
            {
                Username = username,
                Password = password
            };

            userRepository.Save(newMember);
        }

        public void DisableMember(string username)
        {
            var userToDisable = userRepository.GetByUsername(username);

            if (userToDisable is null || userToDisable is not Member)
                return;

            var user = (Member)userToDisable;
            user.IsDisabled = true;
            userRepository.Save(user);
        }

        public void GetAllUsername()
        {
            var members = userRepository.GetAll().OfType<Member>();
            Console.WriteLine();
            Console.WriteLine("List Account:");
            foreach (var member in members)
            {
                Console.WriteLine(member.Username);
            }
        }
        
        public void ManagePassword(string Username)
        {
            var NewPassword = "";
            var NewPassword1 = "%%%%%%%%%%%%%%%%%";
            Boolean tes = false;
            while(NewPassword != NewPassword1)
            {
                Console.WriteLine();
                if (tes)
                {
                    Console.WriteLine("PASSWORD YANG DIBERIKAN TIDAK SESUAI!!");
                    Console.WriteLine();
                }
                Console.WriteLine("Masukkan Password yang Baru:");
                NewPassword = Console.ReadLine();
                Console.WriteLine("Masukkan Password yang Baru:");
                NewPassword1 = Console.ReadLine();
                if (NewPassword == "")
                {
                    Console.WriteLine("Password tidak boleh kosong!");
                    NewPassword1 = "%%%%%%%%%%%%%%%%%";
                    continue;
                }
                tes = true;
            }

            if (NewPassword == NewPassword1)
            {
                
                var userToUpdate = userRepository.GetByUsername(Username);
                if (userToUpdate is null)
                    return;

                userToUpdate.Password = NewPassword;
                
                userRepository.Save(userToUpdate);
            }
        }
    }
}
