using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multithreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            ///
            /// Exemplo 1
            ///
            //Task<double> task = BuscarTotal();
            //Task.WaitAll(task);

            //lblTotal.Text = $"Total: R$ {task.Result}";



            ///
            /// Exemplo 2
            ///
            //double t = await BuscarTotal();
            //lblTotal.Text = $"Total: R$ {t}";



            ///
            /// Exemplo 3
            ///
            //Task<double> task = BuscarTotal();
            //double[] taskAll = await Task.WhenAll(task);

            //lblTotal.Text = $"Total: R$ {taskAll[0]}";



            ///
            /// Exemplo 4
            ///
            //Task<double> task = BuscarTotal();
            //Task<double[]> taskAll = Task.WhenAll(task);
            //taskAll.Wait();

            //lblTotal.Text = $"Total: R$ {taskAll.Result[0]}";


            ///
            /// Exemplo 5
            ///
            // BuscarTotal_v2();
            // await AtualizarTotal_v2();
            // AtualizarTotal();
        }




        public Task<double> BuscarTotal()
        {
            return Task.Factory.StartNew<double>(() =>
            {
                Thread.Sleep(5*1000);

                return 100.99;
            });
        }



        public Task AtualizarTotal_v2()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5 * 1000);
                AtualizarTotal();
            });
        }


        public void AtualizarTotal()
        {
            double total = BuscarTotal_v2();

            if (lblTotal.InvokeRequired)
            {
                lblTotal.Invoke(new Action(() => lblTotal.Text = $"Total: R$ {total}"));
            }
            else
            {
                lblTotal.Text = $"Total: R$ {total}";
            }
        }


        public double BuscarTotal_v2()
        {
            // todo
            return 100.9;
        }




    }
}
