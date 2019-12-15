using Hangman;
using SQLite;
using System;
using System.Collections.Generic;
using Environment = Android.OS.Environment;
using Path = System.IO.Path;

namespace PlayerData
{
    class DatabaseManager
    {
        //Your class name must be your table name

        //Connection path
        SQLiteConnection db =
            new SQLiteConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "PlayerData.sqlite"));

        public DatabaseManager()
        {

        }

        public List<tblHangmanDB> ViewAll()
        {
            try
            {
                SQLiteConnection db =
                    new SQLiteConnection(Path.Combine(Environment.ExternalStorageDirectory.ToString(),
                        "PlayerData.sqlite"));

                return db.Query<tblHangmanDB>("SELECT * from HangmanDB");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }

        public void AddItem(string title, string details)
        {
            try
            {
                using (
                    SQLiteConnection db =
                        new SQLiteConnection(Path.Combine(Environment.ExternalStorageDirectory.ToString(),
                            "PlayerData.sqlite")))
                {
                    //var AddThis = new tblHangmanDB() { Title = title, Details = details};
                    //db.Insert(AddThis);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        //public void EditItem(string title, string details, int listid)
        //{
        //    try
        //    {
        //        {
        //            SQLiteConnection db =
        //                new SQLiteConnection(
        //                    System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(),
        //                        "PlayerData.sqlite"));
        //            var EditThis = new tblHangmanDB() { Title = title, Details = details, ListId = listid};
        //            db.Update(EditThis);

        //            //or this
        //            db.Execute("UPDATE tblToDoList Set Title = ?, Details = , WHERE ID = ?", title, details, listid);

        //        }
        //    }
        //    catch (Exception e)

        //    {
        //        Console.WriteLine("UpdateError:" + e.Message);
        //    }
        //}

        public void DeleteItem(int listid)
        {
            try
            {
                SQLiteConnection db = new SQLiteConnection(Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "PlayerData.sqlite"));
                db.Delete<tblHangmanDB>(listid);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Error" + ex.Message);
            }
        }
        //Page 117
    }
}
