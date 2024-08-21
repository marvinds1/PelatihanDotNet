using Services.Dtos;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserManagement.UserInterfaces
{
    public static class AdminPage
    {
        private static LoginService loginService = LoginService.Instance;
        private static MemberService memberService = MemberService.Instance;
        private static LoginInfo loginInfo = loginService.GetLoginInfo();

        private static List<string> options = new List<string>()
        {
            "Add member account",
            "Disable member account",
            "Show Other Account (Member)",
            "Manage Password",
            "Logout"
        };

        public static void Start()
        {
            while (loginInfo.IsLoggedIn)
            {
                var choice = Helpers.GetChoice(options);

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter member username:");
                            var username = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine("Enter member password:");
                            var password = Console.ReadLine();

                            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                                continue;

                            memberService.AddNewMember(username, password);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter member username:");
                            var username = Console.ReadLine();
                            Console.WriteLine();

                            memberService.DisableMember(username);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 3:
                        try
                        {
                            memberService.GetAllUsername();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 4:
                        try
                        {
                            memberService.ManagePassword(loginInfo.Username);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    default:
                        loginService.Logout();
                        Console.WriteLine("You've logged out.");
                        break;
                }
            }
        }
    }
}
