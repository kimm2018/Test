using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Test
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;

        Dictionary<string, long> dictElapsedTr = new Dictionary<string, long>();
        
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            bool xxxx = Boolean.Parse("f");
            //string sExpiredTime = "2018-07-25T15:42:04Z";
            //DateTime dExpiredTime = Convert.ToDateTime(sExpiredTime);
            //string xs = getExpiredTimeMsg(dExpiredTime);
            //DateTime dd = Convert.ToDateTime(sExpiredTime);
            CCls x= new CCls();
            PParam p = new CParam();
            
            CParam pp = new CParam();
            pp = (CParam)x.PPARAM;
            System.Diagnostics.Debug.WriteLine("aaa");
            System.Console.WriteLine("aaa");

            x.PPARAM = pp;

            CParam xxx = (CParam)x.PPARAM;

            string xab =FmtSec(12311);

            string text = "dfsfa";
            
            System.Windows.Forms.Clipboard.SetText(text);
            //Clipboard.SetDataObject("sdfsd");

            t = new System.Timers.Timer(1000);
            t.Start();
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；

            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；

            t.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件；

            dictElapsedTr.Add("a", 1);
            dictElapsedTr.Add("b", 1);
            dictElapsedTr.Add("c", 1);
            dictElapsedTr.Add("d", 1);
            dictElapsedTr.Add("e", 1);
            StreamReader r = new StreamReader("C:\\Test.py");

            int readChar = 0;
            string result = string.Empty;
            while ((readChar = r.Read()) != -1)
            {
                result += (char)readChar;
            }

            List<int> lstAA= new List<int>();
            Dictionary<int, int> dictSortedItm = new Dictionary<int, int>();
            dictSortedItm.Add(2, 2);
            dictSortedItm.Add(4, 5);
            
            int[] aa = {1,5,3,4,2};
            lstAA = aa.ToList();
            foreach (var itm in dictSortedItm)
	        {
                int insPos = itm.Key;
                int sortedItm = itm.Value;

                for (int j = 0; j < lstAA.Count; j++)
                {
                    int lstCnt = lstAA.Count;
                    if (sortedItm == lstAA[j])
                    {
                        int newItm = lstAA[j];

                        lstAA.RemoveAt(j);
                        if (lstCnt > insPos - 1)
                        {
                            lstAA.Insert(insPos - 1, newItm);
                        }
                        else
                        {
                            lstAA.Add(newItm);
                        }


                        break;
                    }
                }
	        }

            lstAA.ToArray();
            List<string> sss = new List<string>();

            Dictionary<string, int> ssss = new Dictionary<string, int>();
            ssss.Add("s1", 1);
            ssss.Add("s2", 2);

            ssss.Remove("s2");
            
            

            ServiceUnit bb = new ServiceUnit();
            bb.name = "11";

            ServiceUnit[] cc = new ServiceUnit[1];
            cc[0] = bb;

            ServiceUnit[] copy = new ServiceUnit[cc.Length];

            Array.Copy(cc, copy, cc.Length);
            
            

            //for (int i = 0; i < aa.Length; i++)
            //{
            //    int element = aa[i];
            //    int pos = 6;
            //    int arrPos = pos -1;
            //    if (element == 5) 
            //    {
            //        if (lstAA.Count>arrPos)
            //            lstAA.Insert(pos - 1, element);
            //        else
            //            lstAA.Add (element);
            //    }
            //    else
            //        lstAA.Add(element);
            //}
            SUBaseInfo baseInfo;
            
        }

        public struct SUBaseInfo
        {
            public int timer;
            public string cl;
        }

        private string FmtSec( int sec)
        {
            return new DateTime(1970, 01, 01, 00, 00, 00).AddSeconds(sec).ToString("HH:mm:ss");
            
        }

        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            List<string> lstKey = new List<string>();
            lstKey.AddRange(dictElapsedTr.Keys);

            foreach (var key in lstKey)
            {

                long tr = dictElapsedTr[key];
                if (tr > -1)
                {
                    tr = tr + 1;
                    dictElapsedTr[key] = tr;
                }
            }

        }

        private string getExpiredTimeMsg(DateTime dExpiredTime)
        {
            string sMsg = string.Empty;

            try
            {
                DateTime dNow = DateTime.Now;
                TimeSpan timeSpan = dExpiredTime - dNow;

                int days = timeSpan.Days;
                int hrs = timeSpan.Hours;
                int mins = timeSpan.Minutes;
                int milliSecs = timeSpan.Milliseconds;

                if (milliSecs < 0)
                {
                    // Out of date
                    sMsg = "The SU is out of date.";
                }
                else if ((days >= 1) && (days < 3))
                {
                    // Less than 3 days
                    sMsg = string.Format("Expires within {0} days.", Math.Ceiling((decimal)days));
                }
                else if ((hrs >= 1) && (days < 1))
                {
                    // Less than 1 day
                    sMsg = string.Format("Expires within {0} hours.", Math.Ceiling((decimal)hrs));
                }
                else if (hrs < 1)
                {
                    // Less than 1 hour
                    sMsg = string.Format("Expires within {0} mins.", Math.Ceiling((decimal)mins));
                }
            }
            catch
            {
                sMsg = "The conversion of expired time goes wrong.";
            }

            return sMsg;
        }
    }

    public class PParam
    {
        public int a = 1;
    }

    public class CParam: PParam
    {
        public int b = 2;
    }

    public abstract class PCls
    {
        PParam param = new PParam();

        public virtual void add(PParam p)
        {

        }

        public virtual PParam PPARAM
        {
            get { return this.param; }
            set { this.param = value; }
        }
    }

    public class CCls: PCls
    {
        //private CParam cp = new CParam();
        public CCls()
        {
            base.PPARAM = new CParam();
        }
        public override void add(PParam p)
        {

        }

        public override PParam PPARAM
        {
            get { return base.PPARAM; }

            set {
                base.PPARAM = (CParam)value;
            }
        }

    }

    public class ServiceUnit
    {
        public String name { get; set; }
        public String stat { get; set; }
        public String stat_msg { get; set; }
        public DateTime createAt { get; set; }
        public DateTime expiredAt { get; set; }
        public int[] services { get; set; }
    }
}
