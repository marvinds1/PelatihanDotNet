using Services.Dtos;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserManagement.UserInterfaces
{
    public static class MemberPage
    {
        private static LoginService loginService = LoginService.Instance;
        private static MemberService memberService = MemberService.Instance;
        private static LoginInfo loginInfo = loginService.GetLoginInfo();
        private static List<string> options = new List<string>()
        {
            "Show Other Account (Member)",
            "Manage Password",
            "Logout"
        };
        public static void Start()
        {
            while (loginInfo.IsLoggedIn)
            {
                var choice = Helpers.GetChoice(options);

                switch(choice)
                {
                    case 1:
                        try
                        {
                            memberService.GetAllUsername();
                        } catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 2:
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
                        try
                        {
                            loginService.Logout();
                            Console.WriteLine("You've logged out.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                }
            }
        }
    }
}
