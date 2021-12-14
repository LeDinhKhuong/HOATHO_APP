﻿using APP_HOATHO.Global;
using APP_HOATHO.Models.DuyetChungTu;
using APP_HOATHO.ViewModels.DuyetChungTu;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_HOATHO.Views.MoLaiChungTu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   

    public partial class MoLaiChungTu_Line : ContentPage
    {
        MoLaiChungTaDaDuyet_Line_ViewModel viewModel;

        public MoLaiChungTu_Line(DuyetChungTuModel item, DocumentType type)
        {
            InitializeComponent();

            viewModel = new MoLaiChungTaDaDuyet_Line_ViewModel(item, type);
            viewModel.navigation = Navigation;
            BindingContext = viewModel;
            listChiTiet.QueryRowHeight += DataGrid_QueryRowHeight;
        }
        private void DataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                //Calculates and sets the height of the row based on its content.
                try
                {
                    e.Height = listChiTiet.GetRowHeight(e.RowIndex);
                    e.Handled = true;
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.ListItem.Count == 0)
            {
                IsBusy = false;
                viewModel.LoadCommand.Execute(null);
            }
        }
    }
}