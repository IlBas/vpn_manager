using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;


namespace Security// class for MS domain autantication , could be bypasede by using the registry key managed by the controller
{
    public delegate void OnUserAutanticated(string User);
    public delegate void OnUserDisconnected(string User);
        public class Security
        {
            private string _path;
            private string _filterAttribute;
          
            public Security(string path)
            {
                _path = path;
                    
            }

            public bool IsAuthenticated(string domain, string username, string pwd)
            {
                string domainAndUsername = domain + @"\" + username;
                DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);

                try
                {
                    //Bind to the native AdsObject to force authentication.
                    object obj = entry.NativeObject;

                    DirectorySearcher search = new DirectorySearcher(entry);

                    search.Filter = "(SAMAccountName=" + username + ")";
                   
                    //search.PropertiesToLoad.Add("cn");
                    SearchResultCollection result = search.FindAll();

                    if (null == result)
                    {
                        return false;
                    }

                    //Update the new path to the user in the directory.
                   // _path = result[].Path;
                    _filterAttribute = (string)result[0].Properties["cn"][0];
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception("Error authenticating user. " + ex.Message);
                }

                return true;
            }

            public string GetGroups()
            {
                DirectorySearcher search = new DirectorySearcher(_path);
                search.Filter = "(cn=" + _filterAttribute + ")";
              ///  search.PropertiesToLoad.Add("memberOf");
                StringBuilder groupNames = new StringBuilder();

                try
                {
                    SearchResult result = search.FindOne();
                    int propertyCount = result.Properties["memberOf"].Count;
                    string dn;
                    int equalsIndex, commaIndex;

                    for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                    {
                        dn = (string)result.Properties["memberOf"][propertyCounter];
                        equalsIndex = dn.IndexOf("=", 1);
                        commaIndex = dn.IndexOf(",", 1);
                        if (-1 == equalsIndex)
                        {
                            return null;
                        }
                        groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                        groupNames.Append("|");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error obtaining group names. " + ex.Message);
                }
                return groupNames.ToString();
            }
        }

        public class User
        {
            private string _name;
            private string _memeberof;

            public string user
            {
                get { return _name; }
                set { _name = value; }
            }

            public string Membership
            {
                get { return _memeberof; }
                set { _memeberof = value; }

            }

        }

        public static class LoggedUser
        {
            public static OnUserAutanticated Autanticated;
            public static OnUserDisconnected Disconnected;
            private static User _user = null;

            public static User ActualUser
            {
                get 
                {
                    if (_user != null)
                    {
                        return _user;
                    }
                    else
                    {
                        Login lgn = new Login();
                        lgn.ShowDialog();
                        _user = lgn.user;
                        if (Autanticated != null)
                            Autanticated(_user.user);
                        return _user;
                    }                
                }
            }


            public static bool CheckMembership(string membership)
            {
                if (_user == null)
                {
                    Login lgn = new Login();
                    lgn.ShowDialog();
                    _user = lgn.user;
                }

                if (_user != null)
                {
                    if (Autanticated != null)
                        Autanticated(_user.user);
                    return _user.Membership.ToUpper().Contains(membership);
                }
                return false;
                   
            }

            public static bool Connect ()
            {
                if (_user == null)
                {
                    Login lgn = new Login();
                    lgn.ShowDialog();
                    _user = lgn.user;
                }

                if (_user != null)
                {
                    if (Autanticated != null)
                        Autanticated(_user.user);                    
                }
                return false;

            }
            public static bool Disconnect()
            {
               
                if (_user != null)
                {
                    _user = null;
                    if (Disconnected != null)
                        Disconnected("");
                }
                return false;

            }

        }
    
}
