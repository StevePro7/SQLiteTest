using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MySQLiteTest
{
    public class DataSource : UITableViewSource
    {
        private IList<Invoice> tableItems;
        private const string cellIdentifier = "TableCell";

        public DataSource(IList<Invoice> items)
        {
            this.tableItems = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            }

            cell.TextLabel.Text = tableItems[indexPath.Row].Name;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public void AddItem(Invoice invoice)
        {
            tableItems.Add(invoice);
        }
        public void UpdateItem(String item)
        {
            if (tableItems.Count > 0)
            {
                tableItems[0].Name = item;
            }
        }
        public void RemoveItem()
        {
            if (tableItems.Count > 0)
            {
                tableItems.RemoveAt(0);
            }
        }
    }
}