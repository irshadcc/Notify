using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth;
using Newtonsoft.Json;
using Google.Cloud.Firestore;
using System.Drawing;
using System.Collections;
using System.Drawing.Imaging;
using System.Net.Http;

namespace NotifyV1
{
    class DBInterface
    {
        private static string uid, uname, uemail;
        private static readonly HttpClient client = new HttpClient();
        public static string ocrres = "default";

        //public string ocrres { get; set; }

        private static FirestoreDb database;

        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"ulog.txt";

        public static async Task Authenticate(string email, string password, bool remember, Action callback)
        {
            try
            {

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCDEIkb3liTJxSdPi0wQ76Xq1YJ0jx8D6I"));
                var client = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                uid = client.User.LocalId;
                uname = client.User.DisplayName;
                uemail = client.User.Email;
                //MessageBox.Show("Signed In as " + uemail);

                if (remember)
                {
                    Dictionary<string, string> user = new Dictionary<string, string>()
                    {
                        {"uid",client.User.LocalId},
                        {"uname",client.User.DisplayName},
                        {"uemail",client.User.Email}
                    };

                    File.WriteAllText(path, JsonConvert.SerializeObject(user));
                }

                //Connect();

                callback();

            }
            catch (FirebaseAuthException ex)
            {
                string err = ex.Reason.ToString();
                if(err == "Undefined")
                {
                    MessageBox.Show("Check your Internet Connection");
                }
                else
                {
                    MessageBox.Show(err);
                }
                
            }

        }

        public static string FetchUser()
        {
            var user = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));

            uid = user["uid"];
            uname = user["uname"];
            uemail = user["uemail"];

            return uemail;
        }

        public static void Connect()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"biblography-6adfa-firebase-adminsdk-rl5le-1dc01f91b5.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                database = FirestoreDb.Create("biblography-6adfa");
                
            }
            catch
            {
                MessageBox.Show("Unable to connect to server.");
                Application.Exit();
            }


        }

        public static async void GetNotebookList(Action<List<string>> callback)
        {
            Query qref = database.Collection("notebooks").Document(uid).Collection("user_notebooks");
            QuerySnapshot snap = await qref.GetSnapshotAsync();
            List<string> res = new List<string>();
            foreach (DocumentSnapshot doc in snap)
            {
                //Console.WriteLine(doc.GetValue<string>("title"));
                res.Add(doc.GetValue<string>("title"));
            }
            callback(res);

        }

        public async static Task ApplyOCR(string img64)
        {
            var values = new Dictionary<string, string>
            {
                { "image", img64 },
                { "source", "python" }
            };

            var jsonString = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://ec2-13-232-102-64.ap-south-1.compute.amazonaws.com/recognize", content);

            string resp = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(resp);

            if (data.ContainsKey("error"))
            {
                MessageBox.Show(data["error"]);
                ocrres = "OcrError";
            }
            else
            {
                ocrres = data["text"];
                //MessageBox.Show(ocrres);
            }

        }

        private static ArrayList GetTagList(string tags)
        {

            ArrayList tagarr = new ArrayList();

            string[] taglist = tags.Split(',');

            foreach (string s in taglist)
            {
                if (!string.IsNullOrEmpty(s.Trim()))
                {
                    tagarr.Add(s.Trim());
                }
            }

            return tagarr;
        }

        public static string getBase64(Image img)
        {
            using (MemoryStream m = new MemoryStream())
            {
                img.Save(m, ImageFormat.Png);
                byte[] imageBytes = m.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);


                return base64String;
            }
        }

        public static async void AddTxtNote(string notetitle, string nbtitle, string body, string tags)
        {
            string nbid;
            Query qref = database.Collection("notebooks").Document(uid).Collection("user_notebooks").WhereEqualTo("title", nbtitle).Limit(1);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            if (snap.Count > 0)
            {
                DocumentSnapshot doc = snap[0];
                //MessageBox.Show(doc.Id);
                nbid = doc.Id;
            }
            else
            {
                MessageBox.Show("NB not found");
                nbid = "";
            }

            string trailbody;
            
            if (!string.IsNullOrEmpty(body))
                trailbody = "<br><p>" + body + "</p><br><hr>";
            else
                trailbody = "<br>";

            ArrayList taglist = GetTagList(tags);
            string finalbody = trailbody;
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("title", notetitle);
            data.Add("body", finalbody);
            data.Add("tags", taglist);
            data.Add("notebookID", nbid);
            data.Add("timestamp", Timestamp.GetCurrentTimestamp());

            CollectionReference col = database.Collection("notes").Document(uid).Collection("user_notes");

            _ = col.AddAsync(data);


        }

        public static async void GetOCR(Image img,Action<string> callabck)
        {
            string img64 = getBase64(img);
            await ApplyOCR(img64);
            callabck(ocrres);
            
        }


        public static async void AddImgNote(string notetitle, string nbtitle, string body, string tags, Image img, bool ocr)
        {
            string nbid;
            Query qref = database.Collection("notebooks").Document(uid).Collection("user_notebooks").WhereEqualTo("title", nbtitle).Limit(1);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            if (snap.Count > 0)
            {
                DocumentSnapshot doc = snap[0];
                //MessageBox.Show(doc.Id);
                nbid = doc.Id;
            }
            else
            {
                MessageBox.Show("NB not found");
                nbid = "";
            }

            string initbody = "";
            string trailbody;

            if (!string.IsNullOrEmpty(body))
                trailbody = "<br><p>" + body + "</p><br><hr>";
            else
                trailbody = "<br><hr>";

            string img64 = getBase64(img);
            if (ocr)
            {
                await ApplyOCR(img64);
                //callback(ocrres);
                if (ocrres != "OcrError")
                {
                    initbody = "<p>" + ocrres + "</p><br>";

                    ArrayList taglist = GetTagList(tags);
                    string finalbody = initbody + trailbody;
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("title", notetitle);
                    data.Add("body", finalbody);
                    data.Add("tags", taglist);
                    data.Add("notebookID", nbid);
                    data.Add("timestamp", Timestamp.GetCurrentTimestamp());

                    CollectionReference col = database.Collection("notes").Document(uid).Collection("user_notes");

                    _ = col.AddAsync(data);
                }
            }
            else
            {
                string res = "<img src =\"data:image/png;base64," + img64 + "\"style=\"max-height: 100%; max-width: 100%;\"><br>";
                initbody = res;
                ArrayList taglist = GetTagList(tags);
                string finalbody = initbody + trailbody;
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("title", notetitle);
                data.Add("body", finalbody);
                data.Add("tags", taglist);
                data.Add("notebookID", nbid);
                data.Add("timestamp", Timestamp.GetCurrentTimestamp());

                CollectionReference col = database.Collection("notes").Document(uid).Collection("user_notes");

                _ = col.AddAsync(data);

            }


        }

        public static void AddNotebook(string nbtitle)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("title", nbtitle);
            data.Add("labelID", "2");
            data.Add("timestamp", Timestamp.GetCurrentTimestamp());

            CollectionReference col = database.Collection("notebooks").Document(uid).Collection("user_notebooks");

            _ = col.AddAsync(data);

        }

        public async static void UpdateTxtNote(string notetitle, string tags, string body)
        {
            string noteid;
            string currbody = "";
            ArrayList currtags = new ArrayList();
            Query qref = database.Collection("notes").Document(uid).Collection("user_notes").WhereEqualTo("title", notetitle).Limit(1);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            if (snap.Count > 0)
            {
                DocumentSnapshot doc = snap[0];
                //MessageBox.Show(doc.Id);
                noteid = doc.Id;
                currbody = doc.GetValue<string>("body");
                currtags = doc.GetValue<ArrayList>("tags");
            }
            else
            {
                MessageBox.Show("NB not found");
                noteid = "";
            }

            DocumentReference docref = database.Collection("notes").Document(uid).Collection("user_notes").Document(noteid);
            DocumentSnapshot docsnap = await docref.GetSnapshotAsync();

            if (docsnap.Exists)
            {

                string newbody = currbody + "<br><p>" + body + "</p><br><hr>";

                ArrayList taglist = GetTagList(tags);

                foreach (string tag in taglist)
                {
                    if (!currtags.Contains(tag))
                    {
                        currtags.Add(tag);
                    }
                }

                await docref.UpdateAsync("tags", currtags);
                await docref.UpdateAsync("timestamp", FieldValue.ServerTimestamp);
                await docref.UpdateAsync("body", newbody);
            }

        }


        public async static void UpdateNote(string notetitle, string tags, string body, Image img, bool ocr)
        {
            string noteid;
            string currbody = "";
            ArrayList currtags = new ArrayList();
            Query qref = database.Collection("notes").Document(uid).Collection("user_notes").WhereEqualTo("title", notetitle).Limit(1);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            if (snap.Count > 0)
            {
                DocumentSnapshot doc = snap[0];
                //MessageBox.Show(doc.Id);
                noteid = doc.Id;
                currbody = doc.GetValue<string>("body");
                currtags = doc.GetValue<ArrayList>("tags");
            }
            else
            {
                MessageBox.Show("NB not found");
                noteid = "";
            }

            DocumentReference docref = database.Collection("notes").Document(uid).Collection("user_notes").Document(noteid);
            DocumentSnapshot docsnap = await docref.GetSnapshotAsync();

            if (docsnap.Exists)
            {

                string initbody = "";
                string trailbody;

                if (!string.IsNullOrEmpty(body))
                    trailbody = "<br><p>" + body + "</p><br><hr>";
                else
                    trailbody = "<br><hr>";

                string img64 = getBase64(img);
                if (ocr)
                {
                    await ApplyOCR(img64);
                    if (ocrres != "OcrError")
                    {
                        //MessageBox.Show(ocrres);
                        initbody = "<p>" + ocrres + "</p><br>";
                        string newbody = currbody + initbody + trailbody;
                        ArrayList taglist = GetTagList(tags);

                        foreach (string tag in taglist)
                        {
                            if (!currtags.Contains(tag))
                            {
                                currtags.Add(tag);
                            }
                        }

                        await docref.UpdateAsync("tags", currtags);
                        await docref.UpdateAsync("timestamp", FieldValue.ServerTimestamp);
                        await docref.UpdateAsync("body", newbody);

                    }
                }
                else
                {
                    string res = "<img src =\"data:image/png;base64," + img64 + "\"style=\"max-height: 100%; max-width: 100%;\"><br>";
                    initbody = res;
                    string newbody = currbody + initbody + trailbody;

                    ArrayList taglist = GetTagList(tags);

                    foreach (string tag in taglist)
                    {
                        if (!currtags.Contains(tag))
                        {
                            currtags.Add(tag);
                        }
                    }

                    await docref.UpdateAsync("tags", currtags);
                    await docref.UpdateAsync("timestamp", FieldValue.ServerTimestamp);
                    await docref.UpdateAsync("body", newbody);


                }

            }

        }



        public static async void GetNoteList(string nbtitle, Action<List<string>> callback)
        {
            string nbid;
            Query qref = database.Collection("notebooks").Document(uid).Collection("user_notebooks").WhereEqualTo("title", nbtitle).Limit(1);
            QuerySnapshot snap = await qref.GetSnapshotAsync();
            if (snap.Count > 0)
            {
                DocumentSnapshot doc = snap[0];
                //MessageBox.Show(doc.Id);
                nbid = doc.Id;
            }
            else
            {
                MessageBox.Show("NB not found");
                nbid = "";
            }
            qref = database.Collection("notes").Document(uid).Collection("user_notes").WhereEqualTo("notebookID", nbid);
            snap = await qref.GetSnapshotAsync();
            List<string> res = new List<string>();

            foreach (DocumentSnapshot doc in snap)
            {
                //Console.WriteLine(doc.GetValue<string>("title"));
                res.Add(doc.GetValue<string>("title"));
            }
            callback(res);
        }



    }
}
