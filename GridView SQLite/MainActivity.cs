using System;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GridView_SQLite.mDatabase;


namespace GridView_SQLite
{
    [Activity(Label = "GridView_SQLite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private GridView gv;
        private EditText nameEditText;
        private Button saveBtn, retrieveBtn;
        private ArrayAdapter adapter;
        private JavaList<String> tvShows=new JavaList<string>(); 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            nameEditText = FindViewById<EditText>(Resource.Id.nameTxt);
            saveBtn = FindViewById<Button>(Resource.Id.addBtn);
            retrieveBtn = FindViewById<Button>(Resource.Id.retrieveBtn);
            gv = FindViewById<GridView>(Resource.Id.gv);

            adapter=new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,tvShows);

            saveBtn.Click += saveBtn_Click;
            retrieveBtn.Click += retrieveBtn_Click;
            gv.ItemClick += gv_ItemClick;


        }

        void gv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this,tvShows[e.Position],ToastLength.Short).Show();
        }

        void retrieveBtn_Click(object sender, EventArgs e)
        {
            Retrieve();
        }

        void saveBtn_Click(object sender, EventArgs e)
        {
            Save(nameEditText.Text);
        }

        private void Save(String name)
        {
            DBAdapter db=new DBAdapter(this);
            db.OpenDB();
            if (db.Add(name))
            {
                nameEditText.Text = "";
            }
            else
            {
                Toast.MakeText(this,"Unable To Save",ToastLength.Short).Show();
            }

            db.CloseDB();
        }

        //RTERIEVE
        private void Retrieve()
        {
            tvShows.Clear();

            DBAdapter db = new DBAdapter(this);
            db.OpenDB();
            ;
            ICursor c = db.GetTVShows();
            while (c.MoveToNext())
            {
                String name = c.GetString(1);
                tvShows.Add(name);
            }

            db.CloseDB();

            if (tvShows.Size() > 0)
            {
                gv.Adapter = adapter;
            }
            
        }

    }
}

