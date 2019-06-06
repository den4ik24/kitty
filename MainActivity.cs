using System;
using Android.App;
using Android.Widget;
using Android.OS;


namespace kitty
{
    [Activity(Label = "kitty", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button calculateButton;
        TextView madamAge;
        SeekBar madamAgeSeekBar;
        TextView numberCats;
        CheckBox married;
        Spinner spinner;
        ImageView imageCat;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            madamAge = FindViewById<TextView>(Resource.Id.madamAge);
            numberCats = FindViewById<TextView>(Resource.Id.numberCats);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            madamAgeSeekBar = FindViewById<SeekBar>(Resource.Id.madamAgeSeekBar);
            married = FindViewById<CheckBox>(Resource.Id.married);
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            imageCat = FindViewById<ImageView>(Resource.Id.imageCat);


            calculateButton.Click += CalculateButton_Click;

            madamAgeSeekBar.ProgressChanged += MadamAgeSeekBar_ProgressChanged;

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.color_hair, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.SetSelection(1);
        }

        //protected override void OnStart()
        //{
        //    base.OnStart();

        //    calculateButton.Click += CalculateButton_Click;

        //    madamAgeSeekBar.ProgressChanged += MadamAgeSeekBar_ProgressChanged;

        //    spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
        //    var adapter = ArrayAdapter.CreateFromResource(
        //            this, Resource.Array.color_hair, Android.Resource.Layout.SimpleSpinnerItem);

        //    adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
        //    spinner.Adapter = adapter;
        //    spinner.SetSelection(1);
        //}

        //protected override void OnStop()
        //{
        //    base.OnStop();

        //    calculateButton.Click -= CalculateButton_Click;

        //    madamAgeSeekBar.ProgressChanged -= MadamAgeSeekBar_ProgressChanged;

        //    spinner.ItemSelected -= new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
        //    var adapter = ArrayAdapter.CreateFromResource(
        //            this, Resource.Array.color_hair, Android.Resource.Layout.SimpleSpinnerItem);

        //    adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
        //    spinner.Adapter = adapter;
        //    spinner.SetSelection(1);
        //}

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            
            int age = int.Parse(madamAge.Text);
            int Result = age / 8;
            numberCats.Text = Result.ToString() + " пушистиков";

            if (married.Checked == false)
            {
                imageCat.SetImageResource(Resource.Drawable.sample1);
            }
          
            if (married.Checked == true)
            {
                numberCats.Text = " Посоветуйся с мужем ";
                imageCat.SetImageResource(Resource.Drawable.sample3);

            }
               
            
        }

        private void MadamAgeSeekBar_ProgressChanged(object sender, EventArgs e)
        {
            madamAge.Text = string.Format("{0}", madamAgeSeekBar.Progress);
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("Цвет волос {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Short).Show();
            
            
            if(spinner.SelectedItemPosition ==0)
            {
                imageCat.SetImageResource(Resource.Drawable.red);
            }

            if (spinner.SelectedItemPosition == 2)
            {
                imageCat.SetImageResource(Resource.Drawable.black);
            }

            if (spinner.SelectedItemPosition == 3)
            {
                imageCat.SetImageResource(Resource.Drawable.rus);
            }

            if (spinner.SelectedItemPosition == 1)
            {
                imageCat.SetImageResource(Resource.Drawable.sample2);
            }
        }

    }
}



