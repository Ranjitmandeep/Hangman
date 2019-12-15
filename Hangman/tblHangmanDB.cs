using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics.Pdf;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Hangman
{
	class tblHangmanDB
	{
		//These are attributes that define the property below it
		[PrimaryKey, AutoIncrement]

		public int PlayerID { get; set; }

		public string Name { get; set; }

		public string LastWord { get; set; }

		public int Score { get; set; }

		public tblHangmanDB()
		{
			
		}
	}
}