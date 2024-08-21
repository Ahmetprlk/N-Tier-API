using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions.ClaimExtensions
{
    public class ClaimExtensions
    {
        public static void AddName(ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(name, name));
        }
        public static void AddRoles(ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role=>claims.Add(new Claim(role, role)));
        }
    }
}
