using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PlayerData;

namespace Hangman
{
    [Activity(Label = "DBMainActivity")]

    class DBMainActivity : Activity
    {
        //ListView 1stToDoList;
        List<tblHangmanDB> myList;
        DatabaseManager myDbManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //lstToDoList = FindViewById<ListView>(Resource.Id.listView1);
            //CopyTheDB();
            myDbManager = new DatabaseManager();
            myList = myDbManager.ViewAll();
            //lstToDoList.Adapter = new DataAdapter(this, myList);
            //lstToDoList.ItemClick += OnLstToDoListClick;
        }

        //Adds Add to the Menu in the top right of your screen.
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Add");
            return base.OnPrepareOptionsMenu(menu);
        }

        //private void CopyTheDB()
        //{
        //    // Check if your DB has already been extracted.If the file does not exist move it.
        //    if (!File.Exists(dbPath))
        //    {
        //        using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
        //        {
        //            using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
        //            {
        //                byte[] buffer = new byte[2048];
        //                int len = 0;
        //                while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
        //                {
        //                    bw.Write(buffer, 0, len);
        //                }
        //            }
        //        }
        //    }
        //} //This is just to save space should inflate out when run

        //void OnLstToDoListClick(object sender, AdapterView.ItemClickEventArgs e )
        //{
        //    var ToDoItem = myList[e.Position];
        //    var edititem = new Intent(this, typeof(EditItem));
        //    edititem.PutExtra("Title", ToDoItem.Title);
        //    edititem.PutExtra("Details", ToDoItem.Details);
        //    edititem.PutExtra("ListID", ToDoItem.ListId);
        //    StartActivity(edititem);
        //}
        //When you choose Add from the Menu run the Add Activity. Good to know to add more options
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{ var itemTitle = item.TitleFormatted.ToString();
        //    switch (itemTitle) { case "Add": StartActivity(typeof(AddItem));
        //      break;
        //    } return base.OnOptionsItemSelected(item);
        //}
        //Basically reload stuff when the app resumes operation after being paused
        //protected override void OnResume()
        //{ base.OnResume(); myDbManager = new DatabaseManager();
        //    myList = myDbManager.ViewAll();
        //    lstToDoList.Adapter = new DataAdapter(this, myList);
        //}
    }
}



