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
    [Activity(Label = "Players Name")]
    public class PlayerName : Activity
    {
        private Spinner spinner;
        private string difficulty = "Choose a difficulty";
        private Button btnStart;
        private int RandomNum;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Set our view from the "Name" layout resource
            SetContentView(Resource.Layout.Name);
            
            InitializeControls();
            SpinnerSetup();
        }


        public void InitializeControls()
        {
            btnStart = FindViewById<Button>(Resource.Id.btnStart);

            btnStart.Click += delegate
            {
                StartActivity(typeof(Hangman));
            };
        }

        
        private void SpinnerSetup()
        {
            //Tie in the spinner
            try
            {
                var spinner = FindViewById<Spinner>(Resource.Id.SPDifficulty);

                //Tie it to the method
                spinner.ItemSelected += spinner_ItemSelected;

                //TheCreateFromResource() method then creates a new ArrayAdapter, which binds each item in the string array to the initial appearance for the Spinner
                var arrayadapter = ArrayAdapter.CreateFromResource(this, Resource.Array.difficulty_array, Android.Resource.Layout.SimpleSpinnerDropDownItem);

                //Sets spinner dropdown type
                arrayadapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

                //Setting the ArrayAdapter to associate all of its items with the Spinner by setting the Adapter property 
                spinner.Adapter = arrayadapter;
            }
            catch (Exception e)
            {
                Console.WriteLine("Spinner error " + e.Message);
            }
        }


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //Making a fake spinner to send through data to it
            var spinner = (Spinner)sender;

            //difficulty = spinner.GetItemAtPosition(e.Position).ToString();

            string toast = string.Format("Difficulty set to {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Short).Show();

            //difficulty = difficulty.ToLower();
        }
    }
}