using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "HighScores")]
    public class HighScores : Activity
    {
        private Button btnPlay;
        private Button btnMenu;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "HighScores" layout resource
            SetContentView(Resource.Layout.HighScores);

            IntializeControls();
        }

        public void IntializeControls()
        {
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnMenu = FindViewById<Button>(Resource.Id.btnMenu);

            btnPlay.Click += delegate
            {
                Finish();
                StartActivity(typeof(Hangman));
            };
            btnMenu.Click += delegate
            {
                Finish();
                StartActivity(typeof(Menu));
            };
        }
    }
}