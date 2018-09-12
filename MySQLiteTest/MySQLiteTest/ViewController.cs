using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace MySQLiteTest
{
    public partial class ViewController : UIViewController
    {
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
        }

        public override void ViewWillAppear(bool animated)
        {
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

        private static IList<String> GetItems()
        {
            return new List<String>
            {
                "Steven",
                "Suzanne",
                "Adriana",
            };
        }

    }
}
