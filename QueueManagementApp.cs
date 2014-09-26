using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueManagementApplication
{
    public partial class QueueManagementApp : Form
    {
        public QueueManagementApp()
        {
            InitializeComponent();
        }


        Queue<CustomerInfo> customerInfos=new Queue<CustomerInfo>();
        public int serialNumber = 0;
        private void enqueueButton_Click(object sender, EventArgs e)

        {
            CustomerInfo customer = new CustomerInfo();
            customer.serialNo = Convert.ToString(++serialNumber);
            customer.name = enqueueNameTextBox.Text;
            customer.complain = enqueueComplainTextBox.Text;

            customerInfos.Enqueue(customer);

            MessageBox.Show(customer.name +" your serial no is" +customer.serialNo);

            ListViewItem cuListViewItem=new ListViewItem(customer.serialNo);
            cuListViewItem.SubItems.Add(customer.name);

            cuListViewItem.SubItems.Add(customer.complain);

            queueListView.Items.Add(cuListViewItem);

 

            enqueueNameTextBox.Text="";
            enqueueComplainTextBox.Text = "";
        }

       private void dequeueButton_Click(object sender, EventArgs e)
      {
           CustomerInfo customer=new CustomerInfo();
           customer = customerInfos.Dequeue();
           serialNoTextBox.Text = customer.serialNo;
           dequeueNameTextBox.Text = customer.name;
           dequeueComplainTextBox.Text = customer.complain;
           queueListView.Items.RemoveAt(0);

      }

    }
}
