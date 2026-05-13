using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ReceiptScreen : Form
    {
        private BindingList<ReceiptItem> _items = new BindingList<ReceiptItem>();
        private const decimal TAX_RATE = 0.10m;

        public class ReceiptItem
        {
            public string ProductName { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; } = 1;
            public decimal SubTotal => UnitPrice * Quantity;
        }

        public ReceiptScreen()
        {
            InitializeComponent();
            InitializeDataGrid();
            LoadSampleData();
        }

        public void SetReceiptData(List<ReceiptItem> items, decimal subtotal, decimal shippingCost, string paymentMethod, DateTime paidDate)
        {
            _items.Clear();
            foreach (var item in items)
            {
                _items.Add(item);
            }

            decimal tax = subtotal * TAX_RATE;
            decimal total = subtotal + shippingCost + tax;

            textBoxSubtotal.Text = subtotal.ToString("C2");
            textBoxShipping.Text = shippingCost.ToString("C2");
            textBoxTax.Text = tax.ToString("C2");
            textBoxTotal.Text = total.ToString("C2");
            textBoxPaymentMethod.Text = paymentMethod;
            textBoxPaidDate.Text = paidDate.ToString("MMMM dd, yyyy - h:mm tt");

            // Generate receipt number
            labelReceiptNumber.Text = $"Order #{GenerateOrderNumber()} | Invoice ID: INV-{GenerateInvoiceNumber()}";
            labelReceiptDate.Text = paidDate.ToString("MMMM dd, yyyy - h:mm tt");
        }

        private void InitializeDataGrid()
        {
            dataGridViewItems.DataSource = _items;
        }

        private void LoadSampleData()
        {
            // Sample data for display - remove when connecting real receipt data
            _items.Add(new ReceiptItem { ProductName = "Blue T-Shirt", UnitPrice = 19.99m, Quantity = 2 });
            _items.Add(new ReceiptItem { ProductName = "Red Mug", UnitPrice = 8.50m, Quantity = 1 });
            _items.Add(new ReceiptItem { ProductName = "Notebook Set", UnitPrice = 12.75m, Quantity = 3 });

            decimal subtotal = _items.Sum(i => i.UnitPrice * i.Quantity);
            decimal shippingCost = 5.00m;
            decimal tax = subtotal * TAX_RATE;
            decimal total = subtotal + shippingCost + tax;

            textBoxSubtotal.Text = subtotal.ToString("C2");
            textBoxShipping.Text = shippingCost.ToString("C2");
            textBoxTax.Text = tax.ToString("C2");
            textBoxTotal.Text = total.ToString("C2");
        }

        private string GenerateOrderNumber()
        {
            return new Random().Next(10000, 99999).ToString();
        }

        private string GenerateInvoiceNumber()
        {
            return new Random().Next(100, 999).ToString();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Print functionality will integrate with PrintDocument.\nThis is a placeholder for the print receipt action.", 
                    "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // TODO: Implement actual print functionality
                // using (PrintDocument pd = new PrintDocument())
                // {
                //     pd.PrintPage += PrintPage_PrintPage;
                //     PrintPreviewDialog ppd = new PrintPreviewDialog { Document = pd };
                //     ppd.ShowDialog();
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Download PDF functionality will generate and save receipt as PDF.\nThis is a placeholder for the download action.", 
                    "Download PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // TODO: Implement PDF generation (use iTextSharp, PdfSharp, or similar)
                // SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF Files|*.pdf", DefaultExt = "pdf" };
                // if (sfd.ShowDialog() == DialogResult.OK)
                // {
                //     // Generate and save PDF
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Download failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
