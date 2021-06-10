using BlogApi.Db;
using BlogApi.Db.Models;
using BlogApi.Service.DTOs;
using BlogApi.Utils;
using System;
using System.Linq;


namespace BlogApi.Service.Implementations
{
    public class UserService
    {
        private BlogDbContext blogDbContext;
        private JwtUtils jwtUtils;

        public UserService()
        {
            blogDbContext = new BlogDbContext();
            jwtUtils = new JwtUtils();
        }

        public bool RegisterUser(UserDTO user)
        {
            var userEntity = new User() 
            { 
                Username = user.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Email = user.Email,
                CreatedOn = DateTime.Now
            };
            try
            {
                blogDbContext.Users.Add(userEntity);
                blogDbContext.SaveChanges();
            } catch
            {
                return false;
            }
            return true;
        }

        public AuthenticationInfo Login(LoginDTO user)
        {
            if(!CredentialsMatch(user))
            {
                throw new AuthenticationException("Credentials do not match");
            }
            var userFromDb = blogDbContext.Users.Where(u => u.Username == user.Username).FirstOrDefault();
            var token = jwtUtils.GenerateToken(userFromDb);
            return new AuthenticationInfo() { 
                Token = token,
                Username = user.Username
            };
        }

        private bool CredentialsMatch(LoginDTO user)
        {
            var userFromDb = blogDbContext.Users.Where(u => u.Username == user.Username).FirstOrDefault();
            if(userFromDb == null)
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(user.Password, userFromDb.Password);
        }
    }
}