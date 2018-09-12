using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UIKit;

namespace MySQLiteTest
{
    public partial class ViewController : UIViewController
    {
        private DataContext dataContext;
        private DataSource dataSource;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //var items = GetItems();
            //dataSource = new DataSource(items);

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "exrin.db");
            dataContext = new DataContext(dbPath);

            IList<Invoice> invoices = dataContext.Invoices.ToList();
            dataSource = new DataSource(invoices);
            MyTablveView.Source = dataSource;

            MyAddButton.TouchUpInside += MyAddButton_TouchUpInside;
            MyUpdateButton.TouchUpInside += MyUpdateButton_TouchUpInside;
            MyRemoveButton.TouchUpInside += MyRemoveButton_TouchUpInside;
            MyExitButton.TouchUpInside += MyExitButton_TouchUpInside;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        private void MyAddButton_TouchUpInside(object sender, EventArgs e)
        {
            String name = DateTime.Now.ToString();

            Invoice invoice = new Invoice { Id = 0, Name = name, };
            dataContext.Invoices.Add(invoice);
            dataContext.SaveChanges();

            dataSource.AddItem(invoice);
            MyTablveView.ReloadData();
        }

        private void MyUpdateButton_TouchUpInside(object sender, EventArgs e)
        {
            IList<Invoice> invoices = dataContext.Invoices.ToList();
            if (0 == invoices.Count)
            {
                return;
            }

            Invoice invoice = invoices[0];
            String name = invoice.Name + "X";
            invoice.Name = name;
            dataContext.Invoices.Update(invoice);
            dataContext.SaveChanges();

            dataSource.UpdateItem(name);
            MyTablveView.ReloadData();
        }

        private void MyRemoveButton_TouchUpInside(object sender, EventArgs e)
        {
            IList<Invoice> invoices = dataContext.Invoices.ToList();
            if (0 == invoices.Count)
            {
                return;
            }

            Invoice invoice = invoices[0];
            dataContext.Invoices.Remove(invoice);
            dataContext.SaveChanges();

            dataSource.RemoveItem();
            MyTablveView.ReloadData();
        }

        private void MyExitButton_TouchUpInside(object sender, EventArgs e)
        {
            throw new System.DivideByZeroException();
        }

        //private static IList<Invoice> GetItems()
        //{
        //    IList<Invoice> items = new List<Invoice>();
        //    items.Add(new Invoice { Id = 1, Name = "Steven" });
        //    return items;
        //}

    }
}
