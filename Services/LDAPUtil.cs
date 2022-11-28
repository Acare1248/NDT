using System;
using Microsoft.Extensions.Configuration;
using Novell.Directory.Ldap;
using System.Linq;
using System.DirectoryServices;
using System.Collections.Generic;
using System.Runtime.Versioning;
using WebNDTIT01.Models;

namespace WebNDTIT01.Services
{
    public class LDAPUtil
    {
        public static string Host { get; private set; }
        public static int Port { get; private set; }
        public static string BaseDC { get; private set; }
        public static string CookieName { get; private set; }
        public static string GivenName {get; private set;}
        public static string Description {get; private set;}
        public static string Role {get; private set;}
        public static string[] Roles {get; private set;}
        public static string OU {get; private set;}
        public const string LOGINNAME = "sAMAccountName";
        public const string FIRSTNAME = "givenName";
        public const string EMAIL = "mail";

        public static void Register(IConfiguration configuration)
        {
            Host = configuration.GetValue<string>("LDAPServer");
            Port = configuration?.GetValue<int>("LDAPPort") ?? 389;
            BaseDC = configuration.GetValue<string>("LDAPBaseDC");
            CookieName = configuration.GetValue<string>("CookieName");
        }
        public static bool Validate(string username, string password)
        {
            try
            {
                string userDn = $"nichidai\\{username}";
                string BaseDC = "DC=nichidai,DC=co,DC=th";
                using var _connection = new LdapConnection();
                  // _connection.Connect(configuration["Ldap:Domain"], LdapConnection.DefaultPort);
                _connection.Connect(Host, Port);
                _connection.Bind(LdapConnection.LdapV3, userDn, password);
                   // _connection.Bind($"{BindDN},{BaseDC}", BindPassword);
                    var entities = _connection.Search(
                        BaseDC,
                        LdapConnection.ScopeSub,
                        $"sAMAccountName={username}",
                        new string[] { "sAMAccountName", "cn", "mail","memberOf","distinguishedName","description" },
                        false);
                    userDn = null;
                    while (entities.HasMore())
                        {
                            LdapEntry entity = null;
                            try{
                                entity = entities.Next();
                                }
                            catch(LdapException e){
                                string message = e.LdapErrorMessage;
                                continue;
                            }
                            var sAMAccountName = entity.GetAttribute("sAMAccountName")?.StringValue;
                           // var cn = entity.GetAttribute("cn")?.StringValue;
                            GivenName =  entity.GetAttribute("cn")?.StringValue;
                            //Role = entity.GetAttribute("memberOf")?.StringValue;
                            //Role = entity.GetAttribute("memberOf")?.StringValue;
                            var Role = entity.GetAttribute("memberOf"); 
                            if (Role == null)
                            {
                                throw new Exception("Your account is missing roles.");
                            }
                            LDAPUtil l = new LDAPUtil();
                            Roles = Role.StringValueArray
                                    .Select(x => l.GetGroup(x))
                                    .Where(x => x != null)
                                    .Distinct()
                                    .ToArray();

                            OU = entity.GetAttribute("distinguishedName")?.StringValue;
                            Description = entity.GetAttribute("description")?.StringValue;
                            
                            try{
                                var mail = entity.GetAttribute("mail")?.StringValue;
                            }
                            
                            catch{
                                   string mails = null;
                                   var mail =mails;
                                }
                            //If you need to Case insensitive, please modify the below code.
                            if (sAMAccountName != null && sAMAccountName == username)
                            {
                                userDn = entity.Dn;
                                break;
                            }
                        }
                     return true;
            }
            catch (LdapException ldapEx)
            {
                string message = ldapEx.Message;
                return false;
            }
            catch (Exception ss)
            { 
                string ssk = ss.Message;
                return false;
            }
            finally
            {
                    Novell.Directory.Ldap.LdapConnection lc = new Novell.Directory.Ldap.LdapConnection();
                    lc.Disconnect();
            }
        }
        //Check group permission
        private string GetGroup(string value)
        {
            string xxx = null;
            
            if(value.Contains("NDTH_Web_Admin")){
                xxx = "Administrator";
                
            }else{
                xxx = "User";
            }
            return xxx;
        }

        [SupportedOSPlatform("windows")]
       public static List<ADPerson> FinduserAD(string fusername)
        {
            if (fusername == null) {
                fusername = "null";
            }

            List<ADPerson> ADUsers = new List<ADPerson>();

            DirectorySearcher directorysearcher = new DirectorySearcher();
            var path = directorysearcher.SearchRoot.Path;
            DirectoryEntry dirEntry = new DirectoryEntry(path);
            DirectorySearcher dirSearcher = new DirectorySearcher(dirEntry) { Filter = "(" + LDAPUtil.FIRSTNAME + "=*" + fusername + "*)" };

            using (SearchResultCollection cResult = dirSearcher.FindAll())
            {
                if (cResult.Count > 0)
                {
                    foreach (SearchResult sr in cResult)
                    {
                        if (sr.Properties["mail"].Count > 0)
                        {
                            ADUsers.Add(new ADPerson
                            {
                                Name = sr.Properties["displayname"][0].ToString(),
                                Email = sr.Properties["mail"][0].ToString()
                            });
                        }
                    }
                }
                else
                {
                    ADUsers.Add(new ADPerson
                    {
                        Name = "Not found",
                        Email = "-"
                    });
                }
                return ADUsers ;
            }
        }
    }
}
