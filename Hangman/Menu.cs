using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using Java.Util.Jar;

namespace Hangman
{
    [Activity(Label = "Hangman", MainLauncher = true)]
    public class Menu : Activity
    {
        private Button btnPlay;
        private Button btnHighScores;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Set our view from the "Menu" layout resource
            SetContentView(Resource.Layout.Menu);

            IntializeControls();
        }


        public void IntializeControls()
        {
            btnPlay = FindViewById<Button>(Resource.Id.btnPlayHangman);
            btnHighScores = FindViewById<Button>(Resource.Id.btnHighScores);

            btnPlay.Click += delegate
            {
                StartActivity(typeof (PlayerName));
            };

            btnHighScores.Click += delegate
            {
                StartActivity(typeof(HighScores));
            };
        }
        
    }
   
}