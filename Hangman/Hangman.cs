using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Java.IO;

namespace Hangman
{
    [Activity(Label = "Play Hangman")]
    public class Hangman : Activity
    {
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
        private Button btnE;
        private Button btnF;
        private Button btnG;
        private Button btnH;
        private Button btnI;
        private Button btnJ;
        private Button btnK;
        private Button btnL;
        private Button btnM;
        private Button btnN;
        private Button btnO;
        private Button btnP;
        private Button btnQ;
        private Button btnR;
        private Button btnS;
        private Button btnT;
        private Button btnU;
        private Button btnV;
        private Button btnW;
        private Button btnX;
        private Button btnY;
        private Button btnZ;

        private Button btnNewGame;
        private Button btnMenu;

        List<string> DictList = new List<string>();
        private char[] charGameWord;
        private string GameWord;
        private char[] charUnderScoreWord;

        private int count = 0;

        private TextView textVWord;

        private ImageView imageView;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            LoadWords();
            SetContentView(Resource.Layout.Main);

            IntializeControls();
            WordPicker();
        }

        public void DisableAllButtons()
        {
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            btnE.Enabled = false;
            btnF.Enabled = false;
            btnG.Enabled = false;
            btnH.Enabled = false;
            btnI.Enabled = false;
            btnJ.Enabled = false;
            btnK.Enabled = false;
            btnL.Enabled = false;
            btnM.Enabled = false;
            btnN.Enabled = false;
            btnO.Enabled = false;
            btnP.Enabled = false;
            btnQ.Enabled = false;
            btnR.Enabled = false;
            btnS.Enabled = false;
            btnT.Enabled = false;
            btnU.Enabled = false;
            btnV.Enabled = false;
            btnW.Enabled = false;
            btnX.Enabled = false;
            btnY.Enabled = false;
            btnZ.Enabled = false;
        }

        public void IntializeControls()
        {
            btnA = FindViewById<Button>(Resource.Id.btnA);
            btnB = FindViewById<Button>(Resource.Id.btnB);
            btnC = FindViewById<Button>(Resource.Id.btnC);
            btnD = FindViewById<Button>(Resource.Id.btnD);
            btnE = FindViewById<Button>(Resource.Id.btnE);
            btnF = FindViewById<Button>(Resource.Id.btnF);
            btnG = FindViewById<Button>(Resource.Id.btnG);
            btnH = FindViewById<Button>(Resource.Id.btnH);
            btnI = FindViewById<Button>(Resource.Id.btnI);
            btnJ = FindViewById<Button>(Resource.Id.btnJ);
            btnK = FindViewById<Button>(Resource.Id.btnK);
            btnL = FindViewById<Button>(Resource.Id.btnL);
            btnM = FindViewById<Button>(Resource.Id.btnM);
            btnN = FindViewById<Button>(Resource.Id.btnN);
            btnO = FindViewById<Button>(Resource.Id.btnO);
            btnP = FindViewById<Button>(Resource.Id.btnP);
            btnQ = FindViewById<Button>(Resource.Id.btnQ);
            btnR = FindViewById<Button>(Resource.Id.btnR);
            btnS = FindViewById<Button>(Resource.Id.btnS);
            btnT = FindViewById<Button>(Resource.Id.btnT);
            btnU = FindViewById<Button>(Resource.Id.btnU);
            btnV = FindViewById<Button>(Resource.Id.btnV);
            btnW = FindViewById<Button>(Resource.Id.btnW);
            btnX = FindViewById<Button>(Resource.Id.btnX);
            btnY = FindViewById<Button>(Resource.Id.btnY);
            btnZ = FindViewById<Button>(Resource.Id.btnZ);

            textVWord = FindViewById<TextView>(Resource.Id.textVWord);
            imageView = FindViewById<ImageView>(Resource.Id.imageView);

            btnA.Click += BtnAll_Click;
            btnB.Click += BtnAll_Click;
            btnC.Click += BtnAll_Click;
            btnD.Click += BtnAll_Click;
            btnE.Click += BtnAll_Click;
            btnF.Click += BtnAll_Click;
            btnG.Click += BtnAll_Click;
            btnH.Click += BtnAll_Click;
            btnI.Click += BtnAll_Click;
            btnJ.Click += BtnAll_Click;
            btnK.Click += BtnAll_Click;
            btnL.Click += BtnAll_Click;
            btnM.Click += BtnAll_Click;
            btnN.Click += BtnAll_Click;
            btnO.Click += BtnAll_Click;
            btnP.Click += BtnAll_Click;
            btnQ.Click += BtnAll_Click;
            btnR.Click += BtnAll_Click;
            btnS.Click += BtnAll_Click;
            btnT.Click += BtnAll_Click;
            btnU.Click += BtnAll_Click;
            btnV.Click += BtnAll_Click;
            btnW.Click += BtnAll_Click;
            btnX.Click += BtnAll_Click;
            btnY.Click += BtnAll_Click;
            btnZ.Click += BtnAll_Click;

            btnMenu = FindViewById<Button>(Resource.Id.btnMenu);
            btnNewGame = FindViewById<Button>(Resource.Id.btnNewGame);

            btnNewGame.Click += delegate
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

        private void BtnAll_Click(object sender, EventArgs e)
        {
            //Disabling buttons when clicked
            Button clickedButton = (Button) sender;
            clickedButton.Enabled = false;

            char letter = Convert.ToChar(clickedButton.Text.ToLower());

            AfterButtonClick(letter);
        }

        public void LoadWords()
        {
            //Tying the asset manager to the assets in this project 
            try
            {
                var assets = Assets;
                using (var streamr = new StreamReader(assets.Open("HangmanWords.txt")))
                {
                    while (!streamr.EndOfStream)
                    {
                        string text = streamr.ReadLine();

                        //Ignores empty lines or words less that 4 letters
                        if (text != string.Empty && text.Length > 4)
                        {
                            text = text.Trim();

                            //Adding words in without a dash in them
                            if (!text.Contains("-"))
                            {
                                //Adding words to list
                                DictList.Add(text);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Word list didn't load", ToastLength.Short).Show();
            }
        }


        private void WordPicker()
        {
            Random random = new Random();

            //Gets a random word from a random number generated
            int RandomNum = random.Next(1, DictList.Count);

            GameWord = DictList[RandomNum];
            GameWord = GameWord.ToLower();
            GamePlaySetUp();
        }

        private void GamePlaySetUp()
        {
            //Putting selected word into a char array
            charGameWord = GameWord.ToCharArray();
            charUnderScoreWord = new char[charGameWord.Length];

            //Replacing letters with underscores to hide the word
            for (int i = 0; i < charUnderScoreWord.Length; i++)
            {
                charUnderScoreWord[i] = '_';
            }

            //Showing letters as underscores back in text view
            string textviewword = new string(charUnderScoreWord);

            textVWord.Text = textviewword;
        }

        private void AfterButtonClick(char letter)
        {
            Boolean LoadImageIsIncorrect = true;

            //loop through the word checking if each letter matches the one you clicked
            for (int i = 0; i < charUnderScoreWord.Length; i++)
            {
                //if the letter matches
                if (letter == charGameWord[i])
                {
                    //pass the letter to the underscored char at that place
                    charUnderScoreWord[i] = letter;
                    LoadImageIsIncorrect = false;
                }
                //else if (letter != charGameWord[i])
                //{
                    
                    
                //}
            }

            //Revealing correct letters in the word as they are clicked
            string textviewword = new string(charUnderScoreWord);

            textVWord.Text = textviewword;

            if (LoadImageIsIncorrect == true)
            {
                count++;

                //Changing picture when letter clicked doesn't match letter in the gameword
                switch (count)
                {
                    case 1:
                        imageView = FindViewById<ImageView>(Resource.Id.imageView);
                        imageView.SetImageResource(Resource.Drawable.HM1);
                        break;
                    case 2:
                        imageView = FindViewById<ImageView>(Resource.Id.imageView);
                        imageView.SetImageResource(Resource.Drawable.HM2);
                        break;
                    case 3:
                        imageView = FindViewById<ImageView>(Resource.Id.imageView);
                        imageView.SetImageResource(Resource.Drawable.HM3);
                        break;
                    case 4:
                        imageView = FindViewById<ImageView>(Resource.Id.imageView);
                        imageView.SetImageResource(Resource.Drawable.HM4);
                        break;
                    case 5:
                        imageView = FindViewById<ImageView>(Resource.Id.imageView);
                        imageView.SetImageResource(Resource.Drawable.HM5);
                        break;
                    case 6:
                        imageView = FindViewById<ImageView>(Resource.Id.imageView);
                        imageView.SetImageResource(Resource.Drawable.HM6);
                        Toast.MakeText(this, "You lost, play again?", ToastLength.Short).Show();
                        DisableAllButtons();
                        break;
                }
                
                //After word has been completed disable buttons and display a result you win! Play again?  
            }

            //popup dialogue 

            //async void OnAlertYesNoClicked(object sender, EventArgs e)

            //{
            //    var answer = await Display("Question?", "Would you like to play a game", "Yes", "No");
            //    Debug.WriteLine("Answer: " + answer);
            //}
        }

    }
}


