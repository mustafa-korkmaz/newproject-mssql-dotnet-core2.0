﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Security.Jwt
{
    public class JwtTokenConstants
    {
        public static SecurityKey IssuerSigningKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GetCryptoSecurityKey()));
            }
        }

        public static SigningCredentials SigningCredentials
        {
            get
            {
                return new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256);
            }
        }
        
        public static TimeSpan TokenExpirationTime
        {
            get
            {
                return TimeSpan.FromDays(30);
            }
        }

        public static string Issuer
        {
            get
            {
                return "Issuer";
            }
        }

        public static string Audience
        {
            get
            {
                return "Audience";
            }
        }



        private static string GetCryptoSecurityKey()
        {
            //TODO: Set this by configuration file
            var securityKey = "Enter your security key here";
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(securityKey));
                return Encoding.ASCII.GetString(result);
            }
        }
    }
}
