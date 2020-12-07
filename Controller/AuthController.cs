using System;
using sales_and_inventory.Entity;
using sales_and_inventory.Dao;
using System.Diagnostics;
using System.Windows.Forms;
using sales_and_inventory.Util;

namespace sales_and_inventory.Controller
{

    class AuthController
    {
        public static Form loginForm { get; set; }
        public static Form dashboardForm { get; set; }
        public static User currentUser { get; private set; }

        public static Boolean LogIn(string username, string password)
        {
            // find user with given username
            User user;

            try
            {
                user = UserDao.GetOne(username);

                if (user.username == null)
                {
                    MessageBox.Show("User doesn't exist with given credentials!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // check password
                if (!CryptographyUtil.VerifyHash(password, user.password))
                {
                    MessageBox.Show("Invalid Password!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // decrypt photo
                user.photo = CryptographyUtil.DecryptByteArray(user.password.Substring(0, 32), user.photo);

                currentUser = user;

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Login failed!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Boolean logOut()
        {
            currentUser = null;
            return true;
        }

        public static Boolean Register(User user)
        {
            // encrypt user password and photo
            user.password = CryptographyUtil.GetHash(user.password);
            user.photo = CryptographyUtil.EncryptByteArray(user.password.Substring(0, 32), user.photo);

            try
            {
                UserDao.Save(user);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
