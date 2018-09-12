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

            var items = GetItems();
            dataSource = new DataSource(items);
            MyTablveView.Source = dataSource;

            MyAddButton.TouchUpInside += MyAddButton_TouchUpInside;
            MyUpdateButton.TouchUpInside += MyUpdateButton_TouchUpInside;
            MyRemoveButton.TouchUpInside += MyRemoveButton_TouchUpInside;
            MyExitButton.TouchUpInside += MyExitButton_TouchUpInside;

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "exrin.db");
            dataContext = new DataContext(dbPath);
        }

        public override void ViewWillAppear(bool animated)
        {
            IList<Invoice> invoices = dataContext.Invoices.ToList();
            Invoice invoice1 = dataContext.Invoices.Find(123);
            Invoice invoice4 = dataContext.Invoices.Find(456);

            if (invoice1 == null)
            {
                Invoice inv = new Invoice { Id = 123, Name = "Steven", };
                dataContext.Invoices.Add(inv);
            }
            if (invoice4 == null)
            {
                Invoice inv2 = new Invoice { Id = 456, Name = "StevePro", };
                dataContext.Invoices.Add(inv2);
            }

            if (invoice1 != null)
            {
                invoice1.Name = "Suzanne";
                dataContext.Invoices.Update(invoice1);
            }
            if (invoice4 != null)
            {
                invoice4.Name = "Adriana";
                dataContext.Invoices.Update(invoice4);

                //dataContext.Invoices.Remove(invoice4);
            }

            dataContext.SaveChanges();

            base.ViewWillAppear(animated);
        }

        private void MyAddButton_TouchUpInside(object sender, EventArgs e)
        {
            String item = DateTime.Now.ToString();
            dataSource.AddItem(item);
            MyTablveView.ReloadData();
        }

        private void MyUpdateButton_TouchUpInside(object sender, EventArgs e)
        {
            dataSource.UpdateItem("update");
            MyTablveView.ReloadData();
        }

        private void MyRemoveButton_TouchUpInside(object sender, EventArgs e)
        {
            dataSource.RemoveItem("Suzanne");
            MyTablveView.ReloadData();
        }

        private void MyExitButton_TouchUpInside(object sender, EventArgs e)
        {
            throw new System.DivideByZeroException();
        }

        private static IList<Invoice> GetItems()
        {
            IList<Invoice> items = new List<Invoice>();
            items.Add(new Invoice { Id = 1, Name = "Steven" });
            return items;
        }

    }
}
